Namespace AccountReceivable.Classes

    <Serializable()>
    Public Class ClientInvoiceBatchReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeCode
            OfficeName
            GLACodeAR
            GLACodeARDescription
            GLACodeSales
            GLACodeSalesDescription
            GLACodeCOS
            GLACodeCOSDescription
            GLACodeOffset
            GLACodeOffsetDescription
            GLACodeState
            GLACodeStateDescription
            GLACodeCounty
            GLACodeCountyDescription
            GLACodeCity
            GLACodeCityDescription
            InvoiceNumber
            [Description]
            PostPeriodCode
            GLTransaction
            InvoiceDate
            InvoiceAmount
            CostOfSalesAmount
            StateAmount
            CountyAmount
            CityAmount
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _GLACodeAR As String = Nothing
        Private _GLACodeARDescription As String = Nothing
        Private _GLACodeSales As String = Nothing
        Private _GLACodeSalesDescription As String = Nothing
        Private _GLACodeCOS As String = Nothing
        Private _GLACodeCOSDescription As String = Nothing
        Private _GLACodeOffset As String = Nothing
        Private _GLACodeOffsetDescription As String = Nothing
        Private _GLACodeState As String = Nothing
        Private _GLACodeStateDescription As String = Nothing
        Private _GLACodeCounty As String = Nothing
        Private _GLACodeCountyDescription As String = Nothing
        Private _GLACodeCity As String = Nothing
        Private _GLACodeCityDescription As String = Nothing
        Private _InvoiceNumber As Integer = Nothing
        Private _Description As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _GLTransaction As Integer = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceAmount As Decimal = Nothing
        Private _CostOfSalesAmount As Decimal = Nothing
        Private _StateAmount As Decimal = Nothing
        Private _CountyAmount As Decimal = Nothing
        Private _CityAmount As Decimal = Nothing
        Private _SalesAmount As Decimal = Nothing
        Private _GrossProfit As Decimal = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeAR() As String
            Get
                GLACodeAR = _GLACodeAR
            End Get
            Set(value As String)
                _GLACodeAR = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeARDescription() As String
            Get
                GLACodeARDescription = _GLACodeARDescription
            End Get
            Set(value As String)
                _GLACodeARDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeSales() As String
            Get
                GLACodeSales = _GLACodeSales
            End Get
            Set(value As String)
                _GLACodeSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeSalesDescription() As String
            Get
                GLACodeSalesDescription = _GLACodeSalesDescription
            End Get
            Set(value As String)
                _GLACodeSalesDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeCOS() As String
            Get
                GLACodeCOS = _GLACodeCOS
            End Get
            Set(value As String)
                _GLACodeCOS = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeCOSDescription() As String
            Get
                GLACodeCOSDescription = _GLACodeCOSDescription
            End Get
            Set(value As String)
                _GLACodeCOSDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeOffset() As String
            Get
                GLACodeOffset = _GLACodeOffset
            End Get
            Set(value As String)
                _GLACodeOffset = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeOffsetDescription() As String
            Get
                GLACodeOffsetDescription = _GLACodeOffsetDescription
            End Get
            Set(value As String)
                _GLACodeOffsetDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeState() As String
            Get
                GLACodeState = _GLACodeState
            End Get
            Set(value As String)
                _GLACodeState = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeStateDescription() As String
            Get
                GLACodeStateDescription = _GLACodeStateDescription
            End Get
            Set(value As String)
                _GLACodeStateDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeCounty() As String
            Get
                GLACodeCounty = _GLACodeCounty
            End Get
            Set(value As String)
                _GLACodeCounty = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeCountyDescription() As String
            Get
                GLACodeCountyDescription = _GLACodeCountyDescription
            End Get
            Set(value As String)
                _GLACodeCountyDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeCity() As String
            Get
                GLACodeCity = _GLACodeCity
            End Get
            Set(value As String)
                _GLACodeCity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACodeCityDescription() As String
            Get
                GLACodeCityDescription = _GLACodeCityDescription
            End Get
            Set(value As String)
                _GLACodeCityDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLTransaction() As Integer
            Get
                GLTransaction = _GLTransaction
            End Get
            Set(value As Integer)
                _GLTransaction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceAmount() As Decimal
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(value As Decimal)
                _InvoiceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CostOfSalesAmount() As Decimal
            Get
                CostOfSalesAmount = _CostOfSalesAmount
            End Get
            Set(value As Decimal)
                _CostOfSalesAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StateAmount() As Decimal
            Get
                StateAmount = _StateAmount
            End Get
            Set(value As Decimal)
                _StateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CountyAmount() As Decimal
            Get
                CountyAmount = _CountyAmount
            End Get
            Set(value As Decimal)
                _CountyAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CityAmount() As Decimal
            Get
                CityAmount = _CityAmount
            End Get
            Set(value As Decimal)
                _CityAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesAmount() As Decimal
            Get
                SalesAmount = _SalesAmount
            End Get
            Set(value As Decimal)
                _SalesAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GrossProfit() As Decimal
            Get
                GrossProfit = _GrossProfit
            End Get
            Set(value As Decimal)
                _GrossProfit = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

