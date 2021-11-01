Namespace DTO.Media.BroadcastXML

    '' NOTE: Generated code may require at least .NET Framework 4.5 Or .NET Core/Standard 2.0.
    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon", IsNullable:=False)>
    Partial Public Class CreateOrderRequest

        Private orderField As CreateOrderRequestOrder

        Private messageIdField As String

        Private timestampField As Date

        Private targetEnvironmentField As String

        Private originatingTradingPartnerField As String

        Private destinationTradingPartnerField As String

        Private mediaTypeField As String

        Private serviceNameField As String

        Private serviceVersionField As Decimal

        Private serviceInstanceIdField As String

        Private messageVersionField As Decimal

        '''<remarks/>
        Public Property Order() As CreateOrderRequestOrder
            Get
                Return Me.orderField
            End Get
            Set
                Me.orderField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property messageId() As String
            Get
                Return Me.messageIdField
            End Get
            Set
                Me.messageIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property timestamp() As Date
            Get
                Return Me.timestampField
            End Get
            Set
                Me.timestampField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property targetEnvironment() As String
            Get
                Return Me.targetEnvironmentField
            End Get
            Set
                Me.targetEnvironmentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property originatingTradingPartner() As String
            Get
                Return Me.originatingTradingPartnerField
            End Get
            Set
                Me.originatingTradingPartnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property destinationTradingPartner() As String
            Get
                Return Me.destinationTradingPartnerField
            End Get
            Set
                Me.destinationTradingPartnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property mediaType() As String
            Get
                Return Me.mediaTypeField
            End Get
            Set
                Me.mediaTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property serviceName() As String
            Get
                Return Me.serviceNameField
            End Get
            Set
                Me.serviceNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property serviceVersion() As Decimal
            Get
                Return Me.serviceVersionField
            End Get
            Set
                Me.serviceVersionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property serviceInstanceId() As String
            Get
                Return Me.serviceInstanceIdField
            End Get
            Set
                Me.serviceInstanceIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property messageVersion() As Decimal
            Get
                Return Me.messageVersionField
            End Get
            Set
                Me.messageVersionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrder

        Private orderIdReferencesField As CreateOrderRequestOrderOrderIdReferences

        Private orderTypeField As String

        Private orderCashTradeField As String

        Private advertiserField As Advertiser

        Private productField As Product

        Private agencyField As Agency

        Private estimateField As Estimate

        Private sellerField As Seller

        Private localNationalField As String

        Private stationField As Station

        Private startDateField As Date

        Private endDateField As Date

        Private orderGrossAmountField As String ' UShort

        Private billingCalendarField As String

        Private billingCycleField As String

        Private primaryDemoCategoryField As PrimaryDemoCategory

        Private demoCategoryField() As DemoCategory

        Private commentField() As Comment

        Private termsOfSaleField As TermsOfSale

        Private buylinesField As SpotBuyline()

        Private orderIdField As String

        Private orderVersionField As String 'Byte

        Private orderStatusField As String

        '''<remarks/>
        Public Property OrderIdReferences() As CreateOrderRequestOrderOrderIdReferences
            Get
                Return Me.orderIdReferencesField
            End Get
            Set
                Me.orderIdReferencesField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property OrderType() As String
            Get
                Return Me.orderTypeField
            End Get
            Set
                Me.orderTypeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property OrderCashTrade() As String
            Get
                Return Me.orderCashTradeField
            End Get
            Set
                Me.orderCashTradeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property Advertiser() As Advertiser
            Get
                Return Me.advertiserField
            End Get
            Set
                Me.advertiserField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property Product() As Product
            Get
                Return Me.productField
            End Get
            Set
                Me.productField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property Agency() As Agency
            Get
                Return Me.agencyField
            End Get
            Set
                Me.agencyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property Estimate() As Estimate
            Get
                Return Me.estimateField
            End Get
            Set
                Me.estimateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property Seller() As Seller
            Get
                Return Me.sellerField
            End Get
            Set
                Me.sellerField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property LocalNational() As String
            Get
                Return Me.localNationalField
            End Get
            Set
                Me.localNationalField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property Station() As Station
            Get
                Return Me.stationField
            End Get
            Set
                Me.stationField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", DataType:="date")>
        Public Property StartDate() As Date
            Get
                Return Me.startDateField
            End Get
            Set
                Me.startDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", DataType:="date")>
        Public Property EndDate() As Date
            Get
                Return Me.endDateField
            End Get
            Set
                Me.endDateField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property OrderGrossAmount() As String ' UShort
            Get
                Return Me.orderGrossAmountField
            End Get
            Set
                Me.orderGrossAmountField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BillingCalendar() As String
            Get
                Return Me.billingCalendarField
            End Get
            Set
                Me.billingCalendarField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BillingCycle() As String
            Get
                Return Me.billingCycleField
            End Get
            Set
                Me.billingCycleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property PrimaryDemoCategory() As PrimaryDemoCategory
            Get
                Return Me.primaryDemoCategoryField
            End Get
            Set
                Me.primaryDemoCategoryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("DemoCategory", [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property DemoCategory() As DemoCategory()
            Get
                Return Me.demoCategoryField
            End Get
            Set
                Me.demoCategoryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Comment", [Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property Comment() As Comment()
            Get
                Return Me.commentField
            End Get
            Set
                Me.commentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property TermsOfSale() As TermsOfSale
            Get
                Return Me.termsOfSaleField
            End Get
            Set
                Me.termsOfSaleField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Buylines() As SpotBuyline()
            Get
                Return Me.buylinesField
            End Get
            Set
                Me.buylinesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property orderId() As String
            Get
                Return Me.orderIdField
            End Get
            Set
                Me.orderIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property orderVersion() As String 'Byte
            Get
                Return Me.orderVersionField
            End Get
            Set
                Me.orderVersionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property orderStatus() As String
            Get
                Return Me.orderStatusField
            End Get
            Set
                Me.orderStatusField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrderOrderIdReferences

        Private sourceCodeField As SourceCode

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", IsNullable:=False)>
    Partial Public Class SourceCode

        Private sourceField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property source() As String
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class Advertiser

        Private companyNameField As String

        Private sourceCodeField As SourceCode

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property CompanyName() As String
            Get
                Return Me.companyNameField
            End Get
            Set
                Me.companyNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class Product

        Private productNameField As String

        Private sourceCodeField As SourceCode

        '''<remarks/>
        Public Property ProductName() As String
            Get
                Return Me.productNameField
            End Get
            Set
                Me.productNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class Agency

        Private companyNameField As String

        Private contactField As Contact

        Private sourceCodeField As SourceCode

        Private officeField As Office

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property CompanyName() As String
            Get
                Return Me.companyNameField
            End Get
            Set
                Me.companyNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property Contact() As Contact
            Get
                Return Me.contactField
            End Get
            Set
                Me.contactField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property Office() As Office
            Get
                Return Me.officeField
            End Get
            Set
                Me.officeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", IsNullable:=False)>
    Partial Public Class Contact

        Private personFirstNameField As String

        Private personLastNameField As String

        Private emailField As String

        Private phoneField As ContactPhone

        Private sourceCodeField As ContactSourceCode

        Private contactIdField As String

        Private contactRoleField As String

        '''<remarks/>
        Public Property PersonFirstName() As String
            Get
                Return Me.personFirstNameField
            End Get
            Set
                Me.personFirstNameField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PersonLastName() As String
            Get
                Return Me.personLastNameField
            End Get
            Set
                Me.personLastNameField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Email() As String
            Get
                Return Me.emailField
            End Get
            Set
                Me.emailField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Phone() As ContactPhone
            Get
                Return Me.phoneField
            End Get
            Set
                Me.phoneField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SourceCode() As ContactSourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property contactId() As String
            Get
                Return Me.contactIdField
            End Get
            Set
                Me.contactIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property contactRole() As String
            Get
                Return Me.contactRoleField
            End Get
            Set
                Me.contactRoleField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common")>
    Partial Public Class ContactPhone

        Private areaCityCodeField As UShort

        Private phoneNumberField As UInteger

        '''<remarks/>
        Public Property AreaCityCode() As UShort
            Get
                Return Me.areaCityCodeField
            End Get
            Set
                Me.areaCityCodeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PhoneNumber() As UInteger
            Get
                Return Me.phoneNumberField
            End Get
            Set
                Me.phoneNumberField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common")>
    Partial Public Class ContactSourceCode

        Private sourceField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property source() As String
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", IsNullable:=False)>
    Partial Public Class Office

        Private officeNameField As String

        Private addressField As OfficeAddress

        Private sourceCodeField As OfficeSourceCode

        '''<remarks/>
        Public Property OfficeName() As String
            Get
                Return Me.officeNameField
            End Get
            Set
                Me.officeNameField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Address() As OfficeAddress
            Get
                Return Me.addressField
            End Get
            Set
                Me.addressField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SourceCode() As OfficeSourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common")>
    Partial Public Class OfficeAddress

        Private addressBlockLineField As String

        Private addressRoleField As String

        '''<remarks/>
        Public Property AddressBlockLine() As String
            Get
                Return Me.addressBlockLineField
            End Get
            Set
                Me.addressBlockLineField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property addressRole() As String
            Get
                Return Me.addressRoleField
            End Get
            Set
                Me.addressRoleField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common")>
    Partial Public Class OfficeSourceCode

        Private sourceField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property source() As String
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class Estimate

        Private sourceCodeField As SourceCode

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class Seller

        Private stationSellerField As SellerStationSeller

        '''<remarks/>
        Public Property StationSeller() As SellerStationSeller
            Get
                Return Me.stationSellerField
            End Get
            Set
                Me.stationSellerField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
    Partial Public Class SellerStationSeller

        Private companyNameField As String

        Private sourceCodeField As SourceCode

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property CompanyName() As String
            Get
                Return Me.companyNameField
            End Get
            Set
                Me.companyNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class Station

        Private fCCCallLettersField As String

        Private sourceCodeField As SourceCode

        '''<remarks/>
        Public Property FCCCallLetters() As String
            Get
                Return Me.fCCCallLettersField
            End Get
            Set
                Me.fCCCallLettersField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class PrimaryDemoCategory

        Private demoIdField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property demoId() As String
            Get
                Return Me.demoIdField
            End Get
            Set
                Me.demoIdField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class DemoCategory

        Private demoGroupField As String

        Private demoLowerAgeField As Byte

        Private demoUpperAgeField As Byte

        Private demoIdField As String

        '''<remarks/>
        Public Property DemoGroup() As String
            Get
                Return Me.demoGroupField
            End Get
            Set
                Me.demoGroupField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DemoLowerAge() As Byte
            Get
                Return Me.demoLowerAgeField
            End Get
            Set
                Me.demoLowerAgeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DemoUpperAge() As Byte
            Get
                Return Me.demoUpperAgeField
            End Get
            Set
                Me.demoUpperAgeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property demoId() As String
            Get
                Return Me.demoIdField
            End Get
            Set
                Me.demoIdField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_Common"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", IsNullable:=False)>
    Partial Public Class Comment

        Private sourceField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property source() As String
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon", IsNullable:=False)>
    Partial Public Class TermsOfSale

        Private sourceField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property source() As String
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    ''''<remarks/>
    '<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    'Partial Public Class CreateOrderRequestOrderBuylines

    '    Private spotBuylineField As SpotBuyline()

    '    '''<remarks/>
    '    Public Property SpotBuyline() As SpotBuyline()
    '        Get
    '            Return Me.spotBuylineField
    '        End Get
    '        Set
    '            Me.spotBuylineField = Value
    '        End Set
    '    End Property
    'End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class SpotBuyline

        Private buylineIdReferencesField As CreateOrderRequestOrderBuylinesSpotBuylineBuylineIdReferences

        Private buylineCashTradeField As String

        Private buylineDescriptionField As String

        Private startDateField As Date

        Private endDateField As Date

        Private buylineQuantityField As CreateOrderRequestOrderBuylinesSpotBuylineBuylineQuantity

        Private buylineUnitRateField As CreateOrderRequestOrderBuylinesSpotBuylineBuylineUnitRate

        Private buylineGrossAmountField As Decimal 'UShort

        Private spotBuylineTypeField As String

        Private spotLengthField As Integer ' Byte

        Private buyerDaypartField As String

        Private startDayOfWeekField As String

        Private contractIntervalField As CreateOrderRequestOrderBuylinesSpotBuylineContractInterval

        Private weeklySpotDistributionField() As WeeklySpotDistribution

        Private targetDemoValueField() As CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue

        Private buylineVersionField As String 'Byte

        Private buylineStatusField As String

        Private buylineNumberField As String ' Byte

        '''<remarks/>
        Public Property BuylineIdReferences() As CreateOrderRequestOrderBuylinesSpotBuylineBuylineIdReferences
            Get
                Return Me.buylineIdReferencesField
            End Get
            Set
                Me.buylineIdReferencesField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BuylineCashTrade() As String
            Get
                Return Me.buylineCashTradeField
            End Get
            Set
                Me.buylineCashTradeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BuylineDescription() As String
            Get
                Return Me.buylineDescriptionField
            End Get
            Set
                Me.buylineDescriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", DataType:="date")>
        Public Property StartDate() As Date
            Get
                Return Me.startDateField
            End Get
            Set
                Me.startDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", DataType:="date")>
        Public Property EndDate() As Date
            Get
                Return Me.endDateField
            End Get
            Set
                Me.endDateField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BuylineQuantity() As CreateOrderRequestOrderBuylinesSpotBuylineBuylineQuantity
            Get
                Return Me.buylineQuantityField
            End Get
            Set
                Me.buylineQuantityField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BuylineUnitRate() As CreateOrderRequestOrderBuylinesSpotBuylineBuylineUnitRate
            Get
                Return Me.buylineUnitRateField
            End Get
            Set
                Me.buylineUnitRateField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BuylineGrossAmount() As Decimal ' UShort
            Get
                Return Me.buylineGrossAmountField
            End Get
            Set
                Me.buylineGrossAmountField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SpotBuylineType() As String
            Get
                Return Me.spotBuylineTypeField
            End Get
            Set
                Me.spotBuylineTypeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SpotLength() As Integer ' Byte
            Get
                Return Me.spotLengthField
            End Get
            Set
                Me.spotLengthField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property BuyerDaypart() As String
            Get
                Return Me.buyerDaypartField
            End Get
            Set
                Me.buyerDaypartField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property StartDayOfWeek() As String
            Get
                Return Me.startDayOfWeekField
            End Get
            Set
                Me.startDayOfWeekField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ContractInterval() As CreateOrderRequestOrderBuylinesSpotBuylineContractInterval
            Get
                Return Me.contractIntervalField
            End Get
            Set
                Me.contractIntervalField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("WeeklySpotDistribution")>
        Public Property WeeklySpotDistribution() As WeeklySpotDistribution()
            Get
                Return Me.weeklySpotDistributionField
            End Get
            Set
                Me.weeklySpotDistributionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("TargetDemoValue")>
        Public Property TargetDemoValue() As CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue()
            Get
                Return Me.targetDemoValueField
            End Get
            Set
                Me.targetDemoValueField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property buylineVersion() As String ' Byte
            Get
                Return Me.buylineVersionField
            End Get
            Set
                Me.buylineVersionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property buylineStatus() As String
            Get
                Return Me.buylineStatusField
            End Get
            Set
                Me.buylineStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property buylineNumber() As String ' Byte
            Get
                Return Me.buylineNumberField
            End Get
            Set
                Me.buylineNumberField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrderBuylinesSpotBuylineBuylineIdReferences

        Private sourceCodeField As SourceCode

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property SourceCode() As SourceCode
            Get
                Return Me.sourceCodeField
            End Get
            Set
                Me.sourceCodeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrderBuylinesSpotBuylineBuylineQuantity

        Private unitTypeField As String

        Private valueField As Integer 'Byte

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property unitType() As String
            Get
                Return Me.unitTypeField
            End Get
            Set
                Me.unitTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Integer 'Byte
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrderBuylinesSpotBuylineBuylineUnitRate

        Private costModelField As String

        Private valueField As Decimal

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property costModel() As String
            Get
                Return Me.costModelField
            End Get
            Set
                Me.costModelField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Decimal
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrderBuylinesSpotBuylineContractInterval

        Private mondayValidField As Boolean

        Private tuesdayValidField As Boolean

        Private wednesdayValidField As Boolean

        Private thursdayValidField As Boolean

        Private fridayValidField As Boolean

        Private saturdayValidField As Boolean

        Private sundayValidField As Boolean

        Private startTimeField As String

        Private endTimeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property MondayValid() As Boolean
            Get
                Return Me.mondayValidField
            End Get
            Set
                Me.mondayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property TuesdayValid() As Boolean
            Get
                Return Me.tuesdayValidField
            End Get
            Set
                Me.tuesdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property WednesdayValid() As Boolean
            Get
                Return Me.wednesdayValidField
            End Get
            Set
                Me.wednesdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property ThursdayValid() As Boolean
            Get
                Return Me.thursdayValidField
            End Get
            Set
                Me.thursdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property FridayValid() As Boolean
            Get
                Return Me.fridayValidField
            End Get
            Set
                Me.fridayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property SaturdayValid() As Boolean
            Get
                Return Me.saturdayValidField
            End Get
            Set
                Me.saturdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property SundayValid() As Boolean
            Get
                Return Me.sundayValidField
            End Get
            Set
                Me.sundayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property StartTime() As String
            Get
                Return Me.startTimeField
            End Get
            Set
                Me.startTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common")>
        Public Property EndTime() As String
            Get
                Return Me.endTimeField
            End Get
            Set
                Me.endTimeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class WeeklySpotDistribution

        Private unitRateAmountField As Decimal

        Private startDateField As Date

        Private endDateField As Date

        Private spotPerWeekQuantityField As Integer ' Byte

        Private mondayValidField As Boolean

        Private tuesdayValidField As Boolean

        Private wednesdayValidField As Boolean

        Private thursdayValidField As Boolean

        Private fridayValidField As Boolean

        Private saturdayValidField As Boolean

        Private sundayValidField As Boolean

        '''<remarks/>
        Public Property UnitRateAmount() As Decimal
            Get
                Return Me.unitRateAmountField
            End Get
            Set
                Me.unitRateAmountField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", DataType:="date")>
        Public Property StartDate() As Date
            Get
                Return Me.startDateField
            End Get
            Set
                Me.startDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_Common", DataType:="date")>
        Public Property EndDate() As Date
            Get
                Return Me.endDateField
            End Get
            Set
                Me.endDateField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SpotPerWeekQuantity() As Integer ' Byte
            Get
                Return Me.spotPerWeekQuantityField
            End Get
            Set
                Me.spotPerWeekQuantityField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property MondayValid() As Boolean
            Get
                Return Me.mondayValidField
            End Get
            Set
                Me.mondayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property TuesdayValid() As Boolean
            Get
                Return Me.tuesdayValidField
            End Get
            Set
                Me.tuesdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property WednesdayValid() As Boolean
            Get
                Return Me.wednesdayValidField
            End Get
            Set
                Me.wednesdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property ThursdayValid() As Boolean
            Get
                Return Me.thursdayValidField
            End Get
            Set
                Me.thursdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property FridayValid() As Boolean
            Get
                Return Me.fridayValidField
            End Get
            Set
                Me.fridayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property SaturdayValid() As Boolean
            Get
                Return Me.saturdayValidField
            End Get
            Set
                Me.saturdayValidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property SundayValid() As Boolean
            Get
                Return Me.sundayValidField
            End Get
            Set
                Me.sundayValidField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.tvb.org/schema/TVB_OrderCommon")>
    Partial Public Class CreateOrderRequestOrderBuylinesSpotBuylineTargetDemoValue

        Private impressionsValueField As UInteger

        Private impressionsValueFieldSpecified As Boolean

        Private ratingPointValueField As Decimal

        Private ratingPointValueFieldSpecified As Boolean

        Private demoIdField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property ImpressionsValue() As UInteger
            Get
                Return Me.impressionsValueField
            End Get
            Set
                Me.impressionsValueField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ImpressionsValueSpecified() As Boolean
            Get
                Return Me.impressionsValueFieldSpecified
            End Get
            Set
                Me.impressionsValueFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.tvb.org/schema/TVB_MediaCommon")>
        Public Property RatingPointValue() As Decimal
            Get
                Return Me.ratingPointValueField
            End Get
            Set
                Me.ratingPointValueField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RatingPointValueSpecified() As Boolean
            Get
                Return Me.ratingPointValueFieldSpecified
            End Get
            Set
                Me.ratingPointValueFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property demoId() As String
            Get
                Return Me.demoIdField
            End Get
            Set
                Me.demoIdField = Value
            End Set
        End Property
    End Class

End Namespace