<DataContract>
Public Class APIReponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<DataMember>
	Public Property Successful As Boolean
	<DataMember>
    Public Property ErrorMessage As String

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
	Friend Sub New(Successful As Boolean, ErrorMessage As String)

		Me.Successful = Successful
		Me.ErrorMessage = ErrorMessage

	End Sub

#End Region

End Class
