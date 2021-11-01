Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports Webvantage
Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class arptCBHeader1
    Public dtData As DataTable
    Public description As String
    Public version As String
    Public client As String
    Public division As String
    Public product As String
    Public cl_code, div_code, prd_code As String
    Public job, jobDesc As String
    Public jobcomp, compDesc As String
    Public jobNbr As Integer
    Public jobCompNbr As Int16
    Public imgPath As String
    Public ReportTitle As String
    Public Reporter As String
    Public LogoPath As String
    Public LogoPlacement As Integer
    Public LogoID As String
    Public dtAgency As DataTable
    Public RTBText As String
    Public fld As New Field
    Public mConnectionString As String
    Public UserCode As String

    Public CLIENT_REF, ACCT_EXEC, TEAM, CAMPAIGN_CODE, CAMPAIGN_NAME, OPENED_BY, CDP_ADDR, CDP_ADDR2, CDP_ADDR3 As String
    Public BUDGET As Decimal
    Public JOB_DATE_OPENED, JOB_FIRST_USE_DATE, JOB_COMP_DATE As Date
    Public JOB_ESTIMATE_REQ, JOB_RUSH_CHARGES As Int16
    Public CAMPAIGN_ID As Integer

    Public SHOW_CLIENT, SHOW_CLIENT_REF, SHOW_DIVISION, SHOW_PRODUCT, SHOW_CL_ADDRESS, SHOW_DIV_ADDRESS, SHOW_PRD_ADDRESS As Int16
    Public SHOW_JOB_NUMBER, SHOW_JOB_DESC, SHOW_JOB_COMP_NBR, SHOW_JOB_COMP_DESC, SHOW_ACCT_EXEC, SHOW_BUDGET As Int16
    Public SHOW_TEAM, SHOW_DATE_OPENED, SHOW_CAMPAIGN, SHOW_APPRV_EST_REQ, SHOW_RUSH_CHGS_OK, SHOW_DUE_DATE, SHOW_OPENED_BY As Int16

    Public CultureCode As String = "en-US"
    Private Sub arptCBHeader1_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        setCBOptions()
    End Sub

    Public Sub setCBOptions()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim count As Int16
        Dim BriefDefID As Integer
        Dim cb As New cCreativeBrief(mConnectionString, UserCode)

        'Get default report header data
        BriefDefID = cb.getBriefDefID(jobNbr, jobCompNbr)

        SQL_STRING = "SELECT ISNULL(SHOW_CLIENT,0), ISNULL(SHOW_CLIENT_REF,0), ISNULL(SHOW_DIVISION,0), ISNULL(SHOW_PRODUCT,0), ISNULL(SHOW_CL_ADDRESS,0), ISNULL(SHOW_DIV_ADDRESS,0),"
        SQL_STRING &= " ISNULL(SHOW_PRD_ADDRESS,0), ISNULL(SHOW_JOB_NUMBER,0), ISNULL(SHOW_JOB_DESC,0), ISNULL(SHOW_JOB_COMP_NBR,0), ISNULL(SHOW_JOB_COMP_DESC,0), ISNULL(SHOW_ACCT_EXEC,0), ISNULL(SHOW_BUDGET,0),"
        SQL_STRING &= " ISNULL(SHOW_TEAM,0), ISNULL(SHOW_DATE_OPENED,0), ISNULL(SHOW_CAMPAIGN,0), ISNULL(SHOW_APPRV_EST_REQ,0), ISNULL(SHOW_RUSH_CHGS_OK,0), ISNULL(SHOW_DUE_DATE,0), ISNULL(SHOW_OPENED_BY,0)"
        SQL_STRING &= " FROM CRTV_BRF_DEF"
        SQL_STRING &= " WHERE CRTV_BRF_DEF_ID = " & CStr(BriefDefID)

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            SHOW_CLIENT = dr.GetInt16(0)
            SHOW_CLIENT_REF = dr.GetInt16(1)
            SHOW_DIVISION = dr.GetInt16(2)
            SHOW_PRODUCT = dr.GetInt16(3)
            SHOW_CL_ADDRESS = dr.GetInt16(4)
            SHOW_DIV_ADDRESS = dr.GetInt16(5)
            SHOW_PRD_ADDRESS = dr.GetInt16(6)
            SHOW_JOB_NUMBER = dr.GetInt16(7)
            SHOW_JOB_DESC = dr.GetInt16(8)
            SHOW_JOB_COMP_NBR = dr.GetInt16(9)
            SHOW_JOB_COMP_DESC = dr.GetInt16(10)
            SHOW_ACCT_EXEC = dr.GetInt16(11)
            SHOW_BUDGET = dr.GetInt16(12)
            SHOW_TEAM = dr.GetInt16(13)
            SHOW_DATE_OPENED = dr.GetInt16(14)
            SHOW_CAMPAIGN = dr.GetInt16(15)
            SHOW_APPRV_EST_REQ = dr.GetInt16(16)
            SHOW_RUSH_CHGS_OK = dr.GetInt16(17)
            SHOW_DUE_DATE = dr.GetInt16(18)
            SHOW_OPENED_BY = dr.GetInt16(19)
        End If
        dr.Close()


        If SHOW_CLIENT = 1 Then
            Me.txtClient.Text = client
            Me.lblClient.Visible = True
            Me.txtClient.Visible = True
        Else
            Me.lblClient.Visible = False
            Me.txtClient.Visible = False
        End If
        If SHOW_DIVISION = 1 Then
            Me.txtDivision.Text = division
            Me.lblDivision.Visible = True
            Me.txtDivision.Visible = True
        Else
            Me.lblDivision.Visible = False
            Me.txtDivision.Visible = False
        End If
        If SHOW_PRODUCT = 1 Then
            Me.txtProduct.Text = product
            Me.lblProduct.Visible = True
            Me.txtProduct.Visible = True
        Else
            Me.lblProduct.Visible = False
            Me.txtProduct.Visible = False
        End If

        If SHOW_JOB_NUMBER = 1 Then
            job = job
        Else
            job = ""
        End If
        If SHOW_JOB_DESC = 1 Then
            If job = "" Then
                job &= jobDesc
            Else
                job &= " - " & jobDesc
            End If
        End If

        If SHOW_JOB_NUMBER = 1 Or SHOW_JOB_DESC = 1 Then
            Me.txtJob.Visible = True
            Me.lblJob.Visible = True
            Me.txtJob.Text = job
        Else
            Me.txtJob.Visible = False
            Me.lblJob.Visible = False
        End If

        If SHOW_JOB_COMP_NBR = 1 Then
            jobcomp = jobcomp
        Else
            jobcomp = ""
        End If
        If SHOW_JOB_COMP_DESC = 1 Then
            If jobcomp = "" Then
                jobcomp &= compDesc
            Else
                jobcomp &= " - " & compDesc
            End If
        End If
        If SHOW_JOB_COMP_NBR = 1 Or SHOW_JOB_COMP_DESC = 1 Then
            Me.txtComponent.Visible = True
            Me.lblComponent.Visible = True
            Me.txtComponent.Text = jobcomp
        Else
            Me.txtComponent.Visible = False
            Me.lblComponent.Visible = False
        End If



        'Get Job data
        SQL_STRING = " SELECT ISNULL(JOB_LOG.CMP_CODE,''), ISNULL(JOB_LOG.CMP_IDENTIFIER,0), ISNULL(JOB_LOG.JOB_DATE_OPENED,''), ISNULL(JOB_LOG.USER_ID,''), ISNULL(JOB_LOG.JOB_ESTIMATE_REQ,0), ISNULL(JOB_LOG.JOB_RUSH_CHARGES,0), ISNULL(JOB_LOG.JOB_CLI_REF,'') "
        SQL_STRING &= " FROM JOB_LOG WHERE JOB_LOG.JOB_NUMBER = " & CStr(jobNbr)

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            CAMPAIGN_CODE = dr.GetString(0)
            CAMPAIGN_ID = dr.GetInt32(1)
            JOB_DATE_OPENED = dr.GetDateTime(2) 'don't use this one, use component
            OPENED_BY = dr.GetString(3)         'don't use this one, use component
            JOB_ESTIMATE_REQ = dr.GetInt16(4)
            JOB_RUSH_CHARGES = dr.GetInt16(5)
            CLIENT_REF = dr.GetString(6)
        End If
        dr.Close()

        If JOB_ESTIMATE_REQ = 0 Then
            SHOW_APPRV_EST_REQ = 0
        End If
        If JOB_RUSH_CHARGES = 0 Then
            SHOW_RUSH_CHGS_OK = 0
        End If
        If CLIENT_REF = "" Then
            SHOW_CLIENT_REF = 0
        End If


        If SHOW_CLIENT_REF = 1 Then
            Me.txtCliRef.Visible = True
            Me.lblCliRef.Visible = True
            Me.txtCliRef.Text = CLIENT_REF
        Else
            Me.txtCliRef.Visible = False
            Me.lblCliRef.Visible = False
        End If


        'Job Component Data
        SQL_STRING = " SELECT dbo.udf_get_empl_name(EMP_CODE, 'FML'), ISNULL(DP_TM_CODE,''), ISNULL(JOB_COMP_BUDGET_AM,0), JOB_FIRST_USE_DATE, JOB_COMP_DATE  "
        SQL_STRING &= " FROM JOB_COMPONENT "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(jobNbr) & " AND JOB_COMPONENT_NBR = " & CStr(jobCompNbr)

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            OPENED_BY = dr.GetString(0)
            TEAM = dr.GetString(1)
            BUDGET = dr.GetDecimal(2)

            If Not IsDBNull(dr.GetValue(3)) Then
                JOB_FIRST_USE_DATE = dr.GetDateTime(3)
            Else
                SHOW_DUE_DATE = 0
            End If

            If Not IsDBNull(dr.GetValue(4)) Then
                JOB_COMP_DATE = dr.GetDateTime(4)
            Else
                SHOW_DATE_OPENED = 0
            End If

        End If
        dr.Close()

        If OPENED_BY = "" Then
            SHOW_OPENED_BY = 0
        End If
        If TEAM = "" Then
            SHOW_TEAM = 0
        End If
        If BUDGET = 0 Then
            SHOW_BUDGET = 0
        End If


        If SHOW_TEAM = 1 Then
            Me.txtDeptTeam.Visible = True
            Me.lblDeptTeam.Visible = True
            Me.txtDeptTeam.Text = TEAM
        Else
            Me.txtDeptTeam.Visible = False
            Me.lblDeptTeam.Visible = False
        End If


        'TEAM
        If TEAM = "" Then
            SHOW_TEAM = 0
        End If
        If SHOW_TEAM = 1 Then
            SQL_STRING = " Select ISNULL(DP_TM_DESC,'') FROM DEPT_TEAM WHERE DP_TM_CODE = '" & TEAM & "'"

            Try
                dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                TEAM = dr.GetString(0)
            End If
            If TEAM = "" Then
                SHOW_TEAM = 0
            End If
        End If
        dr.Close()

        If SHOW_TEAM = 1 Then
            Me.txtDeptTeam.Visible = True
            Me.lblDeptTeam.Visible = True
            Me.txtDeptTeam.Text = TEAM
        Else
            Me.txtDeptTeam.Visible = False
            Me.lblDeptTeam.Visible = False
        End If

        'Campaign
        CAMPAIGN_NAME = ""
        If CAMPAIGN_ID = 0 Then
            SHOW_CAMPAIGN = 0
        End If
        If SHOW_CAMPAIGN = 1 Then
            SQL_STRING = " Select CMP_NAME FROM CAMPAIGN WHERE CMP_IDENTIFIER = " & CStr(CAMPAIGN_ID)

            Try
                dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                CAMPAIGN_NAME = dr.GetString(0)
            End If
        End If
        If CAMPAIGN_NAME = "" Then
            SHOW_CAMPAIGN = 0
        End If
        dr.Close()

        If SHOW_CAMPAIGN = 1 Then
            Me.txtCampaign.Visible = True
            Me.lblCampaign.Visible = True
            Me.txtCampaign.Text = CAMPAIGN_NAME
        Else
            Me.txtCampaign.Visible = False
            Me.lblCampaign.Visible = False
        End If

        'Account Executive
        ACCT_EXEC = ""
        If SHOW_ACCT_EXEC = 1 Then
            'SQL_STRING = " SELECT dbo.udf_get_empl_name(EMP_CODE, 'FML')"
            'SQL_STRING &= " FROM ACCOUNT_EXECUTIVE "
            'SQL_STRING &= " WHERE CL_CODE = '" & cl_code & "' AND DIV_CODE = '" & div_code & "' AND PRD_CODE = '" & prd_code & "'"
            'SQL_STRING &= " AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL) "
            'SQL_STRING &= " AND DEFAULT_AE = 1"

            'Try
            '    dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            'Catch
            '    Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            'Finally
            'End Try

            SQL_STRING = " SELECT dbo.udf_get_empl_name(EMP_CODE, 'FML')"
            SQL_STRING &= " FROM JOB_COMPONENT "
            SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(jobNbr) & " AND JOB_COMPONENT_NBR = " & CStr(jobCompNbr)

            Try
                dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                ACCT_EXEC = dr.GetString(0)
            End If
        End If
        If ACCT_EXEC = "" Then
            SHOW_ACCT_EXEC = 0
        End If
        dr.Close()

        If SHOW_ACCT_EXEC = 1 Then
            Me.txtAcctExec.Visible = True
            Me.lblAcctExec.Visible = True
            Me.txtAcctExec.Text = ACCT_EXEC
        Else
            Me.txtAcctExec.Visible = False
            Me.lblAcctExec.Visible = False
        End If

    End Sub


   
End Class
