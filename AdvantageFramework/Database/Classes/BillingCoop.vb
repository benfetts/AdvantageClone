Namespace Database.Classes

    <Serializable()>
    Public Class BillingCoop

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            BillCoop
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            Percent
        End Enum

#End Region

#Region " Variables "

        Private _BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Code As String
            Get
                Code = _BillingCoop.Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BillCoop As String
            Get
                BillCoop = _BillingCoop.ToString
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeName As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductName As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3")>
        Public Property Percent As Decimal
            Get
                Percent = _BillingCoop.Percent
            End Get
            Set(ByVal value As Decimal)
                _BillingCoop.Percent = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal BillingCoop As AdvantageFramework.Database.Entities.BillingCoop)

            _BillingCoop = BillingCoop

        End Sub
        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function
        Public Function GetBillingCoop() As AdvantageFramework.Database.Entities.BillingCoop

            GetBillingCoop = _BillingCoop

        End Function

#End Region

    End Class

End Namespace

