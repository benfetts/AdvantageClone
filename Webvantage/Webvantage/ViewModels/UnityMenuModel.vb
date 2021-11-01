Namespace ViewModels

    Public Class UnityMenuModel

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Public Property TargetTag As String = "body"
        Public Property CurrentPrintPage As String = ""
        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0
        Public Property EstimateNumber As Integer = 0
        Public Property EstimateComponentNumber As Integer = 0
        Public Property EstimatingQuoteDelimitedString As String = ""
        Public Property AlertID As Integer = 0
        Public Property TaskSequenceNumber As Integer = -1
        Public Property BillingApprovalBatchID As Integer = 0
        Public Property BillingApprovalID As Integer = 0
        Public Property ConceptShareReviewID As Integer = 0

        'Menu Items
        Public Property NewAlert As UnityMenuItem
        Public Property NewAssignment As UnityMenuItem
        Public Property NewProof As UnityMenuItem
        Public Property NewJob As UnityMenuItem
        Public Property JobJacket As UnityMenuItem
        Public Property JobJacketAlerts As UnityMenuItem
        Public Property JobJacketDocuments As UnityMenuItem
        Public Property JobJacketCreativeBrief As UnityMenuItem
        Public Property JobJacketSpecifications As UnityMenuItem
        Public Property JobJacketVersions As UnityMenuItem
        Public Property JobJacketEstimates As UnityMenuItem
        Public Property JobJacketSchedule As UnityMenuItem
        Public Property JobJacketBoards As UnityMenuItem
        Public Property JobJacketQvA As UnityMenuItem
        Public Property JobJacketPurchaseOrders As UnityMenuItem
        Public Property JobJacketEvents As UnityMenuItem
        Public Property JobJacketProofs As UnityMenuItem
        Public Property JobJacketSnapshot As UnityMenuItem
        Public Property AddTime As UnityMenuItem
        Public Property Stopwatch As UnityMenuItem
        Public Property Print As UnityMenuItem
        Public Property SendAlert As UnityMenuItem
        Public Property SendAssignment As UnityMenuItem
        Public Property SendEmail As UnityMenuItem
        Public Property PrintSendOptions As UnityMenuItem

#End Region

#Region " Methods "

        Public Sub New()

            Me.NewAlert = New UnityMenuItem With {.Text = "New Alert"}
            Me.NewAssignment = New UnityMenuItem With {.Text = "New Assignment"}
            Me.NewJob = New UnityMenuItem With {.Text = "New Job"}
            Me.JobJacket = New UnityMenuItem With {.Text = "Job Jacket"}
            Me.JobJacketAlerts = New UnityMenuItem With {.Text = "Alerts"}
            Me.JobJacketDocuments = New UnityMenuItem With {.Text = "Documents"}
            Me.JobJacketCreativeBrief = New UnityMenuItem With {.Text = "Creative Brief"}
            Me.JobJacketSpecifications = New UnityMenuItem With {.Text = "Specifications"}
            Me.JobJacketVersions = New UnityMenuItem With {.Text = "Versions"}
            Me.JobJacketEstimates = New UnityMenuItem With {.Text = "Estimates"}
            Me.JobJacketSchedule = New UnityMenuItem With {.Text = "Schedule"}
            Me.JobJacketBoards = New UnityMenuItem With {.Text = "Boards"}
            Me.JobJacketQvA = New UnityMenuItem With {.Text = "QvA"}
            Me.JobJacketPurchaseOrders = New UnityMenuItem With {.Text = "Purchase Orders"}
            Me.JobJacketEvents = New UnityMenuItem With {.Text = "Events"}
            Me.JobJacketProofs = New UnityMenuItem With {.Text = "Proofs"}
            Me.JobJacketSnapshot = New UnityMenuItem With {.Text = "Snapshot"}
            Me.AddTime = New UnityMenuItem With {.Text = "Add Time"}
            Me.Stopwatch = New UnityMenuItem With {.Text = "Stopwatch"}
            Me.Print = New UnityMenuItem With {.Text = "Print"}
            Me.SendAlert = New UnityMenuItem With {.Text = "Send Alert"}
            Me.SendAssignment = New UnityMenuItem With {.Text = "Send Assignment"}
            Me.SendEmail = New UnityMenuItem With {.Text = "Send Email"}
            Me.PrintSendOptions = New UnityMenuItem With {.Text = "Print/Send Options"}

        End Sub

#End Region

        Public Class UnityMenuItem

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

            Private _Url As String = Nothing

#End Region

#Region " Properties "

            Public Property Visible As Boolean
            Public Property Text As String

#End Region

#Region " Methods "

            Public Sub New()

                Me.Visible = True
                Me.Text = ""

            End Sub

#End Region

        End Class

    End Class

End Namespace

