Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Partial Public Class Estimating_Phase
    Inherits Webvantage.BaseChildPage
    Private ConnectionString As String
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private EstNum As Integer
    Private EstCompNum As Integer
    Private QuoteNum As Integer
    Private RevNum As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Me.ConnectionString = Session("ConnString")
        'Dim CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
        'Me.CancelButton.Attributes.Add("onclick", CancelScript)
        Me.JobNum = Request.QueryString("JobNum")
        Me.JobCompNum = Request.QueryString("JobCompNum")
        Me.EstNum = Request.QueryString("EstNum")
        Me.EstCompNum = Request.QueryString("EstCompNum")
        Me.QuoteNum = Request.QueryString("QuoteNum")
        Me.RevNum = Request.QueryString("RevNum")

        If Not Me.IsPostBack Then
            Me.pnlPhase.Visible = True
            Me.btnUpdate.Visible = False
            Me.ddEstimatePhase.Visible = False
            Me.txtNewPhase.Visible = False
            Me.lblPhase.Visible = False
            LoadEstimatePhases()
        Else
            Select Case Me.EventArgument
                Case "Refresh"

                Case "HidePopups"

            End Select
        End If
    End Sub

#Region " SubRoutines: "

    Private Sub LoadEstimatePhases()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Me.ddEstimatePhase.DataSource = est.GetEstimatePhaseDesc(Me.EstNum, Me.EstCompNum)
            Me.ddEstimatePhase.DataTextField = "Description"
            Me.ddEstimatePhase.DataValueField = "Description"
            Me.ddEstimatePhase.DataBind()
            Me.ddEstimatePhase.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("None", ""))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub checkchanged()
        Try
            If rbExisting.Checked = True Then
                Me.ddEstimatePhase.Visible = True
                Me.lblPhase.Visible = False
                Me.txtNewPhase.Visible = False
                LoadEstimatePhases()
            End If
            If rbNew.Checked = True Then
                Me.ddEstimatePhase.Visible = False
                Me.lblPhase.Visible = True
                Me.txtNewPhase.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Controls: "

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            'update = est.AddQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.JobNum, Me.JobCompNum, Me.txtApprovedBy.Text, CDate(Me.txtApprovalDate.Text), Me.txtClientPO.Text, Session("UserCode"), Now, Me.txtNotes.Text)
            'If update = True Then
            Dim phase As Integer
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim updatestring As String = Request.QueryString("uStr")
            ds = est.GetEstimatePhases(Me.EstNum, Me.EstCompNum)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("description") = Me.ddEstimatePhase.SelectedValue Then
                        phase = ds.Tables(0).Rows(i)("code")
                        Exit For
                    End If
                Next
            End If
            
            If Me.rbExisting.Checked = True Then
                If Me.ddEstimatePhase.SelectedValue = "" Then
                    Session("EstPhaseID") = -1
                    Session("EstPhaseDesc") = ""
                Else
                    Session("EstPhaseID") = phase
                    Session("EstPhaseDesc") = Me.ddEstimatePhase.SelectedItem.Text
                End If
            End If
            If Me.rbNew.Checked = True Then
                Session("EstPhaseID") = 0
                Session("EstPhaseDesc") = Me.txtNewPhase.Text
            End If
            If EstNum > 0 And EstCompNum > 0 And updatestring.Length > 0 Then
                est.UpdateQuotePhase(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, updatestring, Session("EstPhaseID"), Session("EstPhaseDesc"))
            End If
            Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")
            'Dim FunctionName As String = "Phase"
            'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
            'Else
            'Me.ShowMessage("Phase update Failed!")
            'End If
        Catch ex As Exception
            Me.ShowMessage("Error estimatephase!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Try
            Me.CloseThisWindow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbExisting_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbExisting.CheckedChanged
        checkchanged()
    End Sub

    Private Sub rbNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNew.CheckedChanged
        checkchanged()
    End Sub

#End Region




    
    
End Class