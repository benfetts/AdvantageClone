Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableMediaImportAlert
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            VendorCode
            VendorName
            OrderNumber
            EmployeeCode
        End Enum

#End Region

#Region " Variables "

#End Region

#Region " Properties "

        Public Property InvoiceNumber As String
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property OrderNumber As Integer
        Public Property EmployeeCode As String

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
