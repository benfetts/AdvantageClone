<DataContract>
Public Class JobDetailItemAPIResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    'Force Update
    <DataMember>
    Public Property Message As String = "Success..."
    <DataMember>
    Public Property IsSuccessful As Boolean = True
    <DataMember>
    Public Property Results As Generic.List(Of JobDetailItemAPIReport)

#End Region

#Region " Methods "



#End Region

End Class
