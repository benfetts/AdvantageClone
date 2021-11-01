Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableVendorSearchOrders
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            VendorName
            VendorCode
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _VendorName As String = Nothing
        Private _VendorCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Number() As Integer
            Get
                Number = _Number
            End Get
            Set(ByVal value As Integer)
                _Number = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
