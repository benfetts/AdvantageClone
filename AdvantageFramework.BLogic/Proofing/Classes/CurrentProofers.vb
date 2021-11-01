Namespace Proofing.Classes
    <Serializable()> Public Class CurrentProofers
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property ID As Integer?
        Public Property AlertStateID As Integer?
        Public Property AlertStateName As String
        Public Property EmployeeCode As String
        Public Property EmployeeName As String
        Public Property ProofingStatusID As Integer?
        Public Property ProofingStatus As String
        Public Property ApproveDate As DateTime?
        Public Property IsCurrentState As Boolean?
        Public Property DocumentID As Integer?
        Public Property TotalMarkupCount As Integer? = 0
        Public Property CanDelete As Boolean? = False
        Public ReadOnly Property DateString As String
            Get
                If ApproveDate IsNot Nothing Then

                    Return CDate(ApproveDate).ToShortDateString() & " " & CDate(ApproveDate).ToShortTimeString()

                Else

                    Return ""

                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region


    End Class

End Namespace
