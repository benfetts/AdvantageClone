Imports System.Web

Namespace Web.Classes

    <Serializable()> _
    Public Class ContentPageData

        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Integer = 0

        Public Property EstimateNumber As Integer = 0
        Public Property EstimateComponentNumber As Integer = 0
        Public Property EstimateSelectedQuoteNumbers As String = ""
        Public Property EstimateSelectedQuoteDescriptions As String = ""
        Public Property EstimatePrintSendAll As Boolean = False

        Public Property JobSpecDescription As String = ""
        Public Property JobSpecReason As String = ""
        Public Property JobSpecTitle As String = ""
        Public Property JobSpecVersionID As Integer = 0
        Public Property JobSpecRevisionID As Integer = 0

        Public Property JobVersionHeaderID As Integer = 0
        Public Property JobVersionSequenceNumber As Integer = 0

        Public Property PurchaseOrderNumber As String = ""
        Public Property PurchaseOrderCallingPageMode As String = ""
        Public Property PurchaseOrderNeedsApprovalAndApprove As Boolean = False
        Public Property PurchaseOrderPad As String = ""
        Public Property PurchaseOrderRuleCode As String = ""
        Public Property PurchaseOrderEmployeeCode As String = ""

        Public Sub Save()

            HttpContext.Current.Session("ContentPageData") = Me

        End Sub
        Public Function Load()

            If HttpContext.Current.Session("ContentPageData") IsNot Nothing Then

                Dim this As New ContentPageData
                this = CType(HttpContext.Current.Session("ContentPageData"), ContentPageData)

                Me.JobNumber = this.JobNumber
                Me.JobComponentNumber = this.JobComponentNumber

                Me.EstimateNumber = this.EstimateNumber
                Me.EstimateComponentNumber = this.EstimateComponentNumber
                Me.EstimateSelectedQuoteNumbers = this.EstimateSelectedQuoteNumbers
                Me.EstimateSelectedQuoteDescriptions = this.EstimateSelectedQuoteDescriptions
                Me.EstimatePrintSendAll = this.EstimatePrintSendAll

                Me.JobSpecDescription = this.JobSpecDescription
                Me.JobSpecReason = this.JobSpecReason
                Me.JobSpecTitle = this.JobSpecTitle
                Me.JobSpecVersionID = this.JobSpecVersionID
                Me.JobSpecRevisionID = this.JobSpecRevisionID

                Me.JobVersionHeaderID = this.JobVersionHeaderID
                Me.JobVersionSequenceNumber = this.JobVersionSequenceNumber

                Me.PurchaseOrderNumber = this.PurchaseOrderNumber
                Me.PurchaseOrderCallingPageMode = this.PurchaseOrderCallingPageMode
                Me.PurchaseOrderNeedsApprovalAndApprove = this.PurchaseOrderNeedsApprovalAndApprove
                Me.PurchaseOrderPad = this.PurchaseOrderPad
                Me.PurchaseOrderRuleCode = this.PurchaseOrderRuleCode

                Me.PurchaseOrderEmployeeCode = this.PurchaseOrderEmployeeCode

                Return True

            Else

                Return False

            End If

        End Function
        Public Sub Clear()

            HttpContext.Current.Session("ContentPageData") = Nothing

        End Sub
        Sub New()

        End Sub

    End Class

End Namespace
