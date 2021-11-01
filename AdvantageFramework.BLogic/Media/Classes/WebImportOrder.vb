Namespace Media.Classes

    <Serializable()>
    Public Class WebImportOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderID
            LineNumber
            RevNbr
            MediaType
            MediaPlanOrderDescription
            LineDescription
            ClientCode
            DivisionCode
            ProductCode
            VendorCode
            StartDate
            EndDate
            NetGross
            NetRate
            GrossRate
            TotalSpots
            CostType
            SalesClassCode
            Cost
            NetCharge
            AddAmount
            MarkupPercent
            CampaignCode
            MediaNetAmount
            ClientPO
            RateType
            ImportAccountPayableMediaID
            MediaPlanDetailLevelLineDataIDs
            MediaPlanOrderComment
            'MediaPlanBuyer
            MediaPlanMarketCode
            MediaPlanMarketDescription
            MediaPlanAdSizeCode
            MediaPlanAdSizeDescription
            MediaPlanAdNumber
            MediaPlanHeadline
            MediaPlanIssue
            MediaPlanInternetType
            MediaPlanPlacement
            MediaPlanOutOfHomeType
            MediaPlanDaypart
            MediaPlanStartTime
            MediaPlanEndTime
            MediaPlanLength
            MediaPlanProgramming
            MediaPlanNetworkCode
            'IsSourceMediaPlanning
            IsRevision
            MediaPlanAirDate
            ImportSource
            OrderNumber
            OrderLineNumber
        End Enum

#End Region

