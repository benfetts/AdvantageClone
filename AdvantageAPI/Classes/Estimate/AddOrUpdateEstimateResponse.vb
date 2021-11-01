<DataContract>
Public Class AddOrUpdateEstimateResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property ID As Integer
    <DataMember>
	Public Property Message As String
	<DataMember>
	Public Property IsSuccessful As Boolean
	<DataMember>
	Public Property EstimateNumber As Integer
	<DataMember>
	Public Property EstimateComponentNumber As Integer
	<DataMember>
	Public Property EstimateQuoteNumber As Integer
	<DataMember>
	Public Property EstimateRevisionNumber As Integer

#End Region

#Region " Methods "

	Friend Sub New()

		Me.Message = String.Empty
		Me.IsSuccessful = False

	End Sub

#End Region

End Class
