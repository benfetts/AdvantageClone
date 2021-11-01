Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Partial Public Class Estimating_JobSpecs
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
        
        Dim CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
        'Me.CancelButton.Attributes.Add("onclick", CancelScript)
        Me.JobNum = Request.QueryString("JobNum")
        Me.JobCompNum = Request.QueryString("JobCompNum")
        Me.EstNum = Request.QueryString("EstNum")
        Me.EstCompNum = Request.QueryString("EstCompNum")
        Me.QuoteNum = Request.QueryString("QuoteNum")
        Me.RevNum = Request.QueryString("RevNum")
        If Not Me.IsPostBack Then
            Me.pnlJobSpecs.Visible = True
            Me.btnUpdate.Visible = False
        Else

        End If
    End Sub

#Region " SubRoutines: "

    Private Function SaveSpecs(Optional ByVal RebindGrid As Boolean = True)
        Dim RowCount As Integer = Me.RadGridEstimateJS.MasterTableView.Items.Count
        Dim count As Integer = 0
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEstimateJS.Items(i), Telerik.Web.UI.GridDataItem)
                Dim CurrentSeq As Integer
                Try
                    CurrentSeq = CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer)
                Catch ex As Exception
                    CurrentSeq = -1
                End Try
                If DirectCast(CurrentGridRow.Item("ColumnClientSelect").Controls(0), CheckBox).Checked = True Then
                    SaveGridRow(i, EstNum, EstCompNum, CurrentSeq, CurrentGridRow, QuoteNum, RevNum, False)
                    count = 1
                End If
            Next
        End If
        Return count
    End Function

    Private Function SaveGridRow(ByVal RowIndex As Integer, ByVal RowTask_EstNum As Integer, ByVal RowTask_EstComp As Integer, _
                                     ByVal RowCurrentSeqNum As Integer, ByVal TheGridRow As Telerik.Web.UI.GridDataItem, _
                                     ByVal RowTask_QuoteNum As Integer, ByVal RowTask_RevNum As Integer, Optional ByVal RebindGrid As Boolean = True) As String
        'Create variables:
        Dim RowHasChange As Boolean = False

        Dim RowSpecVersion As Integer
        Dim RowRevision As Integer
        Dim RowQuantity As Integer = -1
        Dim RowSeqNum As Integer

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim v As New cValidations(Session("ConnString"))
        Dim dt As DataTable
        Dim SQLPrefix As String = "UPDATE [ESTIMATE_REV] WITH(ROWLOCK) SET "
        Dim SQLBody As StringBuilder = New StringBuilder
        Dim SQLSuffix As String = " WHERE (ESTIMATE_NUMBER = " & RowTask_EstNum & ") AND (EST_COMPONENT_NBR = " & RowTask_EstComp & ") AND (EST_QUOTE_NBR = " & RowTask_QuoteNum & ") AND (EST_REV_NBR = " & RowTask_RevNum & ")"

        Try
            RowSpecVersion = CInt(TheGridRow("SPEC_VER").Text)
            '	ESTIMATE_REV.SPEC_VER,            
            With SQLBody
                .Append("SPEC_VER = ")
                .Append(RowSpecVersion)
                .Append(", ")
            End With
        Catch ex As Exception
        End Try

        Try
            RowRevision = CInt(TheGridRow("SPEC_REV").Text)
            '	ESTIMATE_REV.SPEC_REV,            
            With SQLBody
                .Append("SPEC_REV = ")
                .Append(RowRevision)
                .Append(", ")
            End With
        Catch ex As Exception
        End Try

        Try
            If TheGridRow("JOB_QTY").Text <> "" And TheGridRow("JOB_QTY").Text <> "&nbsp;" Then
                RowQuantity = CInt(TheGridRow("JOB_QTY").Text)
            End If
            '	ESTIMATE_REV.JOB_QTY,            
            With SQLBody
                If RowQuantity = -1 Then
                    .Append("JOB_QTY = NULL")
                Else
                    .Append("JOB_QTY = ")
                    .Append(RowQuantity)
                End If
                .Append(", ")
            End With
        Catch ex As Exception
        End Try

        Try
            RowSeqNum = RowCurrentSeqNum
            '	ESTIMATE_REV.SPEC_QTY_SEQ_NBR,            
            With SQLBody
                If RowSeqNum = -1 Then
                    .Append("SPEC_QTY_SEQ_NBR = NULL")
                Else
                    .Append("SPEC_QTY_SEQ_NBR = ")
                    .Append(RowSeqNum)
                End If
                .Append(", ")
            End With
        Catch ex As Exception
        End Try



        Dim str As String = SQLBody.ToString
        str = MiscFN.RemoveTrailingDelimiter(str, ",")

        Dim FullSQLString As String = SQLPrefix & str & SQLSuffix

        'FullSQLString &= SavePredList(RowTask_JobNum, RowTask_JobComp, RowTask_SeqNum, RowPredecessorsString)

        'Compare to dataset to get changes,Validate changes:


        'Save:
        Using MyConn As New SqlConnection(Session("ConnString"))
            MyConn.Open()
            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
            Dim MyCmd As New SqlCommand(FullSQLString, MyConn, MyTrans)
            Try
                MyCmd.ExecuteNonQuery()
                MyTrans.Commit()
            Catch ex As Exception
                MyTrans.Rollback()
            Finally
                If MyConn.State = ConnectionState.Open Then MyConn.Close()
            End Try
        End Using


        'If RebindGrid = True Then
        '    Me.RefreshGrid()
        'End If

    End Function

#End Region

#Region " Controls: "

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Try
            Dim dt As DataTable
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim cv As New cValidations(Session("ConnString"))
            Dim count As Integer

            count = Me.SaveSpecs()

            If count = 0 Then
                Me.lblMSG.Text = "No Spec Version was selected."
                Exit Sub
            End If
            Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")

        Catch ex As Exception
            Me.ShowMessage("Error estimateapproval!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub RadGridEstimateJS_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimateJS.ItemCommand

        If e.Item Is Nothing Then Exit Sub


    End Sub

    Private Sub RadGridEstimateJS_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimateJS.NeedDataSource
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Me.RadGridEstimateJS.DataSource = est.GetEstimateJobSpecs(Me.EstNum, Me.EstCompNum, Me.JobNum, Me.JobCompNum)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
        Try
            Me.CloseThisWindow()
        Catch ex As Exception

        End Try
    End Sub

#End Region




    
    
End Class