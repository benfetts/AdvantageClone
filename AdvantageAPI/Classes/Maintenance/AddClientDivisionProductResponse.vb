<DataContract>
Public Class AddClientDivisionProductResponse

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
    Public Property ClientCode As String
    <DataMember>
    Public Property DivisionCode As String
    <DataMember>
    Public Property ProductCode As String

#End Region

#Region " Methods "

    Friend Sub New()

		Me.Message = String.Empty
		Me.IsSuccessful = False

	End Sub

#End Region

End Class