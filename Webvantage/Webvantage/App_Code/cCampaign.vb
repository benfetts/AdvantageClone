Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web

Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports Microsoft.VisualBasic


<Serializable()> Public Class cCampaign

#Region "Public Vars"
    Private mConnString As String
    Private mUserID As String
    Private oSQL As SqlHelper
    Public OFFICE_CODE As String
    Public CL_CODE As String
    Public DIV_CODE As String
    Public PRD_CODE As String
    Public CMP_CODE As String
    Public OFFICE_NAME As String
    Public CL_NAME As String
    Public DIV_NAME As String
    Public PRD_NAME As String
    Public CMP_BEG_DATE As DateTime = Nothing
    Public CMP_END_DATE As DateTime = Nothing
    Public CMP_NAME As String
    Public CMP_DIRECT As Int16 = 0
    Public CMP_MAGAZINE As Int16 = 0
    Public CMP_NEWSPAPER As Int16 = 0
    Public CMP_OUTDOOR As Int16 = 0
    Public CMP_PRINT_COLL As Int16 = 0
    Public CMP_RADIO As Int16 = 0
    Public CMP_TELEVISION As Int16 = 0
    Public CMP_INTERNET As Int16 = 0
    Public CMP_OTHER As Int16 = 0
    Public CMP_OTHER_EXPLAIN As String
    Public CMP_IDENTIFIER As Integer
    Public CMP_CLOSED As Int16 = 0
    Public CMP_BILL_BUDGET As Decimal = 0
    Public CMP_INC_BUDGET As Decimal = 0
    Public CMP_TYPE As Int16
    Public CMP_COMMENTS As String
    Public ALERT_GROUP As String
