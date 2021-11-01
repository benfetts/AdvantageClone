Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class SaveEmployeeTimeReponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeTimeID As Integer

        Public Property EmployeeTimeDetailID As Integer

        Public Property Message As String

        Public Property SaveSuccessful As Integer

        Public Property BillingRate As Decimal

        Public Property IsNonBillable As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal Message As String, ByVal SaveSuccessful As Integer)

            Me.EmployeeTimeID = EmployeeTimeID
            Me.EmployeeTimeDetailID = EmployeeTimeDetailID
            Me.Message = Message
            Me.SaveSuccessful = SaveSuccessful

        End Sub

#End Region

    End Class

End Namespace

