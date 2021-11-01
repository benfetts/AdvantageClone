Public Partial Class BillingApproval_Batch_Tooltip_JobList
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
    Public Property GetSimpleList() As Boolean
        Get

            If ViewState("GetSimpleList") Is Nothing Then

                Return False

            Else

                Return DirectCast(ViewState("GetSimpleList"), Boolean)

            End If

        End Get
        Set(ByVal value As Boolean)

            ViewState("GetSimpleList") = value

        End Set
    End Property
    Public Property ItalicizeApproved() As Boolean
        Get

            If ViewState("ItalicizeApproved") Is Nothing Then

                Return False

            Else

                Return DirectCast(ViewState("ItalicizeApproved"), Boolean)

            End If

        End Get
        Set(ByVal value As Boolean)

            ViewState("ItalicizeApproved") = value

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNumeric(Me.BatchID) Then

            Dim CurrBatchID As Integer = CType(Me.BatchID, Integer)
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dtJobList As New DataTable
            Dim str As String = ""

            If Me.GetSimpleList = False Then

                dtJobList = b.GetBatchJobList(CurrBatchID)

            Else

                dtJobList = b.GetBatchJobListSimple(CurrBatchID, True)

            End If

            If dtJobList.Rows.Count > 0 Then

                For k As Integer = 0 To dtJobList.Rows.Count - 1

                    If IsDBNull(dtJobList.Rows(k)("JOB_AND_COMPONENT")) = False Then

                        If dtJobList.Rows(k)("UNAPPROVED") = False AndAlso ItalicizeApproved = True Then

                            str &= "<div style=""font-style:italic;"">" & dtJobList.Rows(k)("JOB_AND_COMPONENT").ToString() & "</div>"

                        Else

                            str &= "<div>" & dtJobList.Rows(k)("JOB_AND_COMPONENT").ToString() & "</div>"

                        End If

                    End If

                Next

                Me.LblJobs.Text = str

            Else

                Me.LblJobs.Text = "[None]"

            End If

        End If
    End Sub

    Private Sub reset()
        'clear the uc
    End Sub

End Class