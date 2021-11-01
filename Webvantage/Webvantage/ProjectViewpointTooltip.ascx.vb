Imports System.Data.SqlClient

Partial Public Class ProjectViewpointTooltip
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

        Select Case appName
            Case "QvA"
                Me.LblTooltip.Text = GetQvATooltipInfo()

            Case "Alert"
                Me.LblTooltip.Text = getAlertTooltipByJobComp()

            Case "JobSpecs"
                Me.LblTooltip.Text = getJobSpecTooltipInfo()

            Case "Versions"
                Me.LblTooltip.Text = getVersionsTooltipInfo()

            Case "Estimating"
                Me.LblTooltip.Text = getEstTooltipInfo()

            Case "Scheduling"
                Me.LblTooltip.Text = getSchedTooltipInfo()

            Case "CB"
                Me.LblTooltip.Text = getCreativeBrief()

            Case "All"
                Me.LblTooltip.Text = params(0)

        End Select

    End Sub

    Private Function getVersionsTooltipInfo() As String
        Dim ojobver As JobVersion = New JobVersion(CStr(Session("ConnString")))
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim tooltip As String
        Dim tmpl_name, JVDesc, agencyDesc As String
        Dim seq_nbr As Int16
        Dim crDate As DateTime

        SQL_STRING = "SELECT JVH.JOB_VER_SEQ_NBR, ISNULL(JVH.JOB_VER_DESC,''), JVH.CREATE_DATE, JVTH.JV_TMPLT_DESC "
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

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getVersionsTooltipInfo", Err.Description)
        Finally
        End Try

        agencyDesc = ojobver.GetAgencyDesc()

        tooltip = "<strong>" & agencyDesc & "</strong><br/>"
        If dr.HasRows Then
            dr.Read()
            tmpl_name = dr.GetString(3)
            seq_nbr = dr.GetInt16(0)
            JVDesc = dr.GetString(1)
            crDate = dr.GetDateTime(2)

            tooltip &= "<strong>Last: </strong>" & tmpl_name & " - " & CType(seq_nbr, String) & " - " & JVDesc & "<br/>"
            tooltip &= "<strong>Date/Time: </strong>" & CType(crDate, String)

        Else
            tooltip &= "None"
        End If

        Return tooltip

    End Function

    Private Function getEstTooltipInfo() As String
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim tooltip As String
        Dim jobQty, estNbr As Int32
        Dim QuoteNbr, revNbr, estComp As Int16
        Dim apprBy, apprByInt As String
        Dim apprDate, apprDateInt As DateTime
        Dim apprDateStr, apprDateIntStr As String
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))

        dr = cb.getTooltipEst(Job, Comp)

        If dr.HasRows Then
            dr.Read()
            If Not IsDBNull(dr.GetValue(0)) Then
                QuoteNbr = dr.GetInt16(0)
                revNbr = dr.GetInt16(1)
                jobQty = dr.GetInt32(2)
            Else
                QuoteNbr = 0
                revNbr = 0
                jobQty = 0
            End If
            
            apprBy = dr.GetString(3)

            If apprBy = "" Then
                apprBy = "N/A"
            End If

            If Not IsDBNull(dr.GetValue(4)) Then
                apprDateStr = CStr(dr.GetDateTime(4))
            Else
                apprDateStr = ""
            End If

            estNbr = dr.GetInt32(5)
            estComp = dr.GetInt16(6)

            apprByInt = dr.GetString(7)
            If apprByInt = "" Then
                apprByInt = "N/A"
            End If

            If Not IsDBNull(dr.GetValue(8)) Then
                apprDateIntStr = CStr(dr.GetValue(8))
            Else
                apprDateIntStr = ""
            End If

            tooltip = "<strong>Estimate: </strong>" & CStr(estNbr.ToString.PadLeft(6, "0")) & "  <strong>Component:</strong> " & CStr(estComp.ToString.PadLeft(2, "0")) & "<br/>"

            If QuoteNbr = 0 Then
                tooltip &= "<strong>Approved Quote: </strong> None <br/>"
            Else
                tooltip &= "<strong>Approved Quote: </strong> Quote " & CStr(QuoteNbr) & " Rev " & CStr(revNbr) & " - Qty " & CStr(jobQty.ToString("#,##0")) & "<br/>"
            End If
            
            tooltip &= "<strong>Internal Approved By: </strong> " & apprByInt & " " & apprDateIntStr & "<br/>"
            tooltip &= "<strong>Client Approved By: </strong> " & apprBy & " " & apprDateStr

        Else
            tooltip = "<strong>Estimate:</strong><br/> None"
        End If

        Return tooltip

    End Function

    Private Function getSchedTooltipInfo() As String
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim tooltip As String
        Dim trfDesc, trfComments

        SQL_STRING = "SELECT ISNULL(T.TRF_DESCRIPTION,''), ISNULL(CAST(JT.TRF_COMMENTS AS VARCHAR(1000)),'') TRF_COMMENTS "
        SQL_STRING &= " FROM JOB_TRAFFIC JT "
        SQL_STRING &= " INNER JOIN TRAFFIC T ON T.TRF_CODE = JT.TRF_CODE "
        SQL_STRING &= " WHERE JT.JOB_NUMBER = " & Job & " AND JT.JOB_COMPONENT_NBR = " & Comp

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getSchedTooltipInfo", Err.Description)
        Finally
        End Try

        tooltip = "<strong>Project Schedule</strong><br/>"
        If dr.HasRows Then
            dr.Read()
            trfDesc = dr.GetString(0)
            trfComments = dr.GetString(1)

            tooltip &= "<strong>Current Status: </strong>" & trfDesc & "<br/>"
            tooltip &= "<strong>Comment: </strong>" & trfComments

        Else
            tooltip &= "None"
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
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getJobSpecTooltipInfo", Err.Description)
        Finally
        End Try

        desc = ""

        tooltip = "<strong>Job Specification</strong><br/>"
        If dr_jobSpecs.HasRows Then

            Do While dr_jobSpecs.Read
                specVer = dr_jobSpecs.GetInt32(2)
                specRev = dr_jobSpecs.GetInt32(3)
                desc = dr_jobSpecs.GetString(4)
                apprVer = dr_jobSpecs.GetString(5)

                If CStr(specVer) = apprVer Then
                    apprRev = specRev
                End If

                tooltip &= "<strong>Version:</strong> " & CType(specVer, String) & " Rev " & CType(specRev, String) & ": " & desc & "<br/>"
            Loop

            If apprVer = "None" Then
                tooltip &= "<strong>Approved Version:</strong> None"
            Else
                tooltip &= "<strong>Approved Version:</strong> " & apprVer & " Rev " & CType(apprRev, String)
            End If

        Else
            tooltip &= "None"

        End If

        Return tooltip


    End Function

    Private Function getAlertTooltipByJobComp() As String
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr_Alerts As SqlDataReader
        Dim Subject, Generated, tooltip As String

        SQL_STRING = "SELECT A1.JOB_NUMBER, A1.JOB_COMPONENT_NBR, A1.ALERT_ID, ISNULL(A1.SUBJECT, ''), ISNULL(A1.GENERATED,'') "
        SQL_STRING &= " FROM ALERT A1, (SELECT A2.JOB_NUMBER, A2.JOB_COMPONENT_NBR, MAX(A2.ALERT_ID) AS ALERT_ID "
        SQL_STRING &= " FROM ALERT A2 "
        SQL_STRING &= " WHERE(A2.JOB_NUMBER Is Not NULL And A2.JOB_COMPONENT_NBR Is Not NULL) "
        SQL_STRING &= " GROUP BY A2.JOB_NUMBER, A2.JOB_COMPONENT_NBR) AS A2 "
        SQL_STRING &= " WHERE A1.JOB_NUMBER Is Not NULL And A1.JOB_COMPONENT_NBR Is Not NULL "
        SQL_STRING &= " AND A1.JOB_NUMBER = A2.JOB_NUMBER "
        SQL_STRING &= " AND A1.JOB_COMPONENT_NBR =  A2.JOB_COMPONENT_NBR "
        SQL_STRING &= " AND A1.ALERT_ID = A2.ALERT_ID "
        SQL_STRING &= " AND A1.JOB_NUMBER = " & Job & " AND A1.JOB_COMPONENT_NBR = " & Comp

        Try
            dr_Alerts = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getAlertTooltipByJobComp", Err.Description)
        Finally
        End Try

        If dr_Alerts.HasRows Then
            dr_Alerts.Read()

            Subject = dr_Alerts.GetString(3)
            Generated = CType(dr_Alerts.GetDateTime(4), String)
            tooltip = "<strong>Alerts/Documents<br/>Last Alert:</strong> " & Subject & "<br/><strong> Date/Time: </strong>" & Generated
        Else
            tooltip = "<strong>Alerts/Documents<br/></strong> <br/>None"
        End If



        Return tooltip

    End Function

    Private Function GetQvATooltipInfo() As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim client, division, product, timeonly As String
        Dim timeonlyBool As Boolean
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
        appVars.getAllAppVars()

        client = ""
        division = ""
        product = ""
        timeonly = appVars.getAppVar("PVQvAType", "Boolean")

        timeonlyBool = CType(timeonly, Boolean)

        Dim reader As SqlDataReader
        reader = oDO.GetQVAByJobComp(timeonlyBool, Session("UserCode"), Job, Comp)

        Dim qtQty, actQty, qtTot, actTot As Decimal
        Dim tooltip As String

        qtQty = 0
        actQty = 0
        qtTot = 0
        actTot = 0

        If reader.HasRows Then
            reader.Read()
            qtQty = reader.GetDecimal(4)
            actQty = reader.GetDecimal(5)
            qtTot = reader.GetDecimal(2)
            actTot = reader.GetDecimal(3)
        End If

        tooltip = "<strong>QvA<br/>Quote Qty/Hrs: </strong>" & CStr(qtQty.ToString("#,##0.00")) & "<br/> <strong>Actual Qty/Hrs:</strong> " & CStr(actQty.ToString("#,##0.00")) & "<br/><br/><strong>Quote Total: </strong>" & CStr(qtTot.ToString("#,##0.00")) & "<br/> <strong>Actual Total:</strong> " & CStr(actTot.ToString("#,##0.00"))
        Return tooltip

    End Function

    Private Function getCreativeBrief() As String
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim ApprBy, ApprDate, tooltip As String

        SQL_STRING = "SELECT ISNULL(CB_APPR_BY,''), ISNULL(CONVERT(varchar(10),CB_APPR_DATE, 101),'')  "
        SQL_STRING &= " FROM CRTV_BRF_DTL D "
        SQL_STRING &= " LEFT OUTER JOIN CRTV_BRF_APPR A ON D.JOB_NUMBER = A.JOB_NUMBER AND D.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR "
        SQL_STRING &= " WHERE D.JOB_NUMBER = " & Job & " AND D.JOB_COMPONENT_NBR = " & Comp

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getCreativeBrief", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()

            ApprBy = dr.GetString(0)
            ApprDate = dr.GetString(1)
            If ApprBy <> "" Then
                tooltip = "<strong>Creative Brief<br/>Approved by:</strong> " & ApprBy & "<br/><strong> Date: </strong>" & ApprDate
            Else
                tooltip = "<strong>Creative Brief<br/>Approved by:</strong> None"
            End If

        Else
            tooltip = "<strong>Creative Brief<br/></strong>None"
        End If

        Return tooltip

    End Function

    Private Sub reset()
        'clear the uc
    End Sub


End Class