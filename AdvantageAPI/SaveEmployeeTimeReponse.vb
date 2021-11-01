<DataContract>
Public Class SaveEmployeeTimeReponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property EmployeeTimeID As Integer
    <DataMember>
    Public Property EmployeeTimeDetailID As Integer
    <DataMember>
    Public Property Message As String
    <DataMember>
    Public Property SaveSuccessful As Integer
    <DataMember>
    Public Property BillingRate As Decimal
    <DataMember>
    Public Property IsNonBillable As Boolean

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
    Friend Sub New(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal Message As String, ByVal SaveSuccessful As Integer)

        Me.EmployeeTimeID = EmployeeTimeID
        Me.EmployeeTimeDetailID = EmployeeTimeDetailID
        Me.Message = Message
        Me.SaveSuccessful = SaveSuccessful

    End Sub
    Friend Sub UpdateProperties(SaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse)

        Me.EmployeeTimeID = SaveEmployeeTimeReponse.EmployeeTimeID
        Me.EmployeeTimeDetailID = SaveEmployeeTimeReponse.EmployeeTimeDetailID
        Me.Message = SaveEmployeeTimeReponse.Message
        Me.SaveSuccessful = SaveEmployeeTimeReponse.SaveSuccessful
        Me.BillingRate = SaveEmployeeTimeReponse.BillingRate
        Me.IsNonBillable = SaveEmployeeTimeReponse.IsNonBillable

    End Sub

#End Region

End Class
