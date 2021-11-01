Partial Public Class purchaseorder_Approval_Tooltip
    Inherits System.Web.UI.UserControl
    Public Property PONumber() As String
        Get
            If ViewState("PONumber") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("PONumber"), String)
        End Get
        Set(ByVal value As String)
            If Me.PONumber <> value Then
                Me.reset()
            End If
            ViewState("PONumber") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Label1.Text = "Batch ID: " & Me.BatchID.ToString()
        Me.LblEmployee.Text = ""
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim dr As SqlClient.SqlDataReader
        If IsNumeric(Me.PONumber) Then
            dr = POHeader.GetPOApprDataByPO(Me.PONumber)
            If dr.HasRows = True Then
                'Me.LblEmployee.Text &= "" & vbCrLf
                'Me.LblEmployee.Text &= "Approvals needed: </br>"
                Do While dr.Read
                    Me.LblEmployee.Text &= dr.GetString(6) & ": "
                    If IsDBNull(dr("PO_APPROVAL_FLAG")) = False Then
                        If dr.GetBoolean(5) = True Then
                            Me.LblEmployee.Text &= "Approved</br>"
                        ElseIf dr.GetBoolean(5) = False Then
                            Me.LblEmployee.Text &= "Denied</br>"
                        Else
                            Me.LblEmployee.Text &= "Pending</br>"
                        End If
                    Else
                        Me.LblEmployee.Text &= "Pending</br>"
                    End If
                Loop
            End If

        End If
    End Sub

    Private Sub reset()
        'clear the uc
    End Sub
End Class