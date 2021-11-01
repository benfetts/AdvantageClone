Namespace ConceptShare.Classes

    <Serializable()>
    Public Class APIResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CompletedSuccessfully As Boolean
        Public Property ErrorMessage As String

#End Region

#Region " Methods "

        Public Sub New()

            CompletedSuccessfully = False
            ErrorMessage = ""

        End Sub

#End Region

    End Class

End Namespace