#Region " Variables "

        Private _OrderID As Nullable(Of Integer) = Nothing
        Private _LineNumber As Nullable(Of Short) = Nothing
        Private _LineDescription As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _NetGross As Nullable(Of Integer) = Nothing
        Private _CommPct As Nullable(Of Decimal) = Nothing
        Private _NetRate As Nullable(Of Decimal) = Nothing
        Private _GrossRate As Nullable(Of Decimal) = Nothing
        Private _TotalSpots As Nullable(Of Integer) = Nothing
        Private _ImportAccountPayableMediaID As Nullable(Of Integer) = Nothing
        Private _RateType As String = Nothing
        Private _CostType As String = Nothing
        Private _Cost As Nullable(Of Decimal) = Nothing
        Private _MediaNetAmount As Nullable(Of Decimal) = Nothing
        Private _Columns As Nullable(Of Decimal) = Nothing
        Private _Inches As Nullable(Of Decimal) = Nothing
        Private _LinesCirculation As Nullable(Of Integer) = Nothing
        Private _NetCharge As Nullable(Of Decimal) = Nothing
        Private _AddAmount As Nullable(Of Decimal) = Nothing
        Private _MarkupPercent As Nullable(Of Decimal) = Nothing
        Private _CampaignCode As String = Nothing
        Private _ClientPO As String = Nothing
        Private _MediaPlanDetailLevelLineDataIDs As String = Nothing
        Private _MediaPlanOrderDescription As String = Nothing
        Private _MediaPlanOrderComment As String = Nothing
        'Private _MediaPlanBuyer As String = Nothing
        Private _MediaPlanMarketCode As String = Nothing
        Private _MediaPlanMarketDescription As String = Nothing
        Private _MediaPlanAdSizeCode As String = Nothing
        Private _MediaPlanAdSizeDescription As String = Nothing
        Private _MediaPlanAdNumber As String = Nothing
        Private _MediaPlanHeadline As String = Nothing
        Private _MediaPlanIssue As String = Nothing
        Private _MediaPlanInternetType As String = Nothing
        Private _MediaPlanPlacement As String = Nothing
        Private _MediaPlanOutOfHomeType As String = Nothing
        Private _MediaPlanDaypart As String = Nothing
        Private _MediaPlanStartTime As String = Nothing
        Private _MediaPlanEndTime As String = Nothing
        Private _MediaPlanLength As String = Nothing
        Private _MediaPlanProgramming As String = Nothing
        Private _MediaPlanNetworkCode As String = Nothing
        'Private _IsSourceMediaPlanning As Boolean = False
        Private _IsRevision As Boolean = False
        Private _MediaPlanAirDate As Nullable(Of Date) = Nothing
        Private _ImportSource As AdvantageFramework.Media.ImportSource = Methods.ImportSource.Default
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderID() As Nullable(Of Integer)
            Get
                OrderID = _OrderID
            End Get
            Set(value As Nullable(Of Integer))
                _OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public ReadOnly Property RevNbr() As Integer
            Get
                RevNbr = 0
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Order Description")>
        Public Property MediaPlanOrderDescription() As String
            Get
                MediaPlanOrderDescription = _MediaPlanOrderDescription
            End Get
            Set(value As String)
                _MediaPlanOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Line Description")>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(value As String)
                _LineDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.VendorCode, CustomColumnCaption:="Vendor")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NetGross() As Nullable(Of Integer)
            Get
                NetGross = _NetGross
            End Get
            Set(value As Nullable(Of Integer))
                _NetGross = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4", IsReadOnlyColumn:=True)>
        Public Property NetRate() As Nullable(Of Decimal)
            Get
                NetRate = _NetRate
            End Get
            Set(value As Nullable(Of Decimal))
                _NetRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4", IsReadOnlyColumn:=True)>
        Public Property GrossRate() As Nullable(Of Decimal)
            Get
                GrossRate = _GrossRate
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Quantity")>
        Public Property TotalSpots() As Nullable(Of Integer)
            Get
                TotalSpots = _TotalSpots
            End Get
            Set(value As Nullable(Of Integer))
                _TotalSpots = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set(value As String)
                _CostType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public ReadOnly Property Cost() As Nullable(Of Decimal)
            Get
                If Me.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then
                    _Cost = Me.TotalSpots * Me.NetRate / 1000
                Else
                    _Cost = _MediaNetAmount
                End If
                Cost = _Cost
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property NetCharge() As Nullable(Of Decimal)
            Get
                NetCharge = _NetCharge
            End Get
            Set(value As Nullable(Of Decimal))
                _NetCharge = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Agency Fee")>
        Public Property AddAmount() As Nullable(Of Decimal)
            Get
                AddAmount = _AddAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AddAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Markup Percent")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaNetAmount() As Nullable(Of Decimal)
            Get
                MediaNetAmount = _MediaNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MediaNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property RateType() As String
            Get
                If _RateType Is Nothing Then

                    If Me.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then

                        _RateType = "CPM"

                    Else

                        _RateType = "STD"

                    End If

                End If
                RateType = _RateType
            End Get
            Set(value As String)
                _RateType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableMediaID() As Nullable(Of Integer)
            Get
                ImportAccountPayableMediaID = _ImportAccountPayableMediaID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailLevelLineDataIDs() As String
            Get
                MediaPlanDetailLevelLineDataIDs = _MediaPlanDetailLevelLineDataIDs
            End Get
            Set(value As String)
                _MediaPlanDetailLevelLineDataIDs = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanOrderComment() As String
            Get
                MediaPlanOrderComment = _MediaPlanOrderComment
            End Get
            Set(value As String)
                _MediaPlanOrderComment = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public Property MediaPlanBuyer() As String
        '    Get
        '        MediaPlanBuyer = _MediaPlanBuyer
        '    End Get
        '    Set(value As String)
        '        _MediaPlanBuyer = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanMarketCode() As String
            Get
                MediaPlanMarketCode = _MediaPlanMarketCode
            End Get
            Set(value As String)
                _MediaPlanMarketCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanMarketDescription() As String
            Get
                MediaPlanMarketDescription = _MediaPlanMarketDescription
            End Get
            Set(value As String)
                _MediaPlanMarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanAdSizeCode() As String
            Get
                MediaPlanAdSizeCode = _MediaPlanAdSizeCode
            End Get
            Set(value As String)
                _MediaPlanAdSizeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanAdSizeDescription() As String
            Get
                MediaPlanAdSizeDescription = _MediaPlanAdSizeDescription
            End Get
            Set(value As String)
                _MediaPlanAdSizeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanAdNumber() As String
            Get
                MediaPlanAdNumber = _MediaPlanAdNumber
            End Get
            Set(value As String)
                _MediaPlanAdNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanHeadline() As String
            Get
                MediaPlanHeadline = _MediaPlanHeadline
            End Get
            Set(value As String)
                _MediaPlanHeadline = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanIssue() As String
            Get
                MediaPlanIssue = _MediaPlanIssue
            End Get
            Set(value As String)
                _MediaPlanIssue = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanInternetType() As String
            Get
                MediaPlanInternetType = _MediaPlanInternetType
            End Get
            Set(value As String)
                _MediaPlanInternetType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanPlacement() As String
            Get
                MediaPlanPlacement = _MediaPlanPlacement
            End Get
            Set(value As String)
                _MediaPlanPlacement = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanOutOfHomeType() As String
            Get
                MediaPlanOutOfHomeType = _MediaPlanOutOfHomeType
            End Get
            Set(value As String)
                _MediaPlanOutOfHomeType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDaypart() As String
            Get
                MediaPlanDaypart = _MediaPlanDaypart
            End Get
            Set(value As String)
                _MediaPlanDaypart = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanStartTime() As String
            Get
                MediaPlanStartTime = _MediaPlanStartTime
            End Get
            Set(value As String)
                _MediaPlanStartTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanEndTime() As String
            Get
                MediaPlanEndTime = _MediaPlanEndTime
            End Get
            Set(value As String)
                _MediaPlanEndTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanLength() As String
            Get
                MediaPlanLength = _MediaPlanLength
            End Get
            Set(value As String)
                _MediaPlanLength = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanProgramming() As String
            Get
                MediaPlanProgramming = _MediaPlanProgramming
            End Get
            Set(value As String)
                _MediaPlanProgramming = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanNetworkCode() As String
            Get
                MediaPlanNetworkCode = _MediaPlanNetworkCode
            End Get
            Set(value As String)
                _MediaPlanNetworkCode = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public Property IsSourceMediaPlanning() As Boolean
        '    Get
        '        IsSourceMediaPlanning = _IsSourceMediaPlanning
        '    End Get
        '    Set(value As Boolean)
        '        _IsSourceMediaPlanning = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsRevision() As Boolean
            Get
                IsRevision = _IsRevision
            End Get
            Set(value As Boolean)
                _IsRevision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanAirDate() As Nullable(Of Date)
            Get
                MediaPlanAirDate = _MediaPlanAirDate
            End Get
            Set(value As Nullable(Of Date))
                _MediaPlanAirDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ImportSource() As AdvantageFramework.Media.ImportSource
            Get
                ImportSource = _ImportSource
            End Get
            Set(value As AdvantageFramework.Media.ImportSource)
                _ImportSource = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderLineNumber() As Nullable(Of Integer)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderLineNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            _OrderID = ImportOrder.OrderID
            _LineNumber = ImportOrder.LineNumber
            _LineDescription = ImportOrder.LineDescription
            _MediaType = ImportOrder.MediaType
            _SalesClassCode = ImportOrder.SalesClassCode
            _ClientCode = ImportOrder.ClientCode
            _DivisionCode = ImportOrder.DivisionCode
            _ProductCode = ImportOrder.ProductCode
            _VendorCode = ImportOrder.VendorCode
            _StartDate = ImportOrder.StartDate
            _EndDate = ImportOrder.EndDate
            _NetGross = ImportOrder.NetGross
            _CommPct = ImportOrder.GetCommPct
            _NetRate = ImportOrder.NetRate
            _GrossRate = ImportOrder.GrossRate
            _TotalSpots = ImportOrder.TotalSpots
            _ImportAccountPayableMediaID = ImportOrder.ImportAccountPayableMediaID
            _RateType = ImportOrder.RateType
            _CostType = ImportOrder.CostType
            _Cost = ImportOrder.Cost
            _MediaNetAmount = ImportOrder.MediaNetAmount
            _Columns = ImportOrder.GetColumns()
            _Inches = ImportOrder.GetInches()
            _LinesCirculation = ImportOrder.GetLinesCirculation()
            _NetCharge = ImportOrder.NetCharge
            _AddAmount = ImportOrder.AddAmount
            _MarkupPercent = ImportOrder.MarkupPercent
            _CampaignCode = ImportOrder.CampaignCode
            _ClientPO = ImportOrder.ClientPO
            _MediaPlanDetailLevelLineDataIDs = ImportOrder.MediaPlanDetailLevelLineDataIDs
            _MediaPlanOrderDescription = ImportOrder.MediaPlanOrderDescription
            _MediaPlanOrderComment = ImportOrder.MediaPlanOrderComment
            '_MediaPlanBuyer = ImportOrder.MediaPlanBuyer
            _MediaPlanMarketCode = ImportOrder.MediaPlanMarketCode
            _MediaPlanMarketDescription = ImportOrder.MediaPlanMarketDescription
            _MediaPlanAdSizeCode = ImportOrder.MediaPlanAdSizeCode
            _MediaPlanAdSizeDescription = ImportOrder.MediaPlanAdSizeDescription
            _MediaPlanAdNumber = ImportOrder.MediaPlanAdNumber
            _MediaPlanHeadline = ImportOrder.MediaPlanHeadline
            _MediaPlanIssue = ImportOrder.MediaPlanIssue
            _MediaPlanInternetType = ImportOrder.MediaPlanInternetType
            _MediaPlanPlacement = ImportOrder.MediaPlanPlacement
            _MediaPlanOutOfHomeType = ImportOrder.MediaPlanOutOfHomeType
            _MediaPlanDaypart = ImportOrder.MediaPlanDaypart
            _MediaPlanStartTime = ImportOrder.MediaPlanStartTime
            _MediaPlanEndTime = ImportOrder.MediaPlanEndTime
            _MediaPlanLength = ImportOrder.MediaPlanLength
            _MediaPlanProgramming = ImportOrder.MediaPlanProgramming
            _MediaPlanNetworkCode = ImportOrder.MediaPlanNetworkCode
            '_IsSourceMediaPlanning = ImportOrder.IsSourceMediaPlanning
            _IsRevision = ImportOrder.IsRevision
            _MediaPlanAirDate = ImportOrder.MediaPlanAirDate
            _ImportSource = ImportOrder.ImportSource
            _OrderNumber = ImportOrder.OrderNumber
            _OrderLineNumber = ImportOrder.OrderLineNumber

            TransferEntityAttributes(ImportOrder, Me)

        End Sub
        Public Function GetImportOrder() As AdvantageFramework.Media.Classes.ImportOrder

            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing

            Try

                ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder(_CommPct, _ImportAccountPayableMediaID, _Cost, _Columns, _Inches, _LinesCirculation)

                With ImportOrder

                    .OrderID = _OrderID
                    .LineNumber = _LineNumber
                    .LineDescription = _LineDescription
                    .MediaType = _MediaType
                    .SalesClassCode = _SalesClassCode
                    .ClientCode = _ClientCode
                    .DivisionCode = _DivisionCode
                    .ProductCode = _ProductCode
                    .VendorCode = _VendorCode
                    .StartDate = _StartDate
                    .EndDate = _EndDate
                    .NetGross = _NetGross
                    '.GetCommPct = _CommPct
                    .NetRate = _NetRate
                    .GrossRate = _GrossRate
                    .TotalSpots = _TotalSpots
                    '.ImportAccountPayableMediaID = _ImportAccountPayableMediaID
                    .RateType = _RateType
                    .CostType = _CostType
                    '.Cost = _Cost
                    .MediaNetAmount = _MediaNetAmount
                    '.GetColumns() = _Columns
                    '.GetInches() = _Inches
                    '.GetLinesCirculation() = _LinesCirculation
                    .NetCharge = _NetCharge
                    .AddAmount = _AddAmount
                    .MarkupPercent = _MarkupPercent
                    .CampaignCode = _CampaignCode
                    .ClientPO = _ClientPO
                    .MediaPlanDetailLevelLineDataIDs = _MediaPlanDetailLevelLineDataIDs
                    .MediaPlanOrderDescription = _MediaPlanOrderDescription
                    .MediaPlanOrderComment = _MediaPlanOrderComment
                    '.MediaPlanBuyer = _MediaPlanBuyer
                    .MediaPlanMarketCode = _MediaPlanMarketCode
                    .MediaPlanMarketDescription = _MediaPlanMarketDescription
                    .MediaPlanAdSizeCode = _MediaPlanAdSizeCode
                    .MediaPlanAdSizeDescription = _MediaPlanAdSizeDescription
                    .MediaPlanAdNumber = _MediaPlanAdNumber
                    .MediaPlanHeadline = _MediaPlanHeadline
                    .MediaPlanIssue = _MediaPlanIssue
                    .MediaPlanInternetType = _MediaPlanInternetType
                    .MediaPlanPlacement = _MediaPlanPlacement
                    .MediaPlanOutOfHomeType = _MediaPlanOutOfHomeType
                    .MediaPlanDaypart = _MediaPlanDaypart
                    .MediaPlanStartTime = _MediaPlanStartTime
                    .MediaPlanEndTime = _MediaPlanEndTime
                    .MediaPlanLength = _MediaPlanLength
                    .MediaPlanProgramming = _MediaPlanProgramming
                    .MediaPlanNetworkCode = _MediaPlanNetworkCode
                    '.IsSourceMediaPlanning = '_IsSourceMediaPlanning
                    .IsRevision = _IsRevision
                    .MediaPlanAirDate = _MediaPlanAirDate
                    .ImportSource = _ImportSource
                    .OrderNumber = _OrderNumber
                    .OrderLineNumber = _OrderLineNumber

                End With

                TransferEntityAttributes(Me, ImportOrder)

            Catch ex As Exception
                ImportOrder = Nothing
            Finally
                GetImportOrder = ImportOrder
            End Try

        End Function
        Private Sub TransferEntityAttributes(ByVal SourceObject As Object, ByVal TargetObject As Object)

            Dim SourceObjectPropertyDescriptors As List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim SourceObjectEntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim TargetObjectPropertyDescriptors As List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim TargetObjectPropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim TargetObjectEntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                SourceObjectPropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(SourceObject).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList
                TargetObjectPropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(TargetObject).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each SourceObjectPropertyDescriptor In SourceObjectPropertyDescriptors

                    Try

                        SourceObjectEntityAttribute = SourceObjectPropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    Catch ex As Exception
                        SourceObjectEntityAttribute = Nothing
                    End Try

                    If SourceObjectEntityAttribute IsNot Nothing Then

                        Try

                            TargetObjectPropertyDescriptor = TargetObjectPropertyDescriptors.Where(Function(PropDesc) PropDesc.Name = SourceObjectPropertyDescriptor.Name).SingleOrDefault

                        Catch ex As Exception
                            TargetObjectPropertyDescriptor = Nothing
                        End Try

                        If TargetObjectPropertyDescriptor IsNot Nothing Then

                            Try

                                TargetObjectEntityAttribute = TargetObjectPropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                            Catch ex As Exception
                                TargetObjectEntityAttribute = Nothing
                            End Try

                            If TargetObjectEntityAttribute IsNot Nothing Then

                                TargetObjectEntityAttribute.IsRequired = SourceObjectEntityAttribute.IsRequired
                                TargetObjectEntityAttribute.DisplayFormat = SourceObjectEntityAttribute.DisplayFormat
                                TargetObjectEntityAttribute.ShowColumnInGrid = SourceObjectEntityAttribute.ShowColumnInGrid
                                TargetObjectEntityAttribute.IsReadOnlyColumn = SourceObjectEntityAttribute.IsReadOnlyColumn
                                TargetObjectEntityAttribute.CustomColumnCaption = SourceObjectEntityAttribute.CustomColumnCaption
                                TargetObjectEntityAttribute.PropertyType = SourceObjectEntityAttribute.PropertyType
                                TargetObjectEntityAttribute.IsImportDefaultProperty = SourceObjectEntityAttribute.IsImportDefaultProperty
                                TargetObjectEntityAttribute.DefaultColumnType = SourceObjectEntityAttribute.DefaultColumnType
                                TargetObjectEntityAttribute.UseMaxValue = SourceObjectEntityAttribute.UseMaxValue
                                TargetObjectEntityAttribute.MaxValue = SourceObjectEntityAttribute.MaxValue
                                TargetObjectEntityAttribute.UseMinValue = SourceObjectEntityAttribute.UseMinValue
                                TargetObjectEntityAttribute.MinValue = SourceObjectEntityAttribute.MinValue

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Class

End Namespace