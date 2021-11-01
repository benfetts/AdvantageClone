Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Partial Public Class BillingApproval_Approval_Item_Detail_Tooltip_VerDesc
    Inherits System.Web.UI.UserControl

    Public JobVerHdrId As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If JobVerHdrId > 0 Then
            'Me.LblDescription.Text = "The version id is: " & JobVerHdrId
            Try
                Using MyConn As New SqlConnection(Session("ConnString"))
                    MyConn.Open()
                    Dim MyCmd As New SqlCommand("SELECT JOB_VER_DESC FROM JOB_VER_HDR WITH(NOLOCK) WHERE JOB_VER_HDR_ID = " & Me.JobVerHdrId, MyConn)
                    Try
                        Me.LblDescription.Text = MyCmd.ExecuteScalar()
                    Catch ex As Exception
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub

End Class