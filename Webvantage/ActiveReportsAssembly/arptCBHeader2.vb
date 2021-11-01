Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports Webvantage
Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class arptCBHeader2
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

    Public CLIENT_REF, ACCT_EXEC, TEAM, CAMPAIGN_CODE, CAMPAIGN_NAME, OPENED_BY, CDP_ADDR, CDP_CSZ, CDP_ADDR2, CDP_ADDR3 As String
    Public BUDGET As Decimal
    Public JOB_DATE_OPENED, JOB_FIRST_USE_DATE, JOB_COMP_DATE As Date
    Public JOB_ESTIMATE_REQ, JOB_RUSH_CHARGES As Int16
    Public CAMPAIGN_ID As Integer

    Public SHOW_CLIENT, SHOW_CLIENT_REF, SHOW_DIVISION, SHOW_PRODUCT, SHOW_CL_ADDRESS, SHOW_DIV_ADDRESS, SHOW_PRD_ADDRESS As Int16
    Public SHOW_JOB_NUMBER, SHOW_JOB_DESC, SHOW_JOB_COMP_NBR, SHOW_JOB_COMP_DESC, SHOW_ACCT_EXEC, SHOW_BUDGET As Int16
    Public SHOW_TEAM, SHOW_DATE_OPENED, SHOW_CAMPAIGN, SHOW_APPRV_EST_REQ, SHOW_RUSH_CHGS_OK, SHOW_DUE_DATE, SHOW_OPENED_BY As Int16
    Public CultureCode As String = "en-US"

    Private Sub arptCBHeader2_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
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


        If SHOW_APPRV_EST_REQ = 1 Then
            Me.lblApprEstReq.Visible = True
        Else
            Me.lblApprEstReq.Visible = False
        End If

        If SHOW_RUSH_CHGS_OK = 1 Then
            Me.lblRushChargesApproved.Visible = True
        Else
            Me.lblRushChargesApproved.Visible = False
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

        'Populate Report textboxes
        If SHOW_OPENED_BY = 1 Then
            Me.txtOpenedBy.Visible = True
            Me.lblOpenedBy.Visible = True
            Me.txtOpenedBy.Text = OPENED_BY
        Else
            Me.txtOpenedBy.Visible = False
            Me.lblOpenedBy.Visible = False
        End If

        If SHOW_BUDGET = 1 Then
            Me.txtBudget.Visible = True
            Me.lblBudget.Visible = True
            Me.txtBudget.Text = BUDGET
        Else
            Me.txtBudget.Visible = False
            Me.lblBudget.Visible = False
        End If

        If SHOW_DUE_DATE = 1 Then
            Me.txtDue.Visible = True
            Me.lblDue.Visible = True
            Me.txtDue.Text = JOB_FIRST_USE_DATE
        Else
            Me.txtDue.Visible = False
            Me.lblDue.Visible = False
        End If

        If SHOW_DATE_OPENED = 1 Then
            Me.txtOpened.Visible = True
            Me.lblOpened.Visible = True
            Me.txtOpened.Text = JOB_COMP_DATE
        Else
            Me.txtOpened.Visible = False
            Me.lblOpened.Visible = False
        End If


        'C/D/P Address
        Dim ls_addr1, ls_addr2, ls_city, ls_state, ls_zip As String
        SQL_STRING = "SELECT ISNULL(CL_ADDRESS1,'') FROM CLIENT WHERE 1=2 "
        If SHOW_CL_ADDRESS = 1 Then
            SQL_STRING = " SELECT ISNULL(CL_ADDRESS1,''), ISNULL(CL_ADDRESS2,''), ISNULL(CL_CITY,''), ISNULL(CL_STATE,''), ISNULL(CL_ZIP,'') "
            SQL_STRING &= "FROM CLIENT "
            SQL_STRING &= "WHERE CL_CODE = '" & cl_code & "'"
        Else
            If SHOW_DIV_ADDRESS = 1 Then
                SQL_STRING = " SELECT ISNULL(DIV_BADDRESS1,''), ISNULL(DIV_BADDRESS2,''), ISNULL(DIV_BCITY,''), ISNULL(DIV_BSTATE,''), ISNULL(DIV_BZIP,'')"
                SQL_STRING &= "FROM DIVISION "
                SQL_STRING &= "WHERE DIV_CODE = '" & div_code & "' And CL_CODE = '" & cl_code & "'"
            Else
                If SHOW_PRD_ADDRESS = 1 Then
                    SQL_STRING = " SELECT ISNULL(PRD_BILL_ADDRESS1,''), ISNULL(PRD_BILL_ADDRESS2,''), ISNULL(PRD_BILL_CITY,''), ISNULL(PRD_BILL_STATE,''), ISNULL(PRD_BILL_ZIP,'')"
                    SQL_STRING &= "FROM PRODUCT "
                    SQL_STRING &= "WHERE PRD_CODE = '" & prd_code & "' And CL_CODE = '" & cl_code & "' And DIV_CODE = '" & div_code & "'"
                End If
            End If
        End If

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            ls_addr1 = dr.GetString(0)
            ls_addr2 = dr.GetString(1)
            ls_city = dr.GetString(2)
            ls_state = dr.GetString(3)
            ls_zip = dr.GetString(4)

            CDP_ADDR = ""
            If ls_addr1 <> "" Then
                CDP_ADDR &= ls_addr1
            End If

            If ls_addr2 <> "" Then
                If ls_addr1 <> "" Then
                    CDP_ADDR &= vbCrLf & ls_addr2
                Else
                    CDP_ADDR &= ls_addr2
                End If
            End If

            CDP_CSZ = ""
            If ls_city <> "" Then
                CDP_CSZ &= ls_city
            End If

            If ls_state <> "" Then
                If CDP_CSZ <> "" Then
                    CDP_CSZ &= ", " & ls_state
                Else
                    CDP_CSZ &= ls_state
                End If
            End If

            If ls_zip <> "" Then
                If CDP_CSZ <> "" Then
                    CDP_CSZ &= "  " & ls_zip
                Else
                    CDP_CSZ &= ls_zip
                End If
            End If

            If CDP_ADDR <> "" And CDP_CSZ <> "" Then
                CDP_ADDR &= vbCrLf & CDP_CSZ
            End If


            If SHOW_CL_ADDRESS = 1 Or SHOW_DIV_ADDRESS = 1 Or SHOW_PRD_ADDRESS = 1 Then
                If CDP_ADDR = "" Then
                    SHOW_CL_ADDRESS = 0
                    SHOW_DIV_ADDRESS = 0
                    SHOW_PRD_ADDRESS = 0
                    txtAddress.Visible = False
                    'txtAddress2.Visible = False
                    'txtAddress3.Visible = False
                    lblAddress.Visible = False
                    'lblAddress2.Visible = False
                Else
                    txtAddress.Visible = True
                    'txtAddress2.Visible = True
                    'txtAddress3.Visible = True
                    lblAddress.Visible = True
                    'lblAddress2.Visible = True

                    'If ls_addr1 <> "" Then
                    txtAddress.Text = CDP_ADDR
                    'Else
                    '    txtAddress.Visible = False
                    'End If

                    'If ls_addr2 <> "" Then
                    '    If ls_addr1 <> "" Then
                    '        txtAddress2.Text = ls_addr2
                    '    Else
                    '        txtAddress.Text = ls_addr2
                    '        txtAddress.Visible = True
                    '    End If

                    'Else
                    '    txtAddress2.Visible = False
                    'End If

                    'If CDP_ADDR <> "" Then
                    '    If ls_addr2 <> "" Then
                    '        'txtAddress3.Text = CDP_ADDR
                    '    Else
                    '        'txtAddress2.Text = CDP_ADDR
                    '        'txtAddress2.Visible = True
                    '        'txtAddress3.Visible = False
                    '    End If

                    'Else
                    '    'txtAddress3.Visible = False
                    'End If

                    If SHOW_CL_ADDRESS = 1 Then
                        lblAddress.Text = "Client Address:"
                    End If
                    If SHOW_DIV_ADDRESS = 1 Then
                        lblAddress.Text = "Division Address:"
                    End If
                    If SHOW_PRD_ADDRESS = 1 Then
                        lblAddress.Text = "Product Address:"
                    End If
                End If
            End If

        Else
            CDP_ADDR = ""
            SHOW_CL_ADDRESS = 0
            SHOW_DIV_ADDRESS = 0
            SHOW_PRD_ADDRESS = 0
            txtAddress.Visible = False
            'txtAddress2.Visible = False
            'txtAddress3.Visible = False
            lblAddress.Visible = False
            'lblAddress2.Visible = False
        End If

        dr.Close()

    End Sub



End Class
