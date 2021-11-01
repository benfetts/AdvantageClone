Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document

Public Class sum_rep_by_client
    Public strUserID As String = "%"
    Public strClientID As String = "%"
    Public ConnString As String
    Public dtMain As DataTable
    Public dtNextDue As DataTable
    Public TextDoc As Boolean
    Public Filter As String
    Public division As Boolean
    Public product As Boolean
    Public title As String
    Public AE As Boolean
    Public JobDesc As Boolean
    Public Job As Boolean
    Public Component As Boolean
    Public CompDesc As Boolean
    Public type As Boolean
    Public typeDesc As Boolean
    Public status As Boolean
    Public ref As Boolean
    Public sdate As Boolean
    Public duedate As Boolean
    Public comm As Boolean
    Public ndue As Boolean
    Public nduedate As Boolean
    Public nduecomm As Boolean
    Public estimate As Boolean
    Public estaprv As Boolean
    Public strDateRange As String
    Public jobqty As Boolean
    Dim MainDView As DataView
    Dim NexDueView As DataView
    Public CultureCode As String = "en-US"
    'Private ds As arptOpenJobsDS
    'Public dt As New arptOpenJobsDS.usp_OpenJobsReportDataTable

    Private Sub sum_rep_by_client_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'ds = New arptOpenJobsDS
        'Dim t As New arptOpenJobsDSTableAdapters.usp_OpenJobsReportTableAdapter
        't.Fill(dt, strUserID, strClientID)
        'If dtMain.Rows.Count > 0 Then
        MainDView = New DataView(dtMain)
        'End If
        If Me.Filter.Trim <> "" Then
            MainDView.RowFilter = Me.Filter
        End If
        'If dtMain.Rows.Count > 0 Then
        Me.DataSource = MainDView
        'End If
        'If dtNextDue.Rows.Count > 0 Then
        NexDueView = New DataView(dtNextDue)
        'End If

    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        
    End Sub

    Private Sub Detail1_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.AfterPrint
        NexDueView.RowFilter = Nothing
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Me.txtJob1.Visible = Me.JobDesc
        Me.txtComponent1.Visible = Me.CompDesc
        Me.txtComponentNumber.Visible = Me.Component
        Me.txtType.Visible = Me.type
        Me.txtType_desc.Visible = Me.typeDesc
        Me.txtStatus.Visible = Me.status
        Me.txtRef.Visible = Me.ref
        Me.txtSdate.Visible = Me.sdate
        Me.txtDue_Date1.Visible = Me.duedate
        If Me.comm = False Then
            Me.txtComm.Text = ""
        Else
            Me.txtComm.Visible = Me.comm
        End If
        Me.txtNTask.Visible = Me.ndue
        Me.txtND.Visible = Me.nduedate
        Me.txtNComm.Visible = Me.nduecomm
        Me.txtEst.Visible = Me.estimate
        'Me.txtJobQty.Visible = Me.jobqty
        'Me.TextBox2.Visible = Me.jobqty
        
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try

            If Me.jobqty = False Then
                Me.txtJobQty.Text = ""
                Me.TextBox2.Text = ""
            End If
            If Me.txtJobNumber.Text <> "" Then
                If Me.txtJobNumber.Text.Length = 1 Then
                    Me.txtJobNumber.Text = "00000" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 2 Then
                    Me.txtJobNumber.Text = "0000" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 3 Then
                    Me.txtJobNumber.Text = "000" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 4 Then
                    Me.txtJobNumber.Text = "00" & Me.txtJobNumber.Text
                End If
                If Me.txtJobNumber.Text.Length = 5 Then
                    Me.txtJobNumber.Text = "0" & Me.txtJobNumber.Text
                End If
            End If
            Me.lbluser.Text = Me.strUserID
            If Me.txtComponentNumber.Text <> "" Then
                If Me.txtComponentNumber.Text.Length = 1 Then
                    Me.txtComponentNumber.Text = "0" & Me.txtComponentNumber.Text
                End If
            End If
            If Me.nduecomm = True Or Me.ndue = True Or Me.nduedate = True Then
                If Me.txtJobNumber.Text <> "" Then
                    NexDueView.RowFilter = "JOB_NUMBER=" & CInt(txtJobNumber.Text.Trim) & " AND JOB_COMPONENT_NBR=" & CInt(Me.txtComponentNumber.Text.Trim)
                    If NexDueView.Count > 0 Then
                        Me.txtNTask.Text = NexDueView(0)("TASK_DESCRIPTION").ToString()
                        If IsDBNull(NexDueView(0)("JOB_REVISED_DATE")) = False Then
                            Me.txtND.Text = CDate(NexDueView(0)("JOB_REVISED_DATE")).ToShortDateString
                        End If
                        Me.txtNComm.Text = IIf(NexDueView(0)("FNC_COMMENTS").Equals(System.DBNull.Value), "", NexDueView(0)("FNC_COMMENTS").ToString())
                    Else
                        Me.txtNTask.Text = ""
                        Me.txtND.Text = ""
                        Me.txtNComm.Text = ""

                    End If
                End If
            End If
            
            If Me.txtEst.Text.Trim <> "" Then
                Me.txtEst.Text = "Y"
            Else
                Me.txtEst.Text = "N"
            End If
            Me.txtEstAprv.Visible = Me.estaprv
            If Me.txtEstAprv.Text.Trim <> "" Then
                Me.txtEstAprv.Text = "Y"
            Else
                Me.txtEstAprv.Text = "N"
            End If
            If Me.txtSdate.Text <> "" Then
                Me.txtSdate.Text = CDate(Me.txtSdate.Text).ToShortDateString
            End If
            If Me.txtDue_Date1.Text <> "" Then
                Me.txtDue_Date1.Text = CDate(Me.txtDue_Date1.Text).ToShortDateString
            End If
        Catch ex As Exception
            Me.lblae.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint
        If TextDoc Then
            Me.ReportInfo1.Visible = False
        End If
    End Sub

    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint
        'Me.DateOJ.Text = Now.Date.Date
        
    End Sub

    Private Sub GroupHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.BeforePrint
        Me.lbldiv.Visible = Me.division
        Me.lblprod.Visible = Me.product
        Me.lblae.Visible = Me.AE
        Me.txtDivision1.Visible = Me.division
        Me.txtDivisionCode.Visible = Me.division
        Me.txtProduct1.Visible = Me.product
        Me.txtProductCode.Visible = Me.product
        Me.txtAccount_Executive1.Visible = Me.AE

        
    End Sub

    Private Sub GroupHeader2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.BeforePrint
       
        '.Visible = Me.Component
        Me.lblType.Visible = Me.type
        'Me.lblTypeDesc.Visible = Me.typeDesc
        Me.lblStatus.Visible = Me.status
        Me.lblRef.Visible = Me.ref
        Me.lblSdate.Visible = Me.sdate
        Me.lblDueDate.Visible = Me.duedate
        'Me.Label1.Visible = Me.comm
        Me.lblNT.Visible = Me.ndue
        Me.lblND.Visible = Me.nduedate
        Me.Label3.Visible = Me.nduecomm
        Me.lblEst.Visible = Me.estimate
        Me.lblestaprv.Visible = Me.estaprv
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        If Me.title.Trim <> "" Then
            Me.TextBox1.Text = Me.title
        End If
    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format

    End Sub
End Class
