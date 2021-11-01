Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableProductionPurchaseOrders
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Description
            [Date]
            DueDate
            Status
            POTotal
            POBalance
            WorkComplete
            VendorCode
            POComplete
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _Description As String = Nothing
        Private _Date As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing
        Private _Status As String = Nothing
        Private _POTotal As Nullable(Of Decimal) = Nothing
        Private _POBalance As Nullable(Of Decimal) = Nothing
        Private _WorkComplete As String = Nothing
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
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property [Date]() As Nullable(Of Date)
            Get
                [Date] = _Date
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Date = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property POTotal() As Nullable(Of Decimal)
            Get
                POTotal = _POTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property POBalance() As Nullable(Of Decimal)
            Get
                POBalance = _POBalance
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POBalance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property WorkComplete() As String
            Get
                WorkComplete = _WorkComplete
            End Get
            Set(ByVal value As String)
                _WorkComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property POComplete() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
