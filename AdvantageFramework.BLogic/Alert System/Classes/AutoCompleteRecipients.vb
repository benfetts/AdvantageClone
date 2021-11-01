Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AutoCompleteRecipients

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Code As String
        Public Property FullName As String
        Public Property IsEmployee As Boolean?
        Public Property IsClientContact As Boolean?
        Public Property InAlertGroup As Boolean?
        Public Property ConceptShareUserID As Integer?
        Public Property IsConceptShareUser As Boolean?
        Public Property Picture As Byte()

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
