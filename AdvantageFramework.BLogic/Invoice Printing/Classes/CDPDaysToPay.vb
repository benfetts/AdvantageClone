Namespace InvoicePrinting.Classes

    Public Class CDPDaysToPay

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            DivisionCode
            ProductCode
            ClientDaysToPay
            ProductDaysToPay
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property ClientDaysToPay As Short
        Public Property ProductDaysToPay As Short


#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.DivisionCode = String.Empty
            Me.ProductCode = String.Empty
            Me.ClientDaysToPay = 0
            Me.ProductDaysToPay = 0

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode & " - " & Me.DivisionCode & " - " & Me.ProductCode

        End Function

#End Region

    End Class

End Namespace

