Public Partial Class BillingApproval_Batch_Tooltip
    Inherits System.Web.UI.UserControl
    Public Property BatchID() As String
        Get
            If ViewState("BatchID") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("BatchID"), String)
        End Get
        Set(ByVal value As String)
            If Me.BatchID <> value Then
                Me.reset()
            End If
            ViewState("BatchID") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Label1.Text = "Batch ID: " & Me.BatchID.ToString()
        If IsNumeric(Me.BatchID) Then
            Dim CurrBatchID As Integer = CType(Me.BatchID, Integer)
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dsBatchDetails As New DataSet
            Dim dtBatchHeader As New DataTable
            dsBatchDetails = b.GetBatchDetails(CurrBatchID)
            dtBatchHeader = dsBatchDetails.Tables(0)
            If dtBatchHeader.Rows.Count > 0 Then
                If IsDBNull(dtBatchHeader.Rows(0)("CREATE_DATE")) = False Then
                    Me.LblCreated.Text = cGlobals.wvCDate(dtBatchHeader.Rows(0)("CREATE_DATE").ToString()).ToShortDateString
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("CREATE_USER_NAME")) = False Then
                    Me.LblUserID.Text = dtBatchHeader.Rows(0)("CREATE_USER_NAME").ToString()
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("MODIFY_DATE")) = False Then
                    Me.LblModified.Text = cGlobals.wvCDate(dtBatchHeader.Rows(0)("MODIFY_DATE").ToString()).ToShortDateString
                End If
                If IsDBNull(dtBatchHeader.Rows(0)("MODIFY_USER_NAME")) = False Then
                    Me.LblModifiedUser.Text = dtBatchHeader.Rows(0)("MODIFY_USER_NAME").ToString()
                End If
            End If
        End If
    End Sub

    Private Sub reset()
        'clear the uc
    End Sub
End Class