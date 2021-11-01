Namespace JobForecast.Classes

    <Serializable()>
    Public Class JobForecastActual

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            OfficeCode
            OfficeDescription
            CampaignID
            CampaignCode
            CampaignDescription
            SalesClassCode
            SalesClassDescription
            FunctionCode
            FunctionDescription
            ActualBillableNetAmount
            ActualBillableMarkupAmount
            ActualBillableAmount
            ActualRevenueAmount
            FunctionType
            ItemID
            ItemDate
            ItemPostPeriodCode
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _ComponentDescription As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _ActualBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableAmount As Nullable(Of Decimal) = Nothing
        Private _ActualRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _FunctionType As String = Nothing
        Private _ItemID As Nullable(Of Integer) = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _ItemPostPeriodCode As String = Nothing

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
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
                Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Short)
                _ComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
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
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignDescription() As String
            Get
                CampaignDescription = _CampaignDescription
            End Get
            Set(value As String)
                _CampaignDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
                Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableNetAmount() As Nullable(Of Decimal)
            Get
                ActualBillableNetAmount = _ActualBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                ActualBillableMarkupAmount = _ActualBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableAmount() As Nullable(Of Decimal)
            Get
                ActualBillableAmount = _ActualBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualRevenueAmount() As Nullable(Of Decimal)
            Get
                ActualRevenueAmount = _ActualRevenueAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualRevenueAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ItemID() As Nullable(Of Integer)
            Get
                ItemID = _ItemID
            End Get
            Set(value As Nullable(Of Integer))
                _ItemID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemPostPeriodCode() As String
            Get
                ItemPostPeriodCode = _ItemPostPeriodCode
            End Get
            Set(value As String)
                _ItemPostPeriodCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
