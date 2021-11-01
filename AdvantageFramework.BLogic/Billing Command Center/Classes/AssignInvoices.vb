Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class AssignInvoices

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ReturnValue
            ARInvoiceNumber
        End Enum

#End Region

#Region " Variables "

        Private _ReturnValue As Integer = Nothing
        Private _ARInvoiceNumber As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ReturnValue() As Integer
            Get
                ReturnValue = _ReturnValue
            End Get
            Set(value As Integer)
                _ReturnValue = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ARInvoiceNumber() As Integer
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(value As Integer)
                _ARInvoiceNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace