Imports System.Data.SqlClient

Partial Public Class PVTooltip2
    Inherits System.Web.UI.UserControl

    Public params(10) As String
    Public appName As String

    Public Property Job() As String
        Get
            If ViewState("Job") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("Job"), String)
        End Get
        Set(ByVal value As String)
            If Me.Job <> value Then
                Me.reset()
            End If
            ViewState("Job") = value
        End Set
    End Property

    Public Property Comp() As String
        Get
            If ViewState("Comp") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("Comp"), String)
        End Get
        Set(ByVal value As String)
            If Me.Comp <> value Then
                Me.reset()
            End If
            ViewState("Comp") = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.Page.IsCallback Then

            Select Case appName
                Case "QvA"
                    Me.LblTooltip.Text = "QvA<br/>Quote Qty/Hrs: " & params(0) & "<br/> Actual Qty/Hrs: " & params(1) & "<br/><br/>Quote Total: " & params(2) & "<br/> Actual Total: " & params(3)

                Case "Alert"
                    Me.LblTooltip.Text = "Alert<br/>Last Alert: " & params(0) & "<br/> Date/Time: " & params(1)

                Case "JobSpecs"
                    'Me.LblTooltip.Text = params(0)
                    Me.LblTooltip.Text = getJobSpecTooltipInfo()

                Case "Versions"
                    Me.LblTooltip.Text = params(0)
                    'Me.LblTooltip.Text = getVersionsTooltipInfo()

            End Select
        End If

    End Sub


    Private Function getVersionsTooltipInfo() As String
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim tooltip As String
        Dim tmpl_name, seq_nbr, JVDesc, crDate As String

        SQL_STRING = "SELECT JVH.JOB_VER_SEQ_NBR, JVH.JOB_VER_DESC, JVH.CREATE_DATE, JVTH.JV_TMPLT_DESC "
        SQL_STRING &= " FROM JOB_VER_HDR JVH "
        SQL_STRING &= " INNER JOIN (SELECT JVH2.JOB_NUMBER, JVH2.JOB_COMPONENT_NBR, MAX(JVH2.JOB_VER_SEQ_NBR) AS JOB_VER_SEQ_NBR "
        SQL_STRING &= " FROM JOB_VER_HDR JVH2 "
        SQL_STRING &= " GROUP BY JVH2.JOB_NUMBER, JVH2.JOB_COMPONENT_NBR) AS JVH2 "
        SQL_STRING &= " ON JVH.JOB_NUMBER = JVH2.JOB_NUMBER  "
        SQL_STRING &= " AND JVH.JOB_COMPONENT_NBR = JVH2.JOB_COMPONENT_NBR "
        SQL_STRING &= " AND JVH.JOB_VER_SEQ_NBR = JVH2.JOB_VER_SEQ_NBR "
        SQL_STRING &= " INNER JOIN JOB_VER_TMPLT_HDR JVTH ON JVTH.JV_TMPLT_CODE = JVH.JV_TMPLT_CODE "
        SQL_STRING &= " WHERE JVH.JOB_NUMBER = " & Job
        SQL_STRING &= " AND JVH.JOB_COMPONENT_NBR = " & Comp

        If dr.HasRows Then
            tooltip = "Job Version<br/>"
            dr.Read()
            tmpl_name = dr.GetString(3)
            seq_nbr = CType(dr.GetInt16(0), String)
            JVDesc = dr.GetString(1)
            crDate = CType(dr.GetDateTime(2), String)

            tooltip &= "Last: " & tmpl_name & " - " & seq_nbr & " - " & JVDesc
            tooltip &= "Date/Time: " & crDate

        Else
            tooltip = "None"

        End If

        Return tooltip

    End Function

    Private Function getJobSpecTooltipInfo() As String
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr_jobSpecs As SqlDataReader

        Dim specVer As Int32
        Dim specRev As Int32
        Dim apprRev As Int32
        Dim desc, apprVer, tooltip As String

        SQL_STRING = "SELECT JS1.JOB_NUMBER, JS1.JOB_COMPONENT_NBR, JS1.SPEC_VER, JS1.SPEC_REV, ISNULL(JS1.SPEC_VER_DESC,'') SPEC_VER_DESC, ISNULL(CAST(JSA.APPR_SPEC_VER AS VARCHAR(4)),'None') APPR_SPEC_VER"
        SQL_STRING &= " FROM JOB_SPECS JS1  "
        SQL_STRING &= " INNER JOIN (SELECT JS2.JOB_NUMBER, JS2.JOB_COMPONENT_NBR, JS2.SPEC_VER, MAX(JS2.SPEC_REV) AS SPEC_REV "
        SQL_STRING &= " FROM JOB_SPECS JS2 "
        SQL_STRING &= " GROUP BY JS2.JOB_NUMBER, JS2.JOB_COMPONENT_NBR, JS2.SPEC_VER ) AS JS2 "
        SQL_STRING &= " ON JS1.JOB_NUMBER = JS2.JOB_NUMBER "
        SQL_STRING &= " AND JS1.JOB_COMPONENT_NBR = JS2.JOB_COMPONENT_NBR "
        SQL_STRING &= " AND JS1.SPEC_VER = JS2.SPEC_VER "
        SQL_STRING &= " AND JS1.SPEC_REV = JS2.SPEC_REV "
        SQL_STRING &= " LEFT OUTER JOIN JOB_SPEC_APPR JSA ON JSA.JOB_NUMBER = JS2.JOB_NUMBER "
        SQL_STRING &= " AND JSA.JOB_COMPONENT_NBR = JS2.JOB_COMPONENT_NBR "

        SQL_STRING &= " WHERE JS1.JOB_NUMBER = " & Job
        SQL_STRING &= " AND JS1.JOB_COMPONENT_NBR = " & Comp

        SQL_STRING &= " ORDER BY JS1.JOB_NUMBER, JS1.JOB_COMPONENT_NBR, JS1.SPEC_VER, JS1.SPEC_REV "

        Try
            dr_jobSpecs = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            'dt_jobSpecs = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.Text, SQL_STRING, "temp")
        Catch
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getQuoted", Err.Description)
        Finally
        End Try

        desc = ""

        If dr_jobSpecs.HasRows Then
            tooltip = "Job Specification<br/>"
            Do While dr_jobSpecs.Read
                specVer = dr_jobSpecs.GetInt32(2)
                specRev = dr_jobSpecs.GetInt32(3)
                desc = dr_jobSpecs.GetString(4)
                apprVer = dr_jobSpecs.GetString(5)

                If CStr(specVer) = apprVer Then
                    apprRev = specRev
                End If

                tooltip &= "Version " & CType(specVer, String) & " Rev " & CType(specRev, String) & ": " & desc & "<br/>"
            Loop

            If apprVer = "None" Then
                tooltip &= "Approved Version: None"
            Else
                tooltip &= "Approved Version: " & apprVer & " Rev " & CType(apprRev, String)
            End If

        Else
            tooltip = "None"

        End If

        Return tooltip


    End Function

    'Private Sub getJobSpecsTooltipByJobComp(ByVal job As Int32, ByVal comp As Int16, ByRef tooltip As String)
    '    Dim job_nbr As Integer
    '    Dim comp_nbr As Int16
    '    Dim specVer As Int32
    '    Dim specRev As Int32
    '    Dim apprRev As Int32
    '    Dim desc, apprVer As String
    '    Dim found As Boolean = False
    '    Dim idx As Int32

    '    ' dr_jobSpecs dataset JOB_NUMBER, JOB_COMPONENT_NBR, SPEC_VER, SPEC_REV, SPEC_VER_DESC, APPR_SPEC_VER
    '    desc = ""
    '    tooltip = ""
    '    found = False

    '    If dr_jobSpecs.HasRows Then
    '        Do While dr_jobSpecs.Read
    '            job_nbr = dr_jobSpecs.GetInt32(0)
    '            comp_nbr = dr_jobSpecs.GetInt16(1)
    '            If job_nbr = job And comp_nbr = comp Then
    '                specVer = dr_jobSpecs.GetInt32(2)
    '                specRev = dr_jobSpecs.GetInt32(3)
    '                desc = dr_jobSpecs.GetString(4)
    '                apprVer = dr_jobSpecs.GetString(5)

    '                If CStr(specVer) = apprVer Then
    '                    apprRev = specRev
    '                End If

    '                tooltip &= "Version " & CType(specVer, String) & " Rev " & CType(specRev, String) & ": " & desc & "<br/>"
    '                found = True
    '            End If
    '            If job_nbr > job Then
    '                Exit Do
    '            End If
    '        Loop

    '        If found = True Then
    '            If apprVer = "None" Then
    '                tooltip &= "Approved Version: None"
    '            Else
    '                tooltip &= "Approved Version: " & apprVer & " Rev " & CType(apprRev, String)
    '            End If

    '        Else
    '            tooltip = "None"
    '        End If

    '    End If


    'End Sub


    Private Sub reset()
        'clear the uc
    End Sub


End Class