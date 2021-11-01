Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableExpenseReportsForImport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            Status
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _Status As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Status As Integer
            Get
                Status = _Status
            End Get
            Set(ByVal value As Integer)
                _Status = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = _InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace

