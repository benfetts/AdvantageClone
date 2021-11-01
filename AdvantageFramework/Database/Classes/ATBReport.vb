Namespace Database.Classes

    <Serializable()>
    Public Class ATBReport
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ATBNumber
            ATBDescription
            RevisionNumber
            DateOfRequest
            CampaignID
            CampaignCode
            CampaignName
            StartDate
            EndDate
            ClientBudget
            BuyGrossOrNet
            SalesClassCode
            SalesClassDescription
            Comment
            BillingComment
            BillingDate
            ClientPO
            BillingMethod
            CreatedDate
            ModifiedDate
            CreatedByUserCode
            ModifiedByUserCode
            ApprovedByUserCode
            ApprovedDate
            VendorCode
            VendorName
            Quantity
            Rate
            CostType
            Amount
            MarkupAmount
            NetSpend
            LineTotal
            OrderID
            OrderLineID
            OrderLineNumber
            OrderNumber
            IsClosed
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ClientCode As String = ""
        Private _ClientName As String = ""
        Private _DivisionCode As String = ""
        Private _DivisionName As String = ""
        Private _ProductCode As String = ""
        Private _ProductName As String = ""
        Private _ATBNumber As String = Nothing
        Private _ATBDescription As String = ""
        Private _RevisionNumber As String = ""
        Private _DateOfRequest As System.Nullable(Of DateTime) = Nothing
        Private _CampaignID As System.Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = ""
        Private _CampaignName As String = ""
        Private _StartDate As System.Nullable(Of DateTime) = Nothing
        Private _EndDate As System.Nullable(Of DateTime) = Nothing
        Private _ClientBudget As System.Nullable(Of Decimal) = Nothing
        Private _BuyGrossOrNet As String = ""
        Private _SalesClassCode As String = ""
        Private _SalesClassDescription As String = ""
        Private _Comment As String = ""
        Private _BillingComment As String = ""
        Private _BillingDate As System.Nullable(Of DateTime) = Nothing
        Private _ClientPO As String = ""
        Private _BillingMethod As String = ""
        Private _CreatedDate As System.Nullable(Of DateTime) = Nothing
        Private _ModifiedDate As System.Nullable(Of DateTime) = Nothing
        Private _CreatedByUserCode As String = ""
        Private _ModifiedByUserCode As String = ""
        Private _ApprovedByUserCode As String = ""
        Private _ApprovedDate As System.Nullable(Of DateTime) = Nothing
        Private _VendorCode As String = ""
        Private _VendorName As String = ""
        Private _Quantity As System.Nullable(Of Integer) = Nothing
        Private _Rate As System.Nullable(Of Decimal) = Nothing
        Private _CostType As String = Nothing
        Private _Amount As System.Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As System.Nullable(Of Decimal) = Nothing
        Private _NetSpend As System.Nullable(Of Decimal) = Nothing
        Private _LineTotal As System.Nullable(Of Decimal) = Nothing
        Private _OrderID As System.Nullable(Of Integer) = Nothing
        Private _OrderLineID As System.Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As System.Nullable(Of Integer) = Nothing
        Private _OrderNumber As System.Nullable(Of Integer) = Nothing
        Private _IsClosed As String = ""

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ATBNumber() As String
            Get
                ATBNumber = _ATBNumber
            End Get
            Set(ByVal value As String)
                _ATBNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ATBDescription() As String
            Get
                ATBDescription = _ATBDescription
            End Get
            Set(ByVal value As String)
                _ATBDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionNumber() As String
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(ByVal value As String)
                _RevisionNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateOfRequest() As System.Nullable(Of DateTime)
            Get
                DateOfRequest = _DateOfRequest
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _DateOfRequest = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As System.Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As System.Nullable(Of DateTime)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As System.Nullable(Of DateTime)
            Get
                EndDate = _EndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientBudget() As System.Nullable(Of Decimal)
            Get
                ClientBudget = _ClientBudget
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ClientBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BuyGrossOrNet() As String
            Get
                BuyGrossOrNet = _BuyGrossOrNet
            End Get
            Set(ByVal value As String)
                _BuyGrossOrNet = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingComment() As String
            Get
                BillingComment = _BillingComment
            End Get
            Set(ByVal value As String)
                _BillingComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingDate() As System.Nullable(Of DateTime)
            Get
                BillingDate = _BillingDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _BillingDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingMethod() As String
            Get
                BillingMethod = _BillingMethod
            End Get
            Set(ByVal value As String)
                _BillingMethod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As System.Nullable(Of DateTime)
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _CreatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As System.Nullable(Of DateTime)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _ModifiedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
            Get
                CreatedByUserCode = _CreatedByUserCode
            End Get
            Set(ByVal value As String)
                _CreatedByUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _ModifiedByUserCode
            End Get
            Set(ByVal value As String)
                _ModifiedByUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedByUserCode() As String
            Get
                ApprovedByUserCode = _ApprovedByUserCode
            End Get
            Set(ByVal value As String)
                _ApprovedByUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedDate() As System.Nullable(Of DateTime)
            Get
                ApprovedDate = _ApprovedDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _ApprovedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As System.Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property Rate() As System.Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set(ByVal value As String)
                _CostType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Amount() As System.Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MarkupAmount() As System.Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetSpend() As System.Nullable(Of Decimal)
            Get
                NetSpend = _NetSpend
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _NetSpend = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property LineTotal() As System.Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DisplayFormat:="f0")>
        Public Property OrderID() As System.Nullable(Of Integer)
            Get
                OrderID = _OrderID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _OrderID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DisplayFormat:="f0")>
        Public Property OrderLineID() As System.Nullable(Of Integer)
            Get
                OrderLineID = _OrderLineID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _OrderLineID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DisplayFormat:="f0")>
        Public Property OrderLineNumber() As System.Nullable(Of Integer)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _OrderLineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DisplayFormat:="f0")>
        Public Property OrderNumber() As System.Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsClosed() As String
            Get
                IsClosed = _IsClosed
            End Get
            Set(ByVal value As String)
                _IsClosed = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
