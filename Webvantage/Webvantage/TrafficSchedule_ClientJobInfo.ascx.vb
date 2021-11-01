Public Partial Class TrafficSchedule_ClientJobInfo
    Inherits System.Web.UI.UserControl

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

        End If

    End Sub
    Public Sub GetPageData(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer)
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim dt As DataTable = oTrafficSchedule.GetScheduleHeader(JobNumber, JobComponentNumber, Session("UserCode").ToString(), False).Tables(0)
        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("CL_CODE")) = False And IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                Me.lblClient.Text = "(" + dt.Rows(0)("CL_CODE") + ") " + dt.Rows(0)("CL_NAME")
            End If
            If IsDBNull(dt.Rows(0)("DIV_CODE")) = False And IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                Me.lblDivision.Text = "(" + dt.Rows(0)("DIV_CODE") + ") " + dt.Rows(0)("DIV_NAME")
            End If
            If IsDBNull(dt.Rows(0)("PRD_CODE")) = False And IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                Me.lblProduct.Text = "(" + dt.Rows(0)("PRD_CODE") + ") " + dt.Rows(0)("PRD_DESCRIPTION")
            End If
            If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False And IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                ' _JobNum = CInt(dt.Rows(0)("JOB_NUMBER"))
                Me.lblJob.Text = "(" + dt.Rows(0)("JOB_NUMBER").ToString() + ") " + dt.Rows(0)("JOB_DESC")
            End If
            If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False And IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                Me.lblJobComp.Text = "(" + dt.Rows(0)("JOB_COMPONENT_NBR").ToString() + ") " + dt.Rows(0)("JOB_COMP_DESC")
            End If
            If IsDBNull(dt.Rows(0)("TRF_DESC")) = False Then
                'Me.TxtTrafficStatusDescription.Text = ""
                Me.lblJobStatus.Text = dt.Rows(0)("TRF_DESC")
                Me.lblJobStatus.Text = "(" + dt.Rows(0)("TRF_CODE") + ") " + dt.Rows(0)("TRF_DESC")
            End If
            If IsDBNull(dt.Rows(0)("Comments")) = False Then
                Me.lblJobComments.Text = HttpUtility.HtmlEncode(dt.Rows(0)("Comments")).ToString.Replace("\n", "<br/>").Replace(Environment.NewLine, "<br/>").Replace(vbLf, "<br/>")
            End If
            If IsDBNull(dt.Rows(0)("START_DATE")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("START_DATE")) = True Then
                    Me.lblJobStartDate.Text = String.Format("{0:d}", CDate(dt.Rows(0)("START_DATE")))
                Else
                    Me.lblJobStartDate.Text = ""
                End If
            Else
                Me.lblJobStartDate.Text = ""
            End If
            If Me.lblJobStartDate.Text = "1/1/1900" Then
                Me.lblJobStartDate.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("JOB_FIRST_USE_DATE")) = True Then
                    ' Me.lblJobDueDate.Text = cGlobals.wvCDate(dt.Rows(0)("JOB_FIRST_USE_DATE")).ToShortDateString
                    Me.lblJobDueDate.Text = String.Format("{0:d}", CDate(dt.Rows(0)("JOB_FIRST_USE_DATE")))
                Else
                    Me.lblJobDueDate.Text = ""
                End If
            Else
                Me.lblJobDueDate.Text = ""
            End If
            If Me.lblJobDueDate.Text = "1/1/1900" Then
                Me.lblJobDueDate.Text = ""
            End If
            Dim AECode As String
            Dim AEDesc As String
            If IsDBNull(dt.Rows(0)("EMP_CODE_AE")) = False Then
                AECode = dt.Rows(0)("EMP_CODE_AE")
            Else
                AECode = ""
            End If
            If IsDBNull(dt.Rows(0)("AE_NAME")) = False Then
                AEDesc = dt.Rows(0)("AE_NAME")
            Else
                AEDesc = ""
            End If
            lblAE.Text = "(" + AECode + ") " + AEDesc

        End If
    End Sub

    
   
   
End Class