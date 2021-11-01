Namespace Database.Classes

    <Serializable()>
    Public Class MediaOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TypeInitial
            Type
            ShortNumber
            OrderNumber
            Description
            ClientPO
            IsOpen
            OfficeCode
            ClientCode
            DivisionCode
            ProductCode
            CampaignID
            VendorCode
            MarketCode
        End Enum

#End Region

#Region " Variables "

        Private _TypeInitial As String = Nothing
        Private _Type As String = Nothing
        Private _ShortNumber As Integer = Nothing
        Private _Number As String = Nothing
        Private _Description As String = Nothing
        Private _ClientPO As String = Nothing
        Private _IsOpen As Boolean = Nothing
        Private _OfficeCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _CampaignID As System.Nullable(Of Integer) = Nothing
        Private _VendorCode As String = Nothing
        Private _MarketCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property TypeInitial() As String
            Get
                TypeInitial = _TypeInitial
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Type() As String
            Get
                Type = _Type
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ShortNumber() As Integer
            Get
                ShortNumber = _ShortNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Number() As String
            Get
                Number = _Number
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Description() As String
            Get
                Description = _Description
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property ClientPO As String
            Get
                ClientPO = _ClientPO
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property IsOpen As Boolean
            Get
                IsOpen = _IsOpen
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CampaignID() As System.Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal InternetOrder As AdvantageFramework.Database.Entities.InternetOrder)

            _TypeInitial = "I"
            _Type = "Internet Order"
            _ShortNumber = InternetOrder.OrderNumber
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(InternetOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = InternetOrder.Description
            _ClientPO = InternetOrder.ClientPO
            _IsOpen = If(InternetOrder.OrderProcessControl = 1, True, False)
            _OfficeCode = InternetOrder.OfficeCode
            _ClientCode = InternetOrder.ClientCode
            _DivisionCode = InternetOrder.DivisionCode
            _ProductCode = InternetOrder.ProductCode
            _CampaignID = InternetOrder.CampaignID
            _VendorCode = InternetOrder.VendorCode
            _MarketCode = InternetOrder.MarketCode

        End Sub
        Public Sub New(ByVal MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder)

            _TypeInitial = "M"
            _Type = "Magazine Order"
            _ShortNumber = MagazineOrder.OrderNumber
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(MagazineOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = MagazineOrder.Description
            _ClientPO = MagazineOrder.ClientPO
            _IsOpen = If(MagazineOrder.OrderProcessControl = 1, True, False)
            _OfficeCode = MagazineOrder.OfficeCode
            _ClientCode = MagazineOrder.ClientCode
            _DivisionCode = MagazineOrder.DivisionCode
            _ProductCode = MagazineOrder.ProductCode
            _CampaignID = MagazineOrder.CampaignID
            _VendorCode = MagazineOrder.VendorCode
            _MarketCode = MagazineOrder.MarketCode

        End Sub
        Public Sub New(ByVal NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder)

            _TypeInitial = "N"
            _Type = "Newspaper Order"
            _ShortNumber = NewspaperOrder.OrderNumber
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(NewspaperOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = NewspaperOrder.Description
            _ClientPO = NewspaperOrder.ClientPO
            _IsOpen = If(NewspaperOrder.OrderProcessControl = 1, True, False)
            _OfficeCode = NewspaperOrder.OfficeCode
            _ClientCode = NewspaperOrder.ClientCode
            _DivisionCode = NewspaperOrder.DivisionCode
            _ProductCode = NewspaperOrder.ProductCode
            _CampaignID = NewspaperOrder.CampaignID
            _VendorCode = NewspaperOrder.VendorCode
            _MarketCode = NewspaperOrder.MarketCode

        End Sub
        Public Sub New(ByVal OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder)

            _TypeInitial = "O"
            _Type = "Out Of Home Order"
            _ShortNumber = OutOfHomeOrder.OrderNumber
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(OutOfHomeOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = OutOfHomeOrder.Description
            _ClientPO = OutOfHomeOrder.ClientPO
            _IsOpen = If(OutOfHomeOrder.OrderProcessControl = 1, True, False)
            _OfficeCode = OutOfHomeOrder.OfficeCode
            _ClientCode = OutOfHomeOrder.ClientCode
            _DivisionCode = OutOfHomeOrder.DivisionCode
            _ProductCode = OutOfHomeOrder.ProductCode
            _CampaignID = OutOfHomeOrder.CampaignID
            _VendorCode = OutOfHomeOrder.VenderCode
            _MarketCode = OutOfHomeOrder.MarketCode

        End Sub
        Public Sub New(ByVal RadioOrder As AdvantageFramework.Database.Entities.RadioOrder)

            _TypeInitial = "R"
            _Type = "Radio Order"
            _ShortNumber = RadioOrder.OrderNumber
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(RadioOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = RadioOrder.Description
            _ClientPO = RadioOrder.ClientPO
            _IsOpen = If(RadioOrder.OrderProcessControl = 1, True, False)
            _OfficeCode = RadioOrder.OfficeCode
            _ClientCode = RadioOrder.ClientCode
            _DivisionCode = RadioOrder.DivisionCode
            _ProductCode = RadioOrder.ProductCode
            _CampaignID = RadioOrder.CampaignID
            _VendorCode = RadioOrder.VendorCode
            _MarketCode = RadioOrder.MarketCode

        End Sub
        Public Sub New(ByVal TVOrder As AdvantageFramework.Database.Entities.TVOrder)

            _TypeInitial = "T"
            _Type = "TV Order"
            _ShortNumber = TVOrder.OrderNumber
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(TVOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = TVOrder.Description
            _ClientPO = TVOrder.ClientPO
            _IsOpen = If(TVOrder.OrderProcessControl = 1, True, False)
            _OfficeCode = TVOrder.OfficeCode
            _ClientCode = TVOrder.ClientCode
            _DivisionCode = TVOrder.DivisionCode
            _ProductCode = TVOrder.ProductCode
            _CampaignID = TVOrder.CampaignID
            _VendorCode = TVOrder.VendorCode
            _MarketCode = TVOrder.MarketCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Number

        End Function

#End Region

    End Class

End Namespace

