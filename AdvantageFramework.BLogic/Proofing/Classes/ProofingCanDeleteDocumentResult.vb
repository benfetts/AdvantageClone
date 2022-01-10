Namespace Proofing.Classes
    <Serializable>
    Public Class ProofingCanDeleteDocumentResult

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum Properties

            CanDelete
            Message

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        Public Property CanDelete As Boolean? = True
        Public Property Message As String = String.Empty
        Public Property CanDeleteMessage As String = String.Empty
        Public Property TotalMarkupCount As Integer? = 0
        Public Property TotalCommentCount As Integer? = 0
        Public Property ApprovalCount As Integer? = 0


#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class

End Namespace
