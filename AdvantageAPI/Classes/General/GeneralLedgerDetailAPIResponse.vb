<DataContract>
Public Class GeneralLedgerDetailAPIResponse

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
    Public Property Results As List(Of GeneralLedgerDetailAPIReport)

#End Region

#Region " Methods "



#End Region

End Class
