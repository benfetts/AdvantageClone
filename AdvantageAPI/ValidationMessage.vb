<DataContract>
Public Class ValidationMessage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property Message As String
    <DataMember>
    Public Property IsValid As Boolean

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
    Friend Sub New(ByVal Message As String, ByVal IsValid As Boolean)

        Me.Message = Message
        Me.IsValid = IsValid

    End Sub

#End Region

End Class
