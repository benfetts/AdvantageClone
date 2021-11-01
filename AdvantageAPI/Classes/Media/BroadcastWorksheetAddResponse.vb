<DataContract>
Public Class BroadcastWorksheetAddResponse

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
    Public Property IsSuccessful As Boolean
    <DataMember>
    Public Property WorksheetID As Integer

#End Region

#Region " Methods "

    Friend Sub New()

        Me.Message = String.Empty
        Me.IsSuccessful = False
        Me.WorksheetID = 0

    End Sub

#End Region

End Class
