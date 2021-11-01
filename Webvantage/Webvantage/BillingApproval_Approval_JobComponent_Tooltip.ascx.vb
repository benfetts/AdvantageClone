Public Partial Class BillingApproval_Approval_JobComponent_Tooltip
    Inherits System.Web.UI.UserControl

    Public Property iBatchID() As String
        Get
            If ViewState("iBatchID") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("iBatchID"), String)
        End Get
        Set(ByVal value As String)
            If Me.iBatchID <> value Then
                Me.reset()
            End If
            ViewState("iBatchID") = value
        End Set
    End Property
    Public Property iApprovalID() As String
        Get
            If ViewState("iApprovalID") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("iApprovalID"), String)
        End Get
        Set(ByVal value As String)
            If Me.iApprovalID <> value Then
                Me.reset()
            End If
            ViewState("iApprovalID") = value
        End Set
    End Property
    Public Property iJobNumber() As String
        Get
            If ViewState("iJobNumber") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("iJobNumber"), String)
        End Get
        Set(ByVal value As String)
            If Me.iJobNumber <> value Then
                Me.reset()
            End If
            ViewState("iJobNumber") = value
        End Set
    End Property
    Public Property iJobComponentNbr() As String
        Get
            If ViewState("iJobComponentNbr") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("iJobComponentNbr"), String)
        End Get
        Set(ByVal value As String)
            If Me.iJobComponentNbr <> value Then
                Me.reset()
            End If
            ViewState("iJobComponentNbr") = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Me.iBatchID) = True And IsNumeric(Me.iApprovalID) = True And IsNumeric(Me.iJobNumber) = True And IsNumeric(Me.iJobComponentNbr) = True Then
            Dim BatchID As Integer = CType(Me.iBatchID, Integer)
            Dim ApprovalID As Integer = CType(Me.iApprovalID, Integer)
            Dim JobNumber As Integer = CType(Me.iJobNumber, Integer)
            Dim JobComponentNbr As Integer = CType(Me.iJobComponentNbr, Integer)
            If BatchID > 0 And ApprovalID > 0 And JobNumber > 0 And JobComponentNbr > 0 Then
                Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                Dim DsHeader As New DataSet
                Dim DtBaseInfo As New DataTable
                DsHeader = b.GetComponentHeader(BatchID, ApprovalID, JobNumber, JobComponentNbr)
                DtBaseInfo = DsHeader.Tables(0)
                If DtBaseInfo.Rows.Count > 0 Then
                    If IsDBNull(DtBaseInfo.Rows(0)("CLIENT_DISPLAY")) = False Then
                        Me.LblClient.Text = DtBaseInfo.Rows(0)("CLIENT_DISPLAY")
                    End If
                    If IsDBNull(DtBaseInfo.Rows(0)("DIVISION_DISPLAY")) = False Then
                        Me.LblDivision.Text = DtBaseInfo.Rows(0)("DIVISION_DISPLAY")
                    End If
                    If IsDBNull(DtBaseInfo.Rows(0)("PRODUCT_DISPLAY")) = False Then
                        Me.LblProduct.Text = DtBaseInfo.Rows(0)("PRODUCT_DISPLAY")
                    End If
                    If IsDBNull(DtBaseInfo.Rows(0)("CAMPAIGN_DISPLAY")) = False Then
                        Me.LblCampaign.Text = DtBaseInfo.Rows(0)("CAMPAIGN_DISPLAY")
                    Else
                        Me.LblCampaign.Text = "[None]"
                    End If
                    If IsDBNull(DtBaseInfo.Rows(0)("JOB_AND_COMPONENT")) = False Then
                        Me.LblJobComponent.Text = DtBaseInfo.Rows(0)("JOB_AND_COMPONENT")
                    End If
                    If IsDBNull(DtBaseInfo.Rows(0)("AE_EMP_FML_NAME")) = False Then
                        Me.LblAccountExecutive.Text = DtBaseInfo.Rows(0)("AE_EMP_FML_NAME")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub reset()
        'clear the uc
    End Sub

End Class