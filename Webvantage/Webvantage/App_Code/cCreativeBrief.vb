Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web

Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls

<Serializable()> Public Class cCreativeBrief
    Private mConnString As String
    Private mUserID As String
    Private mEmpCode As String
    Private oSQL As SqlHelper
    'Private OpenSpacerTable As String = "<table width=""98%"" border=""0"" style=""vertical-align:top"" cellpadding=""0"" cellspacing=""2"" align=""center"">"
    Private OpenSpacerTable As String = "<table>"
    Private CloseSpacerTable As String = "</table>"
    Private RTFOpen As String = "{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fnil\fcharset0 MS Sans Serif;}}\viewkind4\uc1\pard\lang1033\f0\fs17 "
    Private RTFClose As String = "\par }"
    Private HTMLOpen As String = "<html><body>"
    Private HTMLClose As String = "</body></html>"


    Public Sub New(ByVal ConnStr As String, ByVal UserID As String, Optional ByVal EmpCode As String = "")
        mConnString = ConnStr
        mUserID = UserID

        If EmpCode <> "" Then
            mEmpCode = EmpCode
        End If
    End Sub

    Public Function GetCreativeBriefTmplt_dd() As SqlDataReader
        Try
            Dim dr As SqlDataReader

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_CreativeBriefTmplts")

            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetCreativeBriefTmplt_dd!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try
    End Function

    Public Function CreativeBriefTmpltData(ByVal job As String, ByVal comp As String, ByVal omit As Integer) As DataTable
        Try
            Dim dt As DataTable
            Dim arParams(2) As SqlParameter

            Dim paramJob As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJob.Value = job
            arParams(0) = paramJob

            Dim paramComp As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramComp.Value = comp
            arParams(1) = paramComp

            Dim paramOmit As New SqlParameter("@OmitEmptyFields", SqlDbType.Int)
            paramOmit.Value = omit
            arParams(2) = paramOmit

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Creative_Brief_Report", "dt", arParams)

            Return dt

        Catch ex As Exception
            Err.Raise(Err.Number, "Error CreativeBriefTmpltData!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())

        End Try
    End Function

    Public Function getTooltipEst(ByVal job As String, ByVal comp As String) As SqlDataReader
        Dim dr As SqlDataReader

        Try
            Dim arParams(1) As SqlParameter

            Dim paramJob As New SqlParameter("@JobNum", SqlDbType.VarChar)
            paramJob.Value = job
            arParams(0) = paramJob

            Dim paramComp As New SqlParameter("@JobComp", SqlDbType.VarChar)
            paramComp.Value = comp
            arParams(1) = paramComp

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_est_tooltip", arParams)
            Return dr

        Catch ex As Exception
            Err.Raise(Err.Number, "Error getTooltipEst!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try

    End Function

    Public Function AddCreativeBriefJobComp(ByVal BrfCode As String, ByVal job As Int32, ByVal comp As Int16) As Int16
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim arParams(5) As SqlParameter

                Dim paramCode As New SqlParameter("@CRTV_BRF_CODE", SqlDbType.VarChar)
                paramCode.Value = BrfCode
                arParams(0) = paramCode

                Dim paramJob As New SqlParameter("@JOB_NBR", SqlDbType.Int)
                paramJob.Value = job
                arParams(1) = paramJob

                Dim paramComp As New SqlParameter("@COMP_NBR", SqlDbType.SmallInt)
                paramComp.Value = comp
                arParams(2) = paramComp

                Dim paramUser As New SqlParameter("@USERID", SqlDbType.VarChar)
                paramUser.Value = mUserID
                arParams(3) = paramUser

                Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
                pCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, HttpContext.Current.Session("EmpCode"))
                arParams(4) = pCreateDate

                oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_AddCreativeBriefJobComp", arParams)

            End Using

        Catch ex As Exception
            Err.Raise(Err.Number, "Error AddCreativeBriefJobComp!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            Return -1
        End Try

        Return 1

    End Function

    Public Function AddCreativeBriefApproval(ByVal job As Int32, ByVal comp As Int16, ByVal ApprovedBy As String, ByVal ApprovedComment As String, ByVal UserCode As String, ByVal ApprovalDate As Date, ByVal IsCP As Boolean, ByVal CP_ID As Integer) As Int16
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim arParams(8) As SqlParameter

                Dim paramJob As New SqlParameter("@JobNum", SqlDbType.Int)
                paramJob.Value = job
                arParams(0) = paramJob

                Dim paramComp As New SqlParameter("@JobCompNum", SqlDbType.SmallInt)
                paramComp.Value = comp
                arParams(1) = paramComp

                Dim paramApprovedBy As New SqlParameter("@ApprovedBy", SqlDbType.VarChar)
                paramApprovedBy.Value = ApprovedBy
                arParams(2) = paramApprovedBy

                Dim paramApprovedComment As New SqlParameter("@ApprovedComment", SqlDbType.VarChar)
                paramApprovedComment.Value = ApprovedComment
                arParams(3) = paramApprovedComment

                Dim paramUser As New SqlParameter("@UserCode", SqlDbType.VarChar)
                paramUser.Value = UserCode
                arParams(4) = paramUser

                Dim pCreateDate As New SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime)
                pCreateDate.Value = ApprovalDate
                arParams(5) = pCreateDate

                Dim paramIsCP As New SqlParameter("@IsCP", SqlDbType.Bit)
                paramIsCP.Value = IsCP
                arParams(6) = paramIsCP

                Dim paramCP_ID As New SqlParameter("@CP_ID", SqlDbType.Int)
                paramCP_ID.Value = CP_ID
                arParams(7) = paramCP_ID

                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Creative_Brief_Approval_Add", arParams)

            End Using

        Catch ex As Exception
            Err.Raise(Err.Number, "Error AddCreativeBriefJobComp!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            Return -1
        End Try

        Return 1

    End Function
    Public Function UpdateCreativeBriefApproval(ByVal job As Int32, ByVal comp As Int16, ByVal ApprovedBy As String, ByVal ApprovedComment As String, ByVal UserCode As String, ByVal ApprovalDate As Date, ByVal IsCP As Boolean, ByVal CP_ID As Integer) As Int16
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim arParams(8) As SqlParameter

                Dim paramJob As New SqlParameter("@JobNum", SqlDbType.Int)
                paramJob.Value = job
                arParams(0) = paramJob

                Dim paramComp As New SqlParameter("@JobCompNum", SqlDbType.SmallInt)
                paramComp.Value = comp
                arParams(1) = paramComp

                Dim paramApprovedBy As New SqlParameter("@ApprovedBy", SqlDbType.VarChar)
                paramApprovedBy.Value = ApprovedBy
                arParams(2) = paramApprovedBy

                Dim paramApprovedComment As New SqlParameter("@ApprovedComment", SqlDbType.VarChar)
                paramApprovedComment.Value = ApprovedComment
                arParams(3) = paramApprovedComment

                Dim paramUser As New SqlParameter("@UserCode", SqlDbType.VarChar)
                paramUser.Value = UserCode
                arParams(4) = paramUser

                Dim pCreateDate As New SqlParameter("@ApprovalDate", SqlDbType.SmallDateTime)
                pCreateDate.Value = ApprovalDate
                arParams(5) = pCreateDate

                Dim paramIsCP As New SqlParameter("@IsCP", SqlDbType.Bit)
                paramIsCP.Value = IsCP
                arParams(6) = paramIsCP

                Dim paramCP_ID As New SqlParameter("@CP_ID", SqlDbType.Int)
                paramCP_ID.Value = CP_ID
                arParams(7) = paramCP_ID

                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Creative_Brief_Approval_Update", arParams)

            End Using

        Catch ex As Exception
            Err.Raise(Err.Number, "Error AddCreativeBriefJobComp!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            Return -1
        End Try

        Return 1

    End Function
    Public Function CopyCreativeBriefJobComp(ByVal BrfCode As String, ByVal job As Int32, ByVal comp As Int16, ByVal jobcopy As Int32, ByVal compcopy As Int16) As Int16
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim arParams(7) As SqlParameter

                Dim paramCode As New SqlParameter("@CRTV_BRF_CODE", SqlDbType.VarChar)
                paramCode.Value = BrfCode
                arParams(0) = paramCode

                Dim paramJob As New SqlParameter("@JOB_NBR", SqlDbType.Int)
                paramJob.Value = job
                arParams(1) = paramJob

                Dim paramComp As New SqlParameter("@COMP_NBR", SqlDbType.SmallInt)
                paramComp.Value = comp
                arParams(2) = paramComp

                Dim paramJobCopy As New SqlParameter("@JOB_NBR_COPY", SqlDbType.Int)
                paramJobCopy.Value = jobcopy
                arParams(3) = paramJobCopy

                Dim paramCompCopy As New SqlParameter("@COMP_NBR_COPY", SqlDbType.SmallInt)
                paramCompCopy.Value = compcopy
                arParams(4) = paramCompCopy

                Dim paramUser As New SqlParameter("@USERID", SqlDbType.VarChar)
                paramUser.Value = mUserID
                arParams(5) = paramUser

                Dim pCreateDate As New SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
                pCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, HttpContext.Current.Session("EmpCode"))
                arParams(6) = pCreateDate
                oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_CopyCreativeBriefJobComp", arParams)

            End Using

        Catch ex As Exception
            Err.Raise(Err.Number, "Error CopyCreativeBriefJobComp!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            Return -1
        End Try

        Return 1
    End Function

    Public Function ExistingTemplates(ByVal job As Integer, ByVal comp As Int16) As Boolean

        Dim oSQL As SqlHelper
        Dim count As Integer = 0

        Try

            count = CType(oSQL.ExecuteScalar(mConnString, CommandType.Text, String.Format("SELECT COUNT(1) FROM CRTV_BRF_DTL WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", job, comp)), Integer)
            Return count > 0

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub getfontInfo(ByVal JobNum As Int32, ByVal JobCompNum As Int16, ByVal level As Integer, _
                           ByRef fontsize1 As String, ByRef fontStyle1 As String, _
                           ByRef fontsize2 As String, ByRef fontStyle2 As String, _
                           ByRef fontsize3 As String, ByRef fontStyle3 As String, _
                           ByRef fontsize4 As String, ByRef fontStyle4 As String)
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        Dim BriefDefID As Integer
        Dim styleStr, fontSplit(4), fontsizestr As String
        Dim fontsizelength As Int16
        Dim sizeidx, idx As Int16

        BriefDefID = getBriefDefID(JobNum, JobCompNum)

        'Select Case level
        '    Case "1"
        '        SQL_STRING = "SELECT LVL1_STYLE "
        '    Case "2"
        '        SQL_STRING = "SELECT LVL2_STYLE "
        '    Case "3"
        '        SQL_STRING = "SELECT LVL3_STYLE "
        '    Case "4"
        '        SQL_STRING = "SELECT DTL_STYLE "
        'End Select

        SQL_STRING &= " SELECT LVL1_STYLE,LVL2_STYLE,LVL3_STYLE,DTL_STYLE FROM CRTV_BRF_DEF "
        SQL_STRING &= " WHERE CRTV_BRF_DEF_ID = " & BriefDefID
        SQL_STRING &= " AND ( ACTIVE_FLAG IS NULL OR ACTIVE_FLAG = 0) "

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getfontInfo", Err.Description)
        Finally
        End Try

        fontsize1 = "8"
        fontStyle1 = ""
        fontsize2 = "8"
        fontStyle2 = ""
        fontsize3 = "8"
        fontStyle3 = ""
        fontsize4 = "8"
        fontStyle4 = ""
        If dr.HasRows Then
            dr.Read()
            fontStyle1 = dr(0)
            setfont(1, fontsize1, fontStyle1)
            fontStyle2 = dr(1)
            setfont(2, fontsize2, fontStyle2)
            fontStyle3 = dr(2)
            setfont(3, fontsize3, fontStyle3)
            fontStyle4 = dr(3)
            setfont(4, fontsize4, fontStyle4)
            dr.Close()
        End If
    End Sub

    Public Function setfont(ByVal level As Integer, ByRef fontsize As String, ByRef fontStyle As String)
        Try
            Dim styleStr, fontSplit(4), fontsizestr As String
            Dim sizeidx, idx As Int16

            styleStr = fontStyle

            fontSplit = styleStr.Split

            If fontSplit.Length = 1 Then    'Size only, no styles
                If Left(fontSplit(0), 4) = "size" Then
                    fontsizestr = fontSplit(0).Remove(0, 4)
                    If IsNumeric(fontsizestr) Then
                        fontsize = fontsizestr
                    End If
                End If

            ElseIf fontSplit.Length = 2 Then   'Has both Size & style(s)
                fontStyle = fontSplit(0)

                If Left(fontSplit(1), 4) = "size" Then
                    fontsizestr = fontSplit(1).Remove(0, 4)
                    If IsNumeric(fontsizestr) Then
                        fontsize = fontsizestr
                    End If
                End If

            ElseIf fontSplit.Length > 2 Then
                For idx = 0 To fontSplit.GetLength(0) - 2
                    fontStyle &= fontSplit(idx)
                Next

                If Left(fontSplit(fontSplit.GetLength(0) - 1), 4) = "size" Then
                    fontsizestr = fontSplit(fontSplit.GetLength(0) - 1).Remove(0, 4)
                    If IsNumeric(fontsizestr) Then
                        fontsize = fontsizestr
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Function

    Public Function getBriefDefID(ByVal jobNbr As Int32, ByVal jobComp As Int16) As Integer
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim DefID As Integer

        SQL_STRING = "SELECT DISTINCT CBDF.CRTV_BRF_DEF_ID"
        SQL_STRING &= " FROM CRTV_BRF_DEF CBDF "
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_DEF_ID = CBDF.CRTV_BRF_DEF_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL1_ID = CB1.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL2_ID = CB2.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_DTL CBD ON CBD.CRTV_BRF_LVL3_ID = CB3.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " And CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getBriefDefID", Err.Description)
        Finally

        End Try

        DefID = 0
        If dr.HasRows Then
            dr.Read()
            DefID = dr.GetInt32(0)
        End If

        Return DefID

    End Function

    Public Function getLevel1Data(ByVal jobNbr As Int32, ByVal jobComp As Int16) As SqlDataReader
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT CB1.LVL1_ORDER, ISNULL(CB1.CRTV_BRF_LVL1_DESC,''), CB1.CRTV_BRF_LVL1_ID "
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD "
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= " GROUP BY CB1.LVL1_ORDER, CB1.CRTV_BRF_LVL1_DESC, CB1.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " ORDER BY CB1.LVL1_ORDER"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dr

    End Function

    Public Function getLevel2Data(ByVal Level1ID As String, ByVal jobNbr As Int32, ByVal jobComp As Int16) As SqlDataReader

        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT CB2.LVL2_ORDER, ISNULL(CB2.CRTV_BRF_LVL2_DESC,''), CB2.CRTV_BRF_LVL2_ID "
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= "   AND CB2.CRTV_BRF_LVL1_ID = " & Level1ID
        SQL_STRING &= " GROUP BY CB2.LVL2_ORDER, CB2.CRTV_BRF_LVL2_DESC, CB2.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " ORDER BY CB2.LVL2_ORDER"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dr

    End Function

    Public Function getLevel3Data(ByVal Level2ID As String, ByVal jobNbr As Int32, ByVal jobComp As Int16) As SqlDataReader

        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT CB3.LVL3_ORDER, ISNULL(CB3.CRTV_BRF_LVL3_DESC,''), CB3.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= "   AND CB3.CRTV_BRF_LVL2_ID = " & Level2ID
        SQL_STRING &= " GROUP BY CB3.LVL3_ORDER, CB3.CRTV_BRF_LVL3_DESC, CB3.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " ORDER BY CB3.LVL3_ORDER"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dr

    End Function

    Public Function getDetailData(ByVal Level3ID As String, ByVal jobNbr As Int32, ByVal jobComp As Int16) As SqlDataReader
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT CBD.CRTV_BRF_DTL_ID, ISNULL(CBD.CRTV_BRF_DTL_DESC,'')"
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= "   AND CBD.CRTV_BRF_LVL3_ID = " & Level3ID
        SQL_STRING &= " ORDER BY CBD.DTL_ORDER"

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dr

    End Function

    Public Function getTemplateData(ByVal jobNbr As Integer, ByVal jobCompNbr As Int16) As DataTable
        Dim cb As New cCreativeBrief(mConnString, mUserID)
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4 As SqlDataReader
        Dim dt As DataTable
        Dim row As System.Data.DataRow

        Dim colDesc As DataColumn = New DataColumn("Desc")
        colDesc.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(colDesc)

        cb.getfontInfo(jobNbr, jobCompNbr, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
        'cb.getfontInfo(jobNbr, jobCompNbr, 2, fontsz2, fontStyle2)
        'cb.getfontInfo(jobNbr, jobCompNbr, 3, fontsz3, fontStyle3)
        'cb.getfontInfo(jobNbr, jobCompNbr, 4, fontsz4, fontStyle4)

        Dim desc1, desc2, desc3, desc4 As String
        Dim ID1, ID2, ID3, ID4 As Int16
        Dim szLen, szHt As Integer
        Dim yVal As Integer = 0

        dr1 = cb.getLevel1Data(jobNbr, jobCompNbr)
        Do While dr1.Read
            dt.Rows.Add(row)
            row = dt.NewRow
            desc1 = dr1.GetString(1)
            row.Item("Desc") = desc1
            'desc1 = dr1.GetString(1)
            ID1 = dr1.GetInt16(2)

            dr2 = cb.getLevel2Data(CStr(ID1), jobNbr, jobCompNbr)
            Do While dr2.Read
                dt.Rows.Add(row)
                row = dt.NewRow
                desc2 = dr2.GetString(1)
                row.Item("Desc") = desc2
                ID2 = dr2.GetInt16(2)

                dr3 = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)
                Do While dr3.Read
                    dt.Rows.Add(row)
                    row = dt.NewRow
                    desc3 = dr3.GetString(1)
                    row.Item("Desc") = desc3
                    ID3 = dr3.GetInt16(2)

                    dr4 = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)
                    Do While dr4.Read
                        dt.Rows.Add(row)
                        row = dt.NewRow
                        desc4 = dr4.GetString(1)
                        row.Item("Desc") = desc4
                        ID4 = dr4.GetInt32(0)

                    Loop
                Loop
            Loop
        Loop
        Return dt

    End Function

    Public Function BuildTemplateHTML(ByVal JobNum As Int32, ByVal JobCompNum As Int16) As String
        Dim strXMLData, XMLString As String
        Dim sbXMLData As StringBuilder = New StringBuilder
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4 As SqlDataReader

        XMLString = HTMLOpen

        getfontInfo(JobNum, JobCompNum, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
        'getfontInfo(JobNum, JobCompNum, 2, fontsz2, fontStyle2)
        'getfontInfo(JobNum, JobCompNum, 3, fontsz3, fontStyle3)
        'getfontInfo(JobNum, JobCompNum, 4, fontsz4, fontStyle4)

        'Build level 1 tags
        Select Case fontStyle1
            Case "italic"
                begin1 = "<tr><td> <FONT style=""font-size:" & fontsz1 & """> <I> "
                'begin1 &= "&nbsp;&nbsp; <I>"
                end1 = "</I> <br /></td></tr>"

            Case "underline"
                begin1 = "<tr><td> <FONT style=""font-size:" & fontsz1 & """> <U> "
                'begin1 &= "&nbsp;&nbsp; <U> "
                end1 = "</U> <br /></td></tr>"

            Case "bold"
                begin1 = "<tr><td> <FONT style=""font-size:" & fontsz1 & """> <B> "
                'begin1 &= "&nbsp;&nbsp; <B>"
                end1 = "</B> <br /></td></tr>"

            Case "bullit"
                begin1 = "<tr><td> <FONT style=""font-size:" & fontsz1 & """> <UL><LI> "
                'begin1 &= "&nbsp;&nbsp; <UL><LI> "
                end1 = "</UL></LI> <br /></td></tr>"

            Case ""
                begin1 = "<tr><td> <FONT style=""font-size:" & fontsz1 & """>"
                'begin1 &= "&nbsp;&nbsp; "
                end1 = "<br /></td></tr>"

        End Select

        'Build level 2 tags
        Select Case fontStyle2
            Case "italic"
                begin2 = "<tr><td> <FONT style=""font-size:" & fontsz2 & """> "
                begin2 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <I>"
                end2 = "</I> <br /></td></tr>"

            Case "underline"
                begin2 = "<tr><td> <FONT style=""font-size:" & fontsz2 & """> "
                begin2 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <U> "
                end2 = "</U> <br /></td></tr>"

            Case "bold"
                begin2 = "<tr><td> <FONT style=""font-size:" & fontsz2 & """> "
                begin2 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <B>"
                end2 = "</B> <br /></td></tr>"

            Case "bullit"
                begin2 = "<tr><td> <FONT style=""font-size:" & fontsz2 & """> "
                begin2 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <UL><LI> "
                end2 = "</UL></LI> <br /></td></tr>"

            Case ""
                begin2 = "<tr><td> <FONT style=""font-size:" & fontsz2 & """> "
                end2 = "<br /></td></tr>"
        End Select

        'Build level 3 tags
        Select Case fontStyle3
            Case "italic"
                begin3 = "<tr><td> <FONT style=""font-size:" & fontsz3 & """> "
                begin3 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <I>"
                end3 = "</I> <br /></td></tr>"

            Case "underline"
                begin3 = "<tr><td> <FONT style=""font-size:" & fontsz3 & """> "
                'begin3 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <U> "
                'end3 = "</U> <br /></td></tr>"
                end3 = "<br /></td></tr>"

            Case "bold"
                begin3 = "<tr><td> <FONT style=""font-size:" & fontsz3 & """> "
                begin3 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <B>"
                end3 = "</B> <br /></td></tr>"

            Case "bullit"
                begin3 = "<tr><td> <FONT style=""font-size:" & fontsz3 & """> "
                begin3 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <UL><LI> "
                end3 = "</UL></LI> <br /></td></tr>"

            Case ""
                begin3 = "<tr><td> <FONT style=""font-size:" & fontsz3 & """>"
                begin3 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "
                end3 = "<br /></td></tr>"
        End Select


        'Build detail level tags
        Select Case fontStyle4
            Case "italic"
                begin4 = "<tr><td> <FONT style=""font-size:" & fontsz4 & """>"
                begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <I>"
                end4 = "</I> <br /></td></tr>"

            Case "underline"
                begin4 = "<tr><td> <FONT style=""font-size:" & fontsz4 & """> "
                begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <U> "
                end4 = "</U> <br /></td></tr>"

            Case "bold"
                begin4 = "<tr><td> <FONT style=""font-size:" & fontsz4 & """> "
                begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <B>"
                end4 = "</B> <br /></td></tr>"

            Case "bullit"
                begin4 = "<tr><td> <FONT style=""font-size:" & fontsz4 & """> "
                begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <UL><LI> "
                end4 = "</UL></LI> <br /></td></tr>"

            Case ""
                begin4 = "<tr><td> <FONT style=""font-size:" & fontsz4 & """>"
                'begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "
                end4 = "<br /></td></tr>"
        End Select

        Dim desc1, desc2, desc3, desc4 As String
        Dim ID1, ID2, ID3, ID4 As Int16
        Dim szLen, szHt As Integer

        XMLString &= OpenSpacerTable

        dr1 = getLevel1Data(JobNum, JobCompNum)
        Do While dr1.Read
            desc1 = dr1.GetString(1)
            ID1 = dr1.GetInt16(2)

            XMLString &= begin1
            XMLString &= desc1
            XMLString &= end1

            dr2 = getLevel2Data(CStr(ID1), JobNum, JobCompNum)
            Do While dr2.Read
                desc2 = dr2.GetString(1)
                ID2 = dr2.GetInt16(2)

                XMLString &= begin2
                XMLString &= desc2
                XMLString &= end2

                dr3 = getLevel3Data(CStr(ID2), JobNum, JobCompNum)
                Do While dr3.Read
                    desc3 = dr3.GetString(1)
                    ID3 = dr3.GetInt16(2)

                    XMLString &= begin3
                    XMLString &= desc3
                    XMLString &= end3

                    dr4 = getDetailData(CStr(ID3), JobNum, JobCompNum)
                    Do While dr4.Read
                        Dim myTextbox As New System.Web.UI.WebControls.TextBox

                        desc4 = dr4.GetString(1)

                        XMLString &= begin4
                        XMLString &= desc4
                        XMLString &= end4

                    Loop
                Loop
            Loop
        Loop
        XMLString &= CloseSpacerTable
        XMLString &= HTMLClose

        Return XMLString
    End Function

    Public Function BuildTemplateRTF(ByVal JobNum As Int32, ByVal JobCompNum As Int16) As String
        Dim strXMLData, XMLString As String
        Dim sbXMLData As StringBuilder = New StringBuilder
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4 As SqlDataReader

        '"{\rtf1\ansi\ansicpg1252\deff0{\fonttbl{\f0\fnil\fcharset0 MS Sans Serif;}}\viewkind4\uc1\pard\lang1033\f0\fs17 Rich Text\par }"

        XMLString = HTMLOpen
        getfontInfo(JobNum, JobCompNum, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
        'getfontInfo(JobNum, JobCompNum, 2, fontsz2, fontStyle2)
        'getfontInfo(JobNum, JobCompNum, 3, fontsz3, fontStyle3)
        'getfontInfo(JobNum, JobCompNum, 4, fontsz4, fontStyle4)

        'Build level 1 tags
        Select Case fontStyle1
            Case "italic"
                'begin1 = "<tr><td align=""left""  style=""font-style:italic; text-indent:5px; font-size:""" & fontsz1 & """ >"
                begin1 = "<tr><td align=""left""> <font size=""" & fontsz1 & """> <I>"
                end1 = "</I> <br /></td></tr>"

            Case "underline"
                'begin1 = "<tr><td align=""left""  style=""text-indent:5px; font-size:""" & fontsz1 & """ > <u>"
                begin1 = "<tr><td align=""left""> <font size=""" & fontsz1 & """> <U>"
                end1 = "</U> <br /></td></tr>"

            Case "bold"
                'begin1 = "<tr><td align=""left""  style=""font-weight:bold; text-indent:5px; font-size:""" & fontsz1 & """ >"
                begin1 = "<tr><td align=""left""> <font size=""" & fontsz1 & """> <B>"
                end1 = "</B> <br /></td></tr>"

            Case "bullit"
                'begin1 = "<tr><td align=""left""  style=""display:list-item; text-indent:5px; font-size:""" & fontsz1 & """ > <li>"
                begin1 = "<tr><td align=""left""> <font size=""" & fontsz1 & """> <UL><LI>"
                end1 = "</UL></LI> <br /></td></tr>"

            Case ""
                'begin1 = "<tr><td align=""left""  style=""text-indent:5px; font-size:""" & fontsz1 & """ >"
                begin1 = "<tr><td align=""left""> <font size=""" & fontsz1 & """ >"
                end1 = "<br /></td></tr>"

        End Select

        'Build level 2 tags
        Select Case fontStyle2
            Case "italic"
                'begin2 = "<tr><td align=""left"" class=""MainContentCell"" style=""font-style:italic; text-indent:20px; font-size:""" & fontsz2 & """ >"
                begin2 = "<tr><td align=""left""> <font size=""" & fontsz2 & """> <I>"
                end2 = "</I> <br /></td></tr>"

            Case "underline"
                'begin2 = "<tr><td align=""left"" class=""MainContentCell"" style=""text-indent:20px; font-size:""" & fontsz2 & """ > <u>"
                begin2 = "<tr><td align=""left""> <font size=""" & fontsz2 & """> <U>"
                end2 = "</U> <br /></td></tr>"

            Case "bold"
                'begin2 = "<tr><td align=""left"" class=""MainContentCell"" style=""font-weight:bold; text-indent:20px; font-size:""" & fontsz2 & """ >"
                begin2 = "<tr><td align=""left""> <font size=""" & fontsz2 & """> <B>"
                end2 = "</B> <br /></td></tr>"

            Case "bullit"
                'begin2 = "<tr><td align=""left"" class=""MainContentCell"" style=""display:list-item; text-indent:20px; font-size:""" & fontsz2 & """ > <li>"
                begin2 = "<tr><td align=""left""> <font size=""" & fontsz2 & """> <UL><LI>"
                end2 = "</UL></LI> <br /></td></tr>"

            Case ""
                'begin2 = "<tr><td align=""left"" class=""MainContentCell"" style=""text-indent:20px; font-size:""" & fontsz2 & """ >"
                begin2 = "<tr><td align=""left""> <font size=""" & fontsz2 & """ >"
                end2 = "<br /></td></tr>"
        End Select

        'Build level 3 tags
        Select Case fontStyle3
            Case "italic"
                'begin3 = "<tr><td align=""left"" class=""MainContentCell"" style=""font-style:italic; text-indent:35px; font-size:""" & fontsz3 & """ >"
                begin3 = "<tr><td align=""left""> <font size=""" & fontsz3 & """> <I>"
                end3 = "</I> <br /></td></tr>"

            Case "underline"
                'begin3 = "<tr><td align=""left"" class=""MainContentCell"" style=""text-indent:35px; font-size:" & fontsz3 & """ > <u>"
                begin3 = "<tr><td align=""left""> <font size=""" & fontsz3 & """> <U>"
                end3 = "</U> <br /></td></tr>"

            Case "bold"
                'begin3 = "<tr><td align=""left"" class=""MainContentCell"" style=""font-weight:bold; text-indent:35px; font-size:""" & fontsz3 & " >"
                begin3 = "<tr><td align=""left""> <font size=""" & fontsz3 & """> <B>"
                end3 = "</B> <br /></td></tr>"

            Case "bullit"
                'begin3 = "<tr><td align=""left"" class=""MainContentCell"" style=""display:list-item; text-indent:35px; font-size:""" & fontsz3 & " > <li>"
                begin3 = "<tr><td align=""left""> <font size=""" & fontsz3 & """> <UL><LI>"
                end3 = "</UL></LI> <br /></td></tr>"

            Case ""
                'begin3 = "<tr><td align=""left"" class=""MainContentCell"" style=""text-indent:35px; font-size:" & fontsz3 & """ >"
                begin3 = "<tr><td align=""left""> <font size=""" & fontsz3 & """ >"
                end3 = "<br /></td></tr>"
        End Select


        'Build detail level tags
        Select Case fontStyle4
            Case "italic"
                'begin4 = "<tr><td align=""left"" class=""MainContentCell"" > "
                'begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "
                begin4 = "<tr><td align=""left""> <font size=""" & fontsz4 & """> <I>"
                end4 = "</I> <br /></td></tr>"

            Case "underline"
                'begin4 = "<tr><td align=""left"" class=""MainContentCell"" > "
                'begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <u> "
                begin4 = "<tr><td align=""left""> <font size=""" & fontsz4 & """> <U>"
                end4 = "</U> <br /></td></tr>"

            Case "bold"
                'begin4 = "<tr><td align=""left"" class=""MainContentCell"" > "
                'begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "
                begin4 = "<tr><td align=""left""> <font size=""" & fontsz4 & """> <B>"
                end4 = "</B> <br /></td></tr>"

            Case "bullit"
                'begin4 = "<tr><td align=""left"" class=""MainContentCell"" > "
                'begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <li> "
                begin4 = "<tr><td align=""left""> <font size=""" & fontsz4 & """> <UL><LI>"
                end4 = "</UL></LI> <br /></td></tr>"

            Case ""
                'begin4 = "<tr><td align=""left"" class=""MainContentCell"" > "
                'begin4 &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "
                begin4 = "<tr><td align=""left""> <font size=""" & fontsz4 & """ >"
                end4 = "<br /></td></tr>"
        End Select

        Dim desc1, desc2, desc3, desc4 As String
        Dim ID1, ID2, ID3, ID4 As Int16
        Dim szLen, szHt As Integer

        XMLString &= OpenSpacerTable
        'Panel1.Controls.Add(MiscFN.NewLiteral(OpenSpacerTable))
        dr1 = getLevel1Data(JobNum, JobCompNum)
        Do While dr1.Read
            desc1 = dr1.GetString(1)
            ID1 = dr1.GetInt16(2)

            XMLString &= begin1
            XMLString &= desc1
            XMLString &= end1
            'Panel1.Controls.Add(MiscFN.NewLiteral(begin1))
            'Panel1.Controls.Add(MiscFN.NewLiteral(desc1))
            'Panel1.Controls.Add(MiscFN.NewLiteral(end1))

            dr2 = getLevel2Data(CStr(ID1), JobNum, JobCompNum)
            Do While dr2.Read
                desc2 = dr2.GetString(1)
                ID2 = dr2.GetInt16(2)

                XMLString &= begin2
                XMLString &= desc2
                XMLString &= end2
                'Panel1.Controls.Add(MiscFN.NewLiteral(begin2))
                'Panel1.Controls.Add(MiscFN.NewLiteral(desc2))
                'Panel1.Controls.Add(MiscFN.NewLiteral(end2))

                dr3 = getLevel3Data(CStr(ID2), JobNum, JobCompNum)
                Do While dr3.Read
                    desc3 = dr3.GetString(1)
                    ID3 = dr3.GetInt16(2)

                    XMLString &= begin3
                    XMLString &= desc3
                    XMLString &= end3
                    'Panel1.Controls.Add(MiscFN.NewLiteral(begin3))
                    'Panel1.Controls.Add(MiscFN.NewLiteral(desc3))
                    'Panel1.Controls.Add(MiscFN.NewLiteral(end3))

                    dr4 = getDetailData(CStr(ID3), JobNum, JobCompNum)
                    Do While dr4.Read
                        Dim myTextbox As New System.Web.UI.WebControls.TextBox

                        desc4 = dr4.GetString(1)
                        ID4 = dr4.GetInt32(0)
                        szLen = desc4.Length

                        XMLString &= begin4
                        XMLString &= desc4
                        XMLString &= end4
                        'Panel1.Controls.Add(MiscFN.NewLiteral(begin4))
                        'Panel1.Controls.Add(MiscFN.NewLiteral(desc4))
                        'Panel1.Controls.Add(MiscFN.NewLiteral(end4))

                    Loop
                Loop
            Loop
        Loop
        XMLString &= CloseSpacerTable
        XMLString &= HTMLClose
        'Panel1.Controls.Add(MiscFN.NewLiteral(CloseSpacerTable))

        Return XMLString
    End Function

    Public Function isApprovedVersion(ByVal jobNbr As Int32, ByVal jobComp As Int16) As Boolean
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim count As Int16

        SQL_STRING = "SELECT COUNT(*) FROM CRTV_BRF_APPR "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(jobNbr) & " AND JOB_COMPONENT_NBR = " & CStr(jobComp)

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        dr.Read()
        count = dr.GetInt32(0)
        If count > 0 Then
            Return True
        End If
        Return False

    End Function

    Public Function getLevel1DataTable(ByVal jobNbr As Int32, ByVal jobComp As Int16) As DataTable
        Dim SQL_STRING As String
        Dim dt As DataTable

        SQL_STRING = "SELECT CB1.LVL1_ORDER, ISNULL(CB1.CRTV_BRF_LVL1_DESC,''), CB1.CRTV_BRF_LVL1_ID "
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD "
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= " GROUP BY CB1.LVL1_ORDER, CB1.CRTV_BRF_LVL1_DESC, CB1.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " ORDER BY CB1.LVL1_ORDER"

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dt

    End Function

    Public Function getLevel2DataTable(ByVal Level1ID As String, ByVal jobNbr As Int32, ByVal jobComp As Int16) As DataTable

        Dim SQL_STRING As String
        Dim dt As DataTable

        SQL_STRING = "SELECT CB2.LVL2_ORDER, ISNULL(CB2.CRTV_BRF_LVL2_DESC,''), CB2.CRTV_BRF_LVL2_ID "
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= "   AND CB2.CRTV_BRF_LVL1_ID = " & Level1ID
        SQL_STRING &= " GROUP BY CB2.LVL2_ORDER, CB2.CRTV_BRF_LVL2_DESC, CB2.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " ORDER BY CB2.LVL2_ORDER"

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dt

    End Function

    Public Function getLevel3DataTable(ByVal Level2ID As String, ByVal jobNbr As Int32, ByVal jobComp As Int16) As DataTable

        Dim SQL_STRING As String
        Dim dt As DataTable

        SQL_STRING = "SELECT CB3.LVL3_ORDER, ISNULL(CB3.CRTV_BRF_LVL3_DESC,''), CB3.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= "   AND CB3.CRTV_BRF_LVL2_ID = " & Level2ID
        SQL_STRING &= " GROUP BY CB3.LVL3_ORDER, CB3.CRTV_BRF_LVL3_DESC, CB3.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " ORDER BY CB3.LVL3_ORDER"

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dt

    End Function

    Public Function getDetailDataTable(ByVal Level3ID As String, ByVal jobNbr As Int32, ByVal jobComp As Int16) As DataTable
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dt As DataTable

        SQL_STRING = "SELECT CBD.CRTV_BRF_DTL_ID, ISNULL(CBD.CRTV_BRF_DTL_DESC,'')"
        SQL_STRING &= " FROM CRTV_BRF_DTL CBD"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID"
        SQL_STRING &= " INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID"
        SQL_STRING &= " WHERE CBD.JOB_NUMBER = " & CStr(jobNbr) & " AND CBD.JOB_COMPONENT_NBR = " & CStr(jobComp)
        SQL_STRING &= "   AND CBD.CRTV_BRF_LVL3_ID = " & Level3ID
        SQL_STRING &= " ORDER BY CBD.DTL_ORDER"

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.Text, SQL_STRING, "dt")
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        Return dt

    End Function

End Class