#End Region
    
    Public Function GetCampaignByCmpIdentifier(ByVal CmpIdentifier As Integer) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramCmpIdentifier As New SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            paramCmpIdentifier.Value = CmpIdentifier
            arParams(0) = paramCmpIdentifier

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_CAMPAIGN_GET_BY_ID", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetCampaignByCmpIdentifier!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetCampaignByCode(ByVal cmpCode As String) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramCmpCode As New SqlParameter("@CmpCode", SqlDbType.VarChar)
            paramCmpCode.Value = cmpCode
            arParams(0) = paramCmpCode

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_campaign_by_code", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetCampaignByCode!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Sub LoadCampaignbyCode(ByVal CmpIdentifier As Integer)
        Try
            Dim dr As SqlDataReader
            If CmpIdentifier > 0 Then
                dr = Me.GetCampaignByCmpIdentifier(CmpIdentifier)
                'ElseIf cmpCode <> "" And CmpIdentifier = 0 Then
                '    dr = GetCampaignByCode(cmpCode)
            End If

            If dr.HasRows Then
                dr.Read()
                OFFICE_CODE = dr.GetString(0)
                OFFICE_NAME = dr.GetString(1)
                CL_CODE = dr.GetString(2)
                CL_NAME = dr.GetString(3)
                DIV_CODE = dr.GetString(4)
                DIV_NAME = dr.GetString(5)
                PRD_CODE = dr.GetString(6)
                PRD_NAME = dr.GetString(7)
                CMP_CODE = dr.GetString(8)
                CMP_NAME = dr.GetString(11)
                'CMP_NAME = CMP_NAME.Replace("''", "'")

                ALERT_GROUP = dr.GetString(27)
                If ALERT_GROUP = "" Then
                    ALERT_GROUP = "[None]"
                End If

                CMP_IDENTIFIER = dr.GetInt32(21)
                CMP_CLOSED = dr.GetInt16(22)

                CMP_BILL_BUDGET = dr.GetDecimal(23)
                CMP_INC_BUDGET = dr.GetDecimal(24)

                Try

                    CMP_BEG_DATE = dr.GetDateTime(9)

                Catch ex As Exception
                End Try
                Try

                    CMP_END_DATE = dr.GetDateTime(10)

                Catch ex As Exception
                End Try

                CMP_DIRECT = dr.GetInt16(12)
                CMP_MAGAZINE = dr.GetInt16(13)
                CMP_NEWSPAPER = dr.GetInt16(14)
                CMP_OUTDOOR = dr.GetInt16(15)
                CMP_PRINT_COLL = dr.GetInt16(16)
                CMP_RADIO = dr.GetInt16(17)
                CMP_TELEVISION = dr.GetInt16(18)
                CMP_INTERNET = dr.GetInt16(28)

                CMP_OTHER = dr.GetInt16(19)
                If CMP_OTHER = 1 Then
                    CMP_OTHER_EXPLAIN = dr.GetString(20)
                Else
                    CMP_OTHER_EXPLAIN = ""
                End If

                CMP_COMMENTS = dr.GetString(26)
                CMP_TYPE = dr.GetInt16(25)

            End If

        Catch ex As Exception
            Err.Raise(Err.Number, "Error LoadCampaignbyCode!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

    Public Function GetAllAttachedMedia(ByVal CmpID As Integer) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramCmpID As New SqlParameter("@CmpID", SqlDbType.VarChar)
            paramCmpID.Value = CmpID
            arParams(0) = paramCmpID

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_attached_media_all", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAllAttachedMedia!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetAlertGroupEmpsByOrder(ByVal Type As String, ByVal orderNbr As Integer, ByVal catID As Integer) As SqlDataReader
        Try
            Dim arParams(2) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramType As New SqlParameter("@Type", SqlDbType.VarChar)
            paramType.Value = Type
            arParams(0) = paramType

            Dim paramOrderNbr As New SqlParameter("@ORDER_NBR", SqlDbType.Int)
            paramOrderNbr.Value = orderNbr
            arParams(1) = paramOrderNbr

            Dim paramAlertType As New SqlParameter("@CAT_ID", SqlDbType.Int)
            paramAlertType.Value = catID
            arParams(2) = paramAlertType

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_alert_group_emps_by_order", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAlertGroupEmpsByOrder!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetDfltAlertGroupMembers(ByVal CmpIdentifier As Integer) As String
        Try
            Dim sb As New System.Text.StringBuilder
            Dim emps As New System.Text.StringBuilder
            Dim rtn As String = ""
            With sb
                .Append("SELECT DISTINCT EMAIL_GROUP.EMP_CODE")
                .Append(" FROM CAMPAIGN WITH(NOLOCK) INNER JOIN")
                .Append(" EMAIL_GROUP WITH(NOLOCK) ON CAMPAIGN.ALERT_GROUP = EMAIL_GROUP.EMAIL_GR_CODE")
                .Append(" WHERE (CAMPAIGN.CMP_IDENTIFIER = ")
                .Append(CmpIdentifier)
                .Append(" ) AND ((EMAIL_GROUP.INACTIVE_FLAG IS NULL) OR (EMAIL_GROUP.INACTIVE_FLAG = 0));")
            End With
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, sb.ToString(), "DtEmps")
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        emps.Append(dt.Rows(i)("EMP_CODE"))
                        emps.Append(",")
                    Next
                    rtn = emps.ToString()
                    rtn = MiscFN.RemoveTrailingDelimiter(rtn, ",")
                End If
            End If
            Return rtn
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GetAlertGroupDefaultEmployees(ByVal alertGroup As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String

        StrSQL = " SELECT EMP_CODE FROM EMAIL_GROUP WHERE PRIMARY_EMP = 1 AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) "
        StrSQL = StrSQL + " AND EMAIL_GR_CODE = '" & alertGroup.Replace("'", "''") & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAlertGroupDefaultEmployees!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

        Return dr
    End Function

    Public Function GetAlertGroupDefaultEmployeesJR(ByVal alertGroup As String) As String

        Dim StrSQL As String
        Dim sb As New System.Text.StringBuilder
        Dim emps As New System.Text.StringBuilder
        Dim rtn As String = ""

        StrSQL = " SELECT EMP_CODE FROM EMAIL_GROUP WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) "
        StrSQL = StrSQL + " AND EMAIL_GR_CODE = '" & alertGroup.Replace("'", "''") & "'"

        Try
            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, StrSQL, "DtEmps")
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        emps.Append(dt.Rows(i)("EMP_CODE"))
                        emps.Append(",")
                    Next
                    rtn = emps.ToString()
                    rtn = MiscFN.RemoveTrailingDelimiter(rtn, ",")
                End If
            End If
            Return rtn
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAlertGroupDefaultEmployees!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function isALertGroupActive(ByVal AlertGroup As String) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim bool As Boolean = True

        StrSQL = " SELECT DISTINCT ISNULL(INACTIVE_FLAG,0) FROM dbo.EMAIL_GROUP "
        StrSQL = StrSQL + " WHERE EMAIL_GR_CODE = '" & AlertGroup.Replace("'", "''") & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            If dr.HasRows Then
                dr.Read()
                If dr.GetInt16(0) = 1 Then
                    bool = False
                End If
            End If

        Catch ex As Exception
            Err.Raise(Err.Number, "Error isALertGroupActive!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

        Return bool

    End Function

    Public Function GetEmailAddressFromGroup(ByVal strEmailGroup As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty
            Dim dr As SqlDataReader
            If strEmailGroup <> "" Then
                Dim arParams(1) As SqlParameter

                Dim paramEmailGroup As New SqlParameter("@EmailGroup", SqlDbType.VarChar, 50)
                paramEmailGroup.Value = strEmailGroup
                arParams(0) = paramEmailGroup

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetEmailAddressFromGroup", arParams)
            End If
            Return dr
        Catch ex As Exception
        End Try
    End Function

    Public Function IsAgencyAutoEmail() As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim bool As Boolean = False
        Dim val As Int16 = 0

        StrSQL = "SELECT AUTO_EMAIL FROM AGENCY "

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            Do While dr.Read
                val = dr.GetInt16(0)
            Loop
            If val = 1 Then
                bool = True
            End If

            Return bool

        Catch ex As Exception
            Err.Raise(Err.Number, "Error IsAgencyAutoEmail!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function getUserFullEmpName(ByVal usercode As String) As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim fullName As String = ""

        StrSQL = "SELECT [dbo].[advfn_get_user_name]('" & usercode & "')"
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            Do While dr.Read
                fullName = dr.GetString(0)
            Loop

            dr.Close()
            Return fullName

        Catch ex As Exception
            Err.Raise(Err.Number, "Error getUserFullEmpName!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function IsAlertCategoryPrompt(ByVal catID As Integer) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim bool As Boolean = False
        Dim val As Int16 = 0

        StrSQL = "SELECT PROMPT FROM ALERT_CATEGORY WHERE ALERT_CAT_ID = " & CStr(catID)

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            Do While dr.Read
                val = dr.GetInt16(0)
            Loop
            If val = 1 Then
                bool = True
            End If

            Return bool

        Catch ex As Exception
            Err.Raise(Err.Number, "Error IsAlertCategoryPrompt!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetAvailableMedia(ByVal type As String, ByVal cl_code As String, ByVal div_code As String, ByVal prd_code As String) As SqlDataReader
        Try
            Dim arParams(4) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramType As New SqlParameter("@Type", SqlDbType.VarChar)
            paramType.Value = type
            arParams(0) = paramType

            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = cl_code
            arParams(1) = paramClient

            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = div_code
            arParams(2) = paramDivision

            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = prd_code
            arParams(3) = paramProduct

            Dim paramTask_UserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar)
            paramTask_UserCode.Value = HttpContext.Current.Session("UserCode")
            arParams(4) = paramTask_UserCode

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_available_media", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAvailableMedia!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function GetAttachedMedia(ByVal Type As String, ByVal cmpID As Integer) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader

            Dim paramType As New SqlParameter("@Type", SqlDbType.VarChar)
            paramType.Value = Type
            arParams(0) = paramType

            Dim paramCmpID As New SqlParameter("@CmpID", SqlDbType.Int)
            paramCmpID.Value = cmpID
            arParams(1) = paramCmpID

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_attached_media", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetAttachedMedia!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function UpdateMediaAttachments(ByVal Type As String, ByVal cmpID As Integer, ByVal OrderNbr As Integer) As String
        Try
            Dim arParams(2) As SqlParameter
            'Dim dr As SqlDataReader

            Dim paramType As New SqlParameter("@Type", SqlDbType.VarChar)
            paramType.Value = Type
            arParams(0) = paramType

            Dim paramCmpID As New SqlParameter("@CMP_ID", SqlDbType.Int)
            paramCmpID.Value = cmpID
            arParams(1) = paramCmpID

            Dim paramOrderNbr As New SqlParameter("@ORDER_NBR", SqlDbType.Int)
            paramOrderNbr.Value = OrderNbr
            arParams(2) = paramOrderNbr

            'dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_update_media_attachments", arParams)
            oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_update_media_attachments", arParams)

            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function GetCampaignSearch(ByVal user As String, _
                                        ByVal office As String, _
                                        ByVal client As String, _
                                        ByVal division As String, _
                                        ByVal product As String, _
                                        ByVal cmp As String, _
                                        ByVal showClosed As Boolean) As DataSet
        Try
            Dim arParams(6) As SqlParameter
            Dim dr As DataSet
            Dim showClosedInt As Integer

            Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUser.Value = user
            arParams(0) = paramUser

            Dim paramOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
            paramOffice.Value = office
            arParams(1) = paramOffice

            Dim paramClient As New SqlParameter("@ClientCode", SqlDbType.VarChar)
            paramClient.Value = client
            arParams(2) = paramClient

            Dim paramDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar)
            paramDivision.Value = division
            arParams(3) = paramDivision

            Dim paramProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar)
            paramProduct.Value = product
            arParams(4) = paramProduct

            Dim paramCmpCode As New SqlParameter("@CmpCode", SqlDbType.VarChar)
            paramCmpCode.Value = cmp
            arParams(5) = paramCmpCode

            If showClosed = True Or cmp <> "" Then  'If cmp is not null, might be closed from search popup and will go to main page
                showClosedInt = 1
            Else
                showClosedInt = 0
            End If
            Dim paramClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
            paramClosed.Value = showClosedInt
            arParams(6) = paramClosed

            dr = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_campaign_search", arParams)

            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetCampaignSearch!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function InsertCampaign() As Integer
        Dim SbSQL As New System.Text.StringBuilder
        Dim StrSQL As String = ""
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim li_max As Integer = 0

        'IF ALERT_GROUP IS NULL, AND PRODUCT IS USED, USE ALERT GROUP FROM PRODUCT AS DEFAULT
        If ALERT_GROUP.Length = 0 Or ALERT_GROUP = "[None]" Then
            If CL_CODE.Length > 0 And DIV_CODE.Length > 0 And PRD_CODE.Length > 0 Then 'Already validated
                StrSQL = " SELECT ISNULL(EMAIL_GR_CODE,'') FROM PRODUCT WHERE CL_CODE = '" & CL_CODE & "' AND DIV_CODE = '" & DIV_CODE & "'  AND PRD_CODE = '" & PRD_CODE & "'"
                Try
                    dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
                    dr.Read()
                    ALERT_GROUP = dr.GetString(0)
                Catch
                    Err.Raise(Err.Number, "Class:cCampaign Routine:InsertCampaign", Err.Description)
                    Return -1
                End Try
            End If
        End If

        Try
            Dim insStr As String = ""
            insStr = "(CL_CODE"
            If OFFICE_CODE.Length > 0 Then
                insStr += ", OFFICE_CODE"
            End If
            If DIV_CODE.Length > 0 Then
                insStr += ", DIV_CODE"
            End If
            If PRD_CODE.Length > 0 Then
                insStr += ", PRD_CODE"
            End If
            insStr += ", CMP_CODE, CMP_NAME, CMP_TYPE, CMP_IDENTIFIER, CMP_CLOSED, ALERT_GROUP)"

            Dim msgStr As String = ""
            With SbSQL
                .Append("INSERT INTO CAMPAIGN ")
                .Append(insStr)
                .Append(" VALUES ('")
                .Append(CL_CODE)
            End With

            If OFFICE_CODE.Length > 0 Then
                With SbSQL
                    .Append("','")
                    .Append(OFFICE_CODE)
                End With
            End If

            If DIV_CODE.Length > 0 Then
                With SbSQL
                    .Append("','")
                    .Append(DIV_CODE)
                End With
            End If

            If PRD_CODE.Length > 0 Then
                With SbSQL
                    .Append("','")
                    .Append(PRD_CODE)
                End With
            End If

            CMP_NAME = CMP_NAME.Replace("'", "''")
            If ALERT_GROUP = "[None]" Then
                ALERT_GROUP = ""
            End If
            With SbSQL
                .Append("','")
                .Append(CMP_CODE)
                .Append("','")
                .Append(CMP_NAME)
                .Append("',")
                .Append(CMP_TYPE)
                .Append(",")
                .Append(CMP_IDENTIFIER)
                .Append(",")
                .Append(0)
                .Append(",'")
                .Append(ALERT_GROUP)
                .Append("');")
            End With

            StrSQL = SbSQL.ToString()

            'Save:
            If StrSQL.Trim() <> "" Then
                Using MyConn As New SqlConnection(mConnString)
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                        'msgStr = "Error inserting campaign into database:&nbsp;&nbsp;" & ex.Message.ToString()
                        Return -1
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            Return 1

        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function CampaignExists(ByVal cmpCode As String) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim li_ct As Integer = 0

        StrSQL = " SELECT COUNT(*) FROM CAMPAIGN WHERE CMP_CODE = '" & cmpCode & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            dr.Read()
            li_ct = dr.GetInt32(0)
        Catch
            Return False
        End Try

        If li_ct > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function CampaignCDPExists(ByVal cmpCode As String, ByVal client As String, Optional ByVal division As String = "", Optional ByVal product As String = "") As Boolean
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim li_ct As Integer = 0

        StrSQL = " SELECT COUNT(*) FROM CAMPAIGN WHERE LTRIM(RTRIM(UPPER(CMP_CODE))) = '" & cmpCode.Trim().ToUpper() & "'"
        StrSQL += " AND CL_CODE = '" & client & "' "
        If division <> "" Then
            StrSQL += " AND DIV_CODE = '" & division & "' "
        End If
        If product <> "" Then
            StrSQL += " AND PRD_CODE = '" & product & "' "
        End If

        Try
            li_ct = oSQL.ExecuteScalar(mConnString, CommandType.Text, StrSQL)
        Catch ex As Exception
            Return False
        End Try


        If li_ct > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function ValidateClient(ByVal client As String) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim li_ct As Integer = 0

        StrSQL = " SELECT COUNT(*) FROM CLIENT WHERE CL_CODE = '" & client & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            dr.Read()
            li_ct = dr.GetInt32(0)
        Catch
            Return False
        End Try

        If li_ct > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidateDivision(ByVal client As String, ByVal division As String) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim li_ct As Integer = 0

        StrSQL = " SELECT COUNT(*) FROM DIVISION WHERE CL_CODE = '" & client & "' AND DIV_CODE = '" & division & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            dr.Read()
            li_ct = dr.GetInt32(0)
        Catch
            Return False
        End Try

        If li_ct > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidateProduct(ByVal client As String, ByVal division As String, ByVal product As String) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim li_ct As Integer = 0

        StrSQL = " SELECT COUNT(*) FROM PRODUCT WHERE CL_CODE = '" & client & "' AND DIV_CODE = '" & division & "' AND PRD_CODE = '" & product & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            dr.Read()
            li_ct = dr.GetInt32(0)
        Catch
            Return False
        End Try

        If li_ct > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidateAlertGroup(ByVal alertGroup As String) As Boolean
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim StrSQL As String
        Dim li_ct As Integer = 0

        StrSQL = " SELECT COUNT(*) FROM ALERT_GROUP WHERE E_GROUP = '" & alertGroup & "'"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            dr.Read()
            li_ct = dr.GetInt32(0)
        Catch
            Return False
        End Try

        If li_ct > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CreateBody(ByVal Subject As String, ByVal url As String, ByVal origCmp As cCampaign, Optional ByVal bodytext As String = "") As String
        'newCmp 0:existing  1:new
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
        Dim NowDate As Date = Now
        Dim rowcount As Integer = 0

        Dim HTMLNewLine As String = "<br />"

        Dim newCampaign As Boolean = False
        Dim tHeader As String
        Dim cmpCategory As String
        If Subject.StartsWith("New Campaign") Then
            newCampaign = True
            tHeader = "[New Alert]"
            cmpCategory = "New Campaign"
        Else
            tHeader = "[Alert Updated]"
            cmpCategory = "Campaign Modified"
        End If

        Dim MyEmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
        With MyEmailBody
            If bodytext.Trim() <> "" Then
                .AddCustomRow(bodytext)
                .AddBlankRow()
            End If
            .AddHeaderRow(tHeader)
            .AddKeyValueRow("Subject", Subject)
            .AddKeyValueRow("Description", CMP_NAME)
            .AddHyperlinkRow(url & "/Campaign.aspx?cmp=" & Me.CMP_IDENTIFIER)

            .AddHeaderRow("General Information")
            .AddKeyValueRow("Type", "Production")
            .AddKeyValueRow("Generated Date", LoGlo.FormatDateTime(NowDate))
            .AddKeyValueRow("Generated By", mUserID)
            .AddKeyValueRow("Priority", "Normal")
            .AddKeyValueRow("Category", cmpCategory)

            .AddHeaderRow("Media Types")
            'stick sb here
            Dim sb As New System.Text.StringBuilder
            Dim ct As Integer = 0
            If CMP_MAGAZINE = 1 Then
                sb.AppendLine("Magazine")
                ct += 1
            End If
            If CMP_NEWSPAPER = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Newspaper")
                Else
                    sb.AppendLine(", Newspaper")
                End If
                ct += 1
            End If
            If CMP_INTERNET = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Internet")
                Else
                    sb.AppendLine(", Internet")
                End If
                ct += 1
            End If
            If CMP_OUTDOOR = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Out of Home")
                Else
                    sb.AppendLine(", Out of Home")
                End If
                ct += 1
            End If
            If CMP_RADIO = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Radio")
                Else
                    sb.AppendLine(", Radio")
                End If
                ct += 1
            End If
            If CMP_TELEVISION = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Television")
                Else
                    sb.AppendLine(", Television")
                End If
                ct += 1
            End If
            If CMP_PRINT_COLL = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Print/Collateral")
                Else
                    sb.AppendLine(", Print/Collateral")
                End If
                ct += 1
            End If
            If CMP_DIRECT = 1 Then
                If ct = 0 Then
                    sb.AppendLine("Direct Response")
                Else
                    sb.AppendLine(", Direct Response")
                End If
            End If
            sb.AppendLine(HTMLNewLine)
            If CMP_OTHER = 1 Then
                sb.AppendLine("Other - " & CMP_OTHER_EXPLAIN)
            End If
            .AddCustomRow(sb.ToString())


            .AddHeaderRow("Campaign Details")
            If Me.OFFICE_CODE = "" Then
                .AddKeyValueRow("Office", "")
            Else
                .AddKeyValueRow("Office", Me.OFFICE_CODE & " - " & Me.OFFICE_NAME)
            End If
            .AddKeyValueRow("Client", Me.CL_CODE & " - " & Me.CL_NAME)
            If Me.DIV_CODE.Trim() = "" Then
                .AddKeyValueRow("Division", "")
            Else
                .AddKeyValueRow("Division", Me.DIV_CODE & " - " & Me.DIV_NAME)
            End If
            If Me.PRD_CODE.Trim() = "" Then
                .AddKeyValueRow("Product", "")
            Else
                .AddKeyValueRow("Product", Me.PRD_CODE & " - " & Me.PRD_NAME)
            End If
            .AddKeyValueRow("Campaign", Me.CMP_CODE & " - " & Me.CMP_NAME)
            .AddBlankRow()
            .AddKeyValueRow("Total Billing", Me.CMP_BILL_BUDGET.ToString("#,##0.00"))
            .AddKeyValueRow("Total Income", Me.CMP_INC_BUDGET.ToString("#,##0.00"))
            Try

                If CMP_BEG_DATE.ToString("d") = "1/1/1900" Or CMP_BEG_DATE = Nothing Then
                    .AddKeyValueRow("Beginning Date", "")
                Else
                    .AddKeyValueRow("Beginning Date", Me.CMP_BEG_DATE.ToShortDateString())
                End If

            Catch ex As Exception

                .AddKeyValueRow("Beginning Date", Me.CMP_BEG_DATE.ToShortDateString())

            End Try
            Try

                If CMP_END_DATE.ToString("d") = "1/1/1900" Or CMP_END_DATE = Nothing Then
                    .AddKeyValueRow("Ending Date", "")
                Else
                    .AddKeyValueRow("Ending Date", Me.CMP_END_DATE.ToShortDateString())
                End If

            Catch ex As Exception

                .AddKeyValueRow("Ending Date", "")

            End Try

            If newCampaign = False Then
                .AddHeaderRow("CHANGES ARE AS FOLLOWS")
                If Me.OFFICE_CODE <> origCmp.OFFICE_CODE Then
                    .AddKeyValueRow("Office", "")
                    If OFFICE_CODE = "" Then
                        .AddKeyValueRow("New Value", "")
                    Else
                        .AddKeyValueRow("New Value", Me.OFFICE_CODE & " -  " & Me.OFFICE_NAME)
                    End If
                    If origCmp.OFFICE_CODE = "" Then
                        .AddKeyValueRow("Old Value", "")
                    Else
                        .AddKeyValueRow("Old Value", origCmp.OFFICE_CODE & " -  " & origCmp.OFFICE_NAME)
                    End If
                End If

                If Me.CMP_NAME <> origCmp.CMP_NAME Then
                    .AddKeyValueRow("Campaign Name", "")
                    .AddKeyValueRow("New Value", Me.CMP_NAME)
                    .AddKeyValueRow("Old Value", origCmp.CMP_NAME)
                End If

                If Me.ALERT_GROUP <> origCmp.ALERT_GROUP Then
                    .AddKeyValueRow("Alert Group", "")
                    .AddKeyValueRow("New Value", Me.ALERT_GROUP)
                    .AddKeyValueRow("Old Value", origCmp.ALERT_GROUP)
                End If

                If Me.CMP_TYPE <> origCmp.CMP_TYPE Then
                    Dim typeDescBefore, typeDescNew As String
                    '1 - Overall
                    '2 - Assigned to Jobs and Orders
                    If Me.CMP_TYPE = 1 Then
                        typeDescBefore = "Assigned to Jobs and Orders"
                        typeDescNew = "Overall"
                    Else
                        typeDescBefore = "Overall"
                        typeDescNew = "Assigned to Jobs and Orders"
                    End If
                    .AddKeyValueRow("Campaign Type", "")
                    .AddKeyValueRow("New Value", typeDescNew)
                    .AddKeyValueRow("Old Value", typeDescBefore)
                End If

                If Me.CMP_BILL_BUDGET <> origCmp.CMP_BILL_BUDGET Then
                    .AddKeyValueRow("Total Billing", "")
                    .AddKeyValueRow("New Value", Me.CMP_BILL_BUDGET.ToString("#,##0.00"))
                    .AddKeyValueRow("Old Value", origCmp.CMP_BILL_BUDGET.ToString("#,##0.00"))
                End If

                If Me.CMP_INC_BUDGET <> origCmp.CMP_INC_BUDGET Then
                    .AddKeyValueRow("Total Income", "")
                    .AddKeyValueRow("New Value", Me.CMP_INC_BUDGET.ToString("#,##0.00"))
                    .AddKeyValueRow("Old Value", origCmp.CMP_INC_BUDGET.ToString("#,##0.00"))
                End If
                Try

                    Dim newdt As String = Me.CMP_BEG_DATE.ToShortDateString
                    Dim origdt As String = origCmp.CMP_BEG_DATE.ToShortDateString
                    If CMP_BEG_DATE.ToString("d") = "1/1/1900" Then
                        newdt = ""
                    End If
                    If origCmp.CMP_BEG_DATE.ToString("d") = "1/1/1900" Then
                        origdt = ""
                    End If
                    If newdt <> origdt Then
                        .AddKeyValueRow("Beginning Date", "")
                        .AddKeyValueRow("New Value", newdt)
                        .AddKeyValueRow("Old Value", origdt)
                    End If

                    Dim newEndDt As String = Me.CMP_END_DATE.ToShortDateString
                    Dim origEndDt As String = origCmp.CMP_END_DATE.ToShortDateString
                    If CMP_END_DATE.ToString("d") = "1/1/1900" Then
                        newEndDt = ""
                    End If
                    If origCmp.CMP_END_DATE.ToString("d") = "1/1/1900" Then
                        origEndDt = ""
                    End If
                    If newEndDt <> origEndDt Then
                        .AddKeyValueRow("Ending Date", "")
                        .AddKeyValueRow("New Value", newEndDt)
                        .AddKeyValueRow("Old Value", origEndDt)
                    End If

                Catch ex As Exception

                End Try
            End If
            .Finish()
        End With

        Return MyEmailBody.ToString()
    End Function

    Public Function CreateBodyString(ByVal Subject As String, ByVal url As String, ByVal origCmp As cCampaign) As String
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
        Dim NowDate As Date = Now
        Dim rowcount As Integer = 0
        Dim sb As New System.Text.StringBuilder

        Dim newCampaign As Boolean = False
        Dim cmpCategory As String
        If Subject.StartsWith("New Campaign") Then
            newCampaign = True
            cmpCategory = "New Campaign"
        Else
            cmpCategory = "Campaign Modified"
        End If

        sb.AppendLine("Subject: " & Subject)
        sb.AppendLine("Description: " & CMP_NAME & vbCrLf)

        sb.AppendLine("General Information")
        sb.AppendLine("  Type: Production")
        sb.AppendLine(String.Format("  Generated Date: {0:G}", cEmployee.TimeZoneToday))
        'sb.AppendLine("  Generated Date: " & Format(NowDate, "MM/dd/yyyy hh:mm tt"))
        sb.AppendLine("  Generated By: " & mUserID)
        sb.AppendLine("  Priority: Normal")
        sb.AppendLine("  Category: " & cmpCategory & vbCrLf)

        Dim ct As Integer = 0
        sb.AppendLine("Media Types")
        If CMP_MAGAZINE = 1 Then
            sb.AppendLine("  Magazine")
            ct += 1
        End If

        If CMP_NEWSPAPER = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Newspaper")
            Else
                sb.Append(", Newspaper")
            End If
            ct += 1
        End If

        If CMP_INTERNET = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Internet")
            Else
                sb.Append(", Internet")
            End If
            ct += 1
        End If

        If CMP_OUTDOOR = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Out of Home")
            Else
                sb.Append(", Out of Home")
            End If
            ct += 1
        End If

        If CMP_RADIO = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Radio")
            Else
                sb.Append(", Radio")
            End If
            ct += 1
        End If

        If CMP_TELEVISION = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Television")
            Else
                sb.Append(", Television")
            End If
            ct += 1
        End If

        If CMP_PRINT_COLL = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Print/Collateral")
            Else
                sb.Append(", Print/Collateral")
            End If
            ct += 1
        End If

        If CMP_DIRECT = 1 Then
            If ct = 0 Then
                sb.AppendLine("  Direct Response")
            Else
                sb.Append(", Direct Response")
            End If
            ct += 1
        End If

        If CMP_OTHER = 1 Then
            sb.AppendLine("  Other - " & CMP_OTHER_EXPLAIN)
        End If
        sb.AppendLine(vbLf)

        sb.AppendLine("Campaign Details")

        If OFFICE_CODE = "" Then
            sb.AppendLine("  Office: ")
        Else
            sb.AppendLine("  Office: " & Me.OFFICE_CODE & " - " & Me.OFFICE_NAME)
        End If

        sb.AppendLine("  Client: " & Me.CL_CODE & " - " & Me.CL_NAME)

        If DIV_CODE = "" Then
            sb.AppendLine("  Division: ")
        Else
            sb.AppendLine("  Division: " & Me.DIV_CODE & " - " & Me.DIV_NAME)
        End If

        If PRD_CODE = "" Then
            sb.AppendLine("  Product: ")
        Else
            sb.AppendLine("  Product: " & Me.PRD_CODE & " - " & Me.PRD_NAME)
        End If

        sb.AppendLine("  Campaign: " & Me.CMP_CODE & " - " & Me.CMP_NAME & vbCrLf)

        If newCampaign = False Then
            sb.AppendLine("***********************")
            sb.AppendLine("CHANGES ARE AS FOLLOWS")
            sb.AppendLine("***********************")

            If Me.OFFICE_CODE <> origCmp.OFFICE_CODE Then
                sb.AppendLine("Office")
                If OFFICE_CODE = "" Then
                    sb.AppendLine("  New Value:")
                Else
                    sb.AppendLine("  New Value:" & Me.OFFICE_CODE & " -  " & Me.OFFICE_NAME)
                End If
                If origCmp.OFFICE_CODE = "" Then
                    sb.AppendLine("  Old Value:" & vbCrLf)
                Else
                    sb.AppendLine("  Old Value:" & origCmp.OFFICE_CODE & " -  " & origCmp.OFFICE_NAME & vbCrLf)
                End If

            End If
            If Me.CMP_NAME <> origCmp.CMP_NAME Then
                sb.AppendLine("Campaign Name")
                sb.AppendLine("  New Value:" & Me.CMP_NAME)
                sb.AppendLine("  Old Value:" & origCmp.CMP_NAME & vbCrLf)
            End If
            If Me.ALERT_GROUP <> origCmp.ALERT_GROUP Then
                sb.AppendLine("Alert Group")
                sb.AppendLine("  New Value:" & Me.ALERT_GROUP)
                sb.AppendLine("  Old Value:" & origCmp.ALERT_GROUP & vbCrLf)
            End If
            If Me.CMP_TYPE <> origCmp.CMP_TYPE Then
                Dim typeDescBefore, typeDescNew As String
                '1 - Overall
                '2 - Assigned to Jobs and Orders
                If Me.CMP_TYPE = 1 Then
                    typeDescBefore = "Assigned to Jobs and Orders"
                    typeDescNew = "Overall"
                Else
                    typeDescBefore = "Overall"
                    typeDescNew = "Assigned to Jobs and Orders"
                End If
                sb.AppendLine("Campaign Type")
                sb.AppendLine("  New Value:" & typeDescNew)
                sb.AppendLine("  Old Value:" & typeDescBefore & vbCrLf)
            End If
            If Me.CMP_BILL_BUDGET <> origCmp.CMP_BILL_BUDGET Then
                sb.AppendLine("Total Billing")
                sb.AppendLine("  New Value:" & Me.CMP_BILL_BUDGET.ToString("#,##0.00"))
                sb.AppendLine("  Old Value:" & origCmp.CMP_BILL_BUDGET.ToString("#,##0.00") & vbCrLf)
            End If
            If Me.CMP_INC_BUDGET <> origCmp.CMP_INC_BUDGET Then
                sb.AppendLine("Total Income")
                sb.AppendLine("  New Value:" & Me.CMP_INC_BUDGET.ToString("#,##0.00"))
                sb.AppendLine("  Old Value:" & origCmp.CMP_INC_BUDGET.ToString("#,##0.00") & vbCrLf)
            End If

            Try

                'If Me.CMP_BEG_DATE <> origCmp.CMP_BEG_DATE Then
                '    sb.AppendLine("Beginning Date")
                '    sb.AppendLine("  New Value:" & Me.CMP_BEG_DATE.ToString("MM/dd/yyyy"))
                '    sb.AppendLine("  Old Value:" & origCmp.CMP_BEG_DATE.ToString("MM/dd/yyyy") & vbCrLf)
                'End If
                '****
                Dim newdt As String = Me.CMP_BEG_DATE.ToString("MM/dd/yyyy")
                Dim origdt As String = origCmp.CMP_BEG_DATE.ToString("MM/dd/yyyy")
                If CMP_BEG_DATE.ToString("d") = "1/1/1900" Then
                    newdt = ""
                End If
                If origCmp.CMP_BEG_DATE.ToString("d") = "1/1/1900" Then
                    origdt = ""
                End If

                If newdt <> origdt Then
                    sb.AppendLine("Beginning Date")
                    sb.AppendLine("  New Value:" & newdt)
                    sb.AppendLine("  Old Value:" & origdt & vbCrLf)
                End If


                'If Me.CMP_END_DATE <> origCmp.CMP_END_DATE Then
                '    sb.AppendLine("Ending Date")
                '    sb.AppendLine("  New Value:" & Me.CMP_END_DATE.ToString("MM/dd/yyyy"))
                '    sb.AppendLine("  Old Value:" & origCmp.CMP_END_DATE.ToString("MM/dd/yyyy"))
                'End If
                '*****
                Dim newEndDt As String = Me.CMP_END_DATE.ToString("MM/dd/yyyy")
                Dim origEndDt As String = origCmp.CMP_END_DATE.ToString("MM/dd/yyyy")
                If CMP_END_DATE.ToString("d") = "1/1/1900" Then
                    newEndDt = ""
                End If
                If origCmp.CMP_END_DATE.ToString("d") = "1/1/1900" Then
                    origEndDt = ""
                End If

                If newEndDt <> origEndDt Then
                    sb.AppendLine("Ending Date")
                    sb.AppendLine("  New Value:" & newEndDt)
                    sb.AppendLine("  Old Value:" & origEndDt)
                End If

            Catch ex As Exception

            End Try

        End If

        Return sb.ToString

    End Function

    Public Function getNextCampaignIdentifier() As Integer
        Dim StrSQL As String = ""
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim li_max As Integer = 0

        StrSQL = " SELECT MAX(CMP_IDENTIFIER) FROM CAMPAIGN "
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            dr.Read()
            If IsDBNull(dr(0)) = False Then
                li_max = dr.GetInt32(0)
            End If
            li_max = li_max + 1

            Return li_max
        Catch
            Err.Raise(Err.Number, "Class:cCampaign Routine:InsertCampaign", Err.Description)
            Return -1
        End Try

    End Function

    Public Sub New(ByVal conn As String, Optional ByVal CmpID As Integer = 0)
        mConnString = conn
        mUserID = HttpContext.Current.Session("UserCode")

        If CmpID <> 0 Then
            LoadCampaignbyCode(CmpID)
        End If

    End Sub


    Public Function InsertCampaign2() As String
        '**************************
        ' NOT USED
        '**************************
        Dim SbSQL As New System.Text.StringBuilder
        Dim StrSQL As String = ""

        Try
            With SbSQL
                .Append("INSERT INTO CAMPAIGN (OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, CMP_BEG_DATE, CMP_END_DATE, ")
                .Append(" CMP_NAME, CMP_DIRECT, CMP_MAGAZINE, CMP_NEWSPAPER, CMP_OUTDOOR, CMP_PRINT_COLL,")
                .Append(" CMP_RADIO, CMP_TELEVISION, CMP_OTHER, CMP_OTHER_EXPLAIN, CMP_CLOSED, CMP_BILL_BUDGET, CMP_INC_BUDGET, CMP_TYPE, CMP_COMMENTS ")
                .Append(" VALUES ('")
                .Append(OFFICE_CODE)
                .Append("','")
                .Append(CL_CODE)
                .Append("','")
                .Append(DIV_CODE)
                .Append("','")
                .Append(PRD_CODE)
                .Append("','")
                .Append(CMP_CODE)
                .Append("','")
                .Append(CMP_BEG_DATE)
                .Append("','")
                .Append(CMP_END_DATE)
                .Append("','")
                .Append(CMP_NAME)
                .Append("','")
                .Append(CMP_DIRECT)
                .Append("','")
                .Append(CMP_MAGAZINE)
                .Append("','")
                .Append(CMP_NEWSPAPER)
                .Append("','")
                .Append(CMP_OUTDOOR)
                .Append("','")
                .Append(CMP_PRINT_COLL)
                .Append("','")
                .Append(CMP_RADIO)
                .Append("','")
                .Append(CMP_TELEVISION)
                .Append("','")
                .Append(CMP_OTHER)
                .Append("','")
                .Append(CMP_OTHER_EXPLAIN)
                .Append("','")
                .Append(CMP_CLOSED)
                .Append("','")
                .Append(CMP_BILL_BUDGET)
                .Append("','")
                .Append(CMP_INC_BUDGET)
                .Append("','")
                .Append(CMP_TYPE)
                .Append("','")
                .Append(CMP_COMMENTS)
                .Append("');")
            End With

            StrSQL = SbSQL.ToString()

            'Save:
            If StrSQL.Trim() <> "" Then
                Using MyConn As New SqlConnection(mConnString)
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                        Return "Error inserting campaign into database:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            Return ""
        Catch ex As Exception
            Return "Error inserting campaign into database:&nbsp;&nbsp;" & ex.Message.ToString()
        End Try

    End Function


End Class
