Namespace AccountPayable.Classes

    <Serializable()>
    Public Class ImportAccountPayableMedia
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportAccountPayableID
            MediaType
            OrderID
            OrderNumber
            Month
            Year
            SalesClassCode
            OrderLineID
            OrderLineNumber
            LineDate
            MediaQuantity
            MediaGrossRate
            MediaNetRate
            MediaNetAmount
            MediaVendorTax
            MediaNetCharge
            MediaMarkupPercent
            MediaAddAmount
            PreviouslyPostedNetAmount
            OrderNetAmount
            OrderNetVariance
            MediaOfficeCode
            MediaClientCode
            ClientName
            MediaDivisionCode
            DivisionName
            MediaProductCode
            ProductName
            MediaCampaignID
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
        Private _ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader = Nothing
        Private _PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _AllowVendorNotOnOrder As Nullable(Of Boolean) = Nothing
        Private _AccountPayableAvailableInternetOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders) = Nothing
        Private _AccountPayableAvailableMagazineOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders) = Nothing
        Private _AccountPayableAvailableNewspaperOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders) = Nothing
        Private _AccountPayableAvailableOutOfHomeOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders) = Nothing
        Private _AccountPayableAvailableRadioOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders) = Nothing
        Private _AccountPayableAvailableTVOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders) = Nothing

#End Region

#Region " Properties "

        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor)
            Set(value As Generic.List(Of System.ComponentModel.PropertyDescriptor))
                _PropertyDescriptors = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AllowVendorNotOnOrder As Nullable(Of Boolean)
            Set(value As Nullable(Of Boolean))
                _AllowVendorNotOnOrder = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AccountPayableAvailableInternetOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders))
                _AccountPayableAvailableInternetOrdersList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AccountPayableAvailableMagazineOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders))
                _AccountPayableAvailableMagazineOrdersList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AccountPayableAvailableNewspaperOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders))
                _AccountPayableAvailableNewspaperOrdersList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AccountPayableAvailableOutOfHomeOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders))
                _AccountPayableAvailableOutOfHomeOrdersList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AccountPayableAvailableRadioOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders))
                _AccountPayableAvailableRadioOrdersList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property AccountPayableAvailableTVOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders))
                _AccountPayableAvailableTVOrdersList = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayableMedia.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ImportAccountPayableID() As Integer
            Get
                ImportAccountPayableID = _ImportAccountPayableMedia.ImportAccountPayableID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaType() As String
            Get
                MediaType = _ImportAccountPayableMedia.MediaType
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderID() As Nullable(Of Integer)
            Get
                OrderID = _ImportAccountPayableMedia.OrderID
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _ImportAccountPayableMedia.OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Month() As String
            Get
                Month = _ImportAccountPayableMedia.Month
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.Month = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Year() As Nullable(Of Short)
            Get
                Year = _ImportAccountPayableMedia.Year
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableMedia.Year = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _ImportAccountPayableMedia.SalesClassCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderLineID() As Nullable(Of Integer)
            Get
                OrderLineID = _ImportAccountPayableMedia.OrderLineID
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.OrderLineID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _ImportAccountPayableMedia.OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableMedia.OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineDate() As Nullable(Of Date)
            Get
                LineDate = _ImportAccountPayableMedia.LineDate
            End Get
            Set(value As Nullable(Of Date))
                _ImportAccountPayableMedia.LineDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaQuantity() As Nullable(Of Decimal)
            Get
                MediaQuantity = _ImportAccountPayableMedia.MediaQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property MediaGrossRate() As Nullable(Of Decimal)
            Get
                MediaGrossRate = _ImportAccountPayableMedia.MediaGrossRate
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaGrossRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property MediaNetRate() As Nullable(Of Decimal)
            Get
                MediaNetRate = _ImportAccountPayableMedia.MediaNetRate
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaNetRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property MediaNetAmount() As Nullable(Of Decimal)
            Get
                MediaNetAmount = _ImportAccountPayableMedia.MediaNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaVendorTax() As Nullable(Of Decimal)
            Get
                MediaVendorTax = _ImportAccountPayableMedia.MediaVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaNetCharge() As Nullable(Of Decimal)
            Get
                MediaNetCharge = _ImportAccountPayableMedia.MediaNetCharge
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaNetCharge = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property MediaMarkupPercent() As Nullable(Of Decimal)
            Get
                MediaMarkupPercent = _ImportAccountPayableMedia.MediaMarkupPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaMarkupPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaAddAmount() As Nullable(Of Decimal)
            Get
                MediaAddAmount = _ImportAccountPayableMedia.MediaAddAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaAddAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PreviouslyPostedNetAmount() As Nullable(Of Decimal)
            Get
                PreviouslyPostedNetAmount = _ImportAccountPayableMedia.PreviouslyPostedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.PreviouslyPostedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property OrderNetAmount() As Nullable(Of Decimal)
            Get
                OrderNetAmount = _ImportAccountPayableMedia.OrderNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.OrderNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public ReadOnly Property OrderNetVariance() As Nullable(Of Decimal)
            Get
                If _ImportAccountPayableMedia.ID <> 0 Then
                    OrderNetVariance = OrderNetAmount.GetValueOrDefault(0) - (MediaNetAmount.GetValueOrDefault(0) + MediaVendorTax.GetValueOrDefault(0) + MediaNetCharge.GetValueOrDefault(0) + PreviouslyPostedNetAmount.GetValueOrDefault(0))
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaOfficeCode() As String
            Get
                MediaOfficeCode = _ImportAccountPayableMedia.OfficeCodeDetail
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.OfficeCodeDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, CustomColumnCaption:="Client Code")>
        Public Property MediaClientCode() As String
            Get
                MediaClientCode = _ImportAccountPayableMedia.ClientCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ImportAccountPayableMedia.ClientName
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, CustomColumnCaption:="Division Code")>
        Public Property MediaDivisionCode() As String
            Get
                MediaDivisionCode = _ImportAccountPayableMedia.DivisionCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _ImportAccountPayableMedia.DivisionName
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, CustomColumnCaption:="Product Code")>
        Public Property MediaProductCode() As String
            Get
                MediaProductCode = _ImportAccountPayableMedia.ProductCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
            Get
                ProductName = _ImportAccountPayableMedia.ProductName
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorCode() As String
            Get
                VendorCode = _ImportAccountPayableHeader.VendorCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsLegacyBroadcastOrder() As Boolean
            Get
                IsLegacyBroadcastOrder = _ImportAccountPayableMedia.IsLegacyBroadcastOrder
            End Get
            Set(value As Boolean)
                _ImportAccountPayableMedia.IsLegacyBroadcastOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _ImportAccountPayableHeader.OfficeCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public WriteOnly Property DaypartID() As Nullable(Of Integer)
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.DaypartID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaCampaignID() As Nullable(Of Integer)
            Get
                MediaCampaignID = _ImportAccountPayableMedia.CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.CampaignID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableMedia = New AdvantageFramework.Database.Entities.ImportAccountPayableMedia

        End Sub
        Public Sub New(ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia, ByVal ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader)

            _ImportAccountPayableMedia = ImportAccountPayableMedia
            _ImportAccountPayableHeader = ImportAccountPayableHeader

        End Sub
        Public Overrides Function ToString() As String

            ToString = _ImportAccountPayableMedia.ID

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportAccountPayableMedia

            GetEntity = _ImportAccountPayableMedia

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Overrides Sub SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.OrderLineNumber.ToString

                        If Me.IsLegacyBroadcastOrder Then

                            SetRequired(PropertyDescriptor, False)

                        Else

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.MediaOfficeCode.ToString

                        If _ImportAccountPayableHeader.IsInterCompanyTransactionsEnabled OrElse _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim OfficeCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.MediaType.ToString

                    PropertyValue = Value

                    If IsValid AndAlso PropertyValue <> "I" AndAlso PropertyValue <> "M" AndAlso PropertyValue <> "N" AndAlso PropertyValue <> "O" AndAlso PropertyValue <> "R" AndAlso PropertyValue <> "T" Then

                        IsValid = False

                        ErrorText = "Please enter a valid media type."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.OrderID.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.OrderNumber Is Nothing Then

                        If _AllowVendorNotOnOrder Is Nothing Then

                            _AllowVendorNotOnOrder = AdvantageFramework.Agency.GetOptionAPAllowOrderNotMatchingVendor(DbContext)

                        End If

                        IsValid = False

                        ErrorText = Trim("Invalid Order ID.  " & If(_AllowVendorNotOnOrder, "Does not exist or does not exist for source code.", "Does not exist or does not exist for source code, or Vendor on AP Invoice may not match the Order Vendor."))

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.MediaOfficeCode.ToString

                    PropertyValue = Value

                    If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso _ImportAccountPayableHeader.OfficeCode <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Office does not match header."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.OrderNumber.ToString

                    If Value IsNot Nothing Then

                        If _AllowVendorNotOnOrder Is Nothing Then

                            _AllowVendorNotOnOrder = AdvantageFramework.Agency.GetOptionAPAllowOrderNotMatchingVendor(DbContext)

                        End If

                        PropertyValue = Value

                        If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled Then

                            OfficeCode = Me.OfficeCode

                        End If

                        Select Case Me.MediaType

                            Case "T"

                                If _AccountPayableAvailableTVOrdersList Is Nothing Then

                                    _AccountPayableAvailableTVOrdersList = AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _ImportAccountPayableHeader.BatchName, _ImportAccountPayableHeader.SourceCode, Me.OrderID, Me.LineDate)

                                End If

                                If (From Entity In _AccountPayableAvailableTVOrdersList
                                    Where Entity.OrderNumber = CInt(PropertyValue) AndAlso
                                          Entity.Month = Me.Month AndAlso
                                          Entity.Year = Me.Year AndAlso
                                          Entity.ClientCode = Me.MediaClientCode AndAlso
                                          Entity.DivisionCode = Me.MediaDivisionCode AndAlso
                                          Entity.ProductCode = Me.MediaProductCode AndAlso
                                          Entity.VendorCode = If(_AllowVendorNotOnOrder = False, Me.VendorCode, Entity.VendorCode) AndAlso
                                          Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                                    IsValid = False

                                    ErrorText = Trim("Order Number is invalid.  " & If(_AllowVendorNotOnOrder AndAlso Me.OrderID IsNot Nothing, "Order ID/Source Code may not match the Order, or Order may be closed.",
                                                                                  If(Me.OrderID IsNot Nothing, "Vendor on AP Invoice may not match the Order Vendor or Order ID/Source Code may not match the Order, or Order may be closed.", "")))

                                End If

                            Case "R"

                                If _AccountPayableAvailableRadioOrdersList Is Nothing Then

                                    _AccountPayableAvailableRadioOrdersList = AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _ImportAccountPayableHeader.BatchName, _ImportAccountPayableHeader.SourceCode, Me.OrderID, Me.LineDate)

                                End If

                                If (From Entity In _AccountPayableAvailableRadioOrdersList
                                    Where Entity.OrderNumber = CInt(PropertyValue) AndAlso
                                          Entity.Month = Me.Month AndAlso
                                          Entity.Year = Me.Year AndAlso
                                          Entity.ClientCode = Me.MediaClientCode AndAlso
                                          Entity.DivisionCode = Me.MediaDivisionCode AndAlso
                                          Entity.ProductCode = Me.MediaProductCode AndAlso
                                          Entity.VendorCode = If(_AllowVendorNotOnOrder = False, Me.VendorCode, Entity.VendorCode) AndAlso
                                          Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                                    IsValid = False

                                    ErrorText = Trim("Order Number is invalid.  " & If(_AllowVendorNotOnOrder AndAlso Me.OrderID IsNot Nothing, "Order ID/Source Code may not match the Order, or Order may be closed.",
                                                                                  If(Me.OrderID IsNot Nothing, "Vendor on AP Invoice may not match the Order Vendor or Order ID/Source Code may not match the Order, or Order may be closed.", "")))

                                End If

                            Case "M"

                                If _AccountPayableAvailableMagazineOrdersList Is Nothing Then

                                    _AccountPayableAvailableMagazineOrdersList = AdvantageFramework.AccountPayable.GetAvailableMagazineOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, _ImportAccountPayableHeader.BatchName, _ImportAccountPayableHeader.SourceCode, Me.OrderID)

                                End If

                                If (From Entity In _AccountPayableAvailableMagazineOrdersList
                                    Where Entity.OrderNumber = CInt(PropertyValue) AndAlso
                                          Entity.ClientCode = Me.MediaClientCode AndAlso
                                          Entity.DivisionCode = Me.MediaDivisionCode AndAlso
                                          Entity.ProductCode = Me.MediaProductCode AndAlso
                                          Entity.VendorCode = If(_AllowVendorNotOnOrder = False, Me.VendorCode, Entity.VendorCode) AndAlso
                                          Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                                    IsValid = False

                                    ErrorText = Trim("Order Number is invalid.  " & If(_AllowVendorNotOnOrder AndAlso Me.OrderID IsNot Nothing, "Order ID/Source Code may not match the Order, or Order may be closed.",
                                                                                  If(Me.OrderID IsNot Nothing, "Vendor on AP Invoice may not match the Order Vendor or Order ID/Source Code may not match the Order, or Order may be closed.", "")))

                                End If

                            Case "I"

                                If _AccountPayableAvailableInternetOrdersList Is Nothing Then

                                    _AccountPayableAvailableInternetOrdersList = AdvantageFramework.AccountPayable.GetAvailableInternetOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, _ImportAccountPayableHeader.BatchName, _ImportAccountPayableHeader.SourceCode, Me.OrderID)

                                End If

                                If (From Entity In _AccountPayableAvailableInternetOrdersList
                                    Where Entity.OrderNumber = CInt(PropertyValue) AndAlso
                                          Entity.ClientCode = Me.MediaClientCode AndAlso
                                          Entity.DivisionCode = Me.MediaDivisionCode AndAlso
                                          Entity.ProductCode = Me.MediaProductCode AndAlso
                                          Entity.VendorCode = If(_AllowVendorNotOnOrder = False, Me.VendorCode, Entity.VendorCode) AndAlso
                                          Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                                    IsValid = False

                                    ErrorText = Trim("Order Number is invalid.  " & If(_AllowVendorNotOnOrder AndAlso Me.OrderID IsNot Nothing, "Order ID/Source Code may not match the Order, or Order may be closed.",
                                                                                  If(Me.OrderID IsNot Nothing, "Vendor on AP Invoice may not match the Order Vendor or Order ID/Source Code may not match the Order, or Order may be closed.", "")))

                                End If

                            Case "N"

                                If _AccountPayableAvailableNewspaperOrdersList Is Nothing Then

                                    _AccountPayableAvailableNewspaperOrdersList = AdvantageFramework.AccountPayable.GetAvailableNewspaperOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, _ImportAccountPayableHeader.BatchName, _ImportAccountPayableHeader.SourceCode, Me.OrderID)

                                End If

                                If (From Entity In _AccountPayableAvailableNewspaperOrdersList
                                    Where Entity.OrderNumber = CInt(PropertyValue) AndAlso
                                          Entity.ClientCode = Me.MediaClientCode AndAlso
                                          Entity.DivisionCode = Me.MediaDivisionCode AndAlso
                                          Entity.ProductCode = Me.MediaProductCode AndAlso
                                          Entity.VendorCode = If(_AllowVendorNotOnOrder = False, Me.VendorCode, Entity.VendorCode) AndAlso
                                          Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                                    IsValid = False

                                    ErrorText = Trim("Order Number is invalid.  " & If(_AllowVendorNotOnOrder AndAlso Me.OrderID IsNot Nothing, "Order ID/Source Code may not match the Order, or Order may be closed.",
                                                                                  If(Me.OrderID IsNot Nothing, "Vendor on AP Invoice may not match the Order Vendor or Order ID/Source Code may not match the Order, or Order may be closed.", "")))

                                End If

                            Case "O"

                                If _AccountPayableAvailableOutOfHomeOrdersList Is Nothing Then

                                    _AccountPayableAvailableOutOfHomeOrdersList = AdvantageFramework.AccountPayable.GetAvailableOutOfHomeOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, _ImportAccountPayableHeader.BatchName, _ImportAccountPayableHeader.SourceCode, Me.OrderID)

                                End If

                                If (From Entity In _AccountPayableAvailableOutOfHomeOrdersList
                                    Where Entity.OrderNumber = CInt(PropertyValue) AndAlso
                                          Entity.ClientCode = Me.MediaClientCode AndAlso
                                          Entity.DivisionCode = Me.MediaDivisionCode AndAlso
                                          Entity.ProductCode = Me.MediaProductCode AndAlso
                                          Entity.VendorCode = If(_AllowVendorNotOnOrder = False, Me.VendorCode, Entity.VendorCode) AndAlso
                                          Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                                    IsValid = False

                                    ErrorText = Trim("Order Number is invalid.  " & If(_AllowVendorNotOnOrder AndAlso Me.OrderID IsNot Nothing, "Order ID/Source Code may not match the Order, or Order may be closed.",
                                                                                  If(Me.OrderID IsNot Nothing, "Vendor on AP Invoice may not match the Order Vendor or Order ID/Source Code may not match the Order, or Order may be closed.", "")))

                                End If

                        End Select

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia.Properties.MediaCampaignID.ToString

                    PropertyValue = Value

                    If String.IsNullOrWhiteSpace(Me.MediaClientCode) = False Then

                        If String.IsNullOrWhiteSpace(Me.MediaDivisionCode) = False Then

                            DivisionCode = Me.MediaDivisionCode

                        End If

                        If String.IsNullOrWhiteSpace(Me.MediaProductCode) = False Then

                            ProductCode = Me.MediaProductCode

                        End If

                        If AdvantageFramework.Database.Procedures.Campaign.LoadAllByClientDivisionAndProduct(DbContext, Me.MediaClientCode, DivisionCode, ProductCode).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid campaign."

                        End If

                    ElseIf PropertyValue IsNot Nothing Then

                        IsValid = False

                        ErrorText = "Invalid campaign."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Function CustomValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                If PropertyDescriptor.Attributes.OfType(Of System.Xml.Serialization.XmlIgnoreAttribute).Any = False AndAlso _
                        Not PropertyDescriptor.PropertyType Is GetType(Byte()) Then

                    OldValue = PropertyDescriptor.GetValue(Me)
                    Value = OldValue

                    PropertyErrorText = CustomValidateProperty(PropertyDescriptor.Name, PropertyIsValid, Value)

                    If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

                        PropertyDescriptor.SetValue(Me, Value)

                    End If

                    If PropertyIsValid = False Then

                        If IsValid Then

                            IsValid = False

                        End If

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                    ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                    End If

                End If

            Next

            _EntityError = ErrorText

            CustomValidateEntity = ErrorText

        End Function
        Public Function CustomValidateProperty(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim IsRequired As Boolean = False
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
            Dim DisplayName As String = ""

            LoadPropertyAttributes(Me.GetType, PropertyName, IsRequired, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName)

            End If

            IsValid = True

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, False, IsRequired, True, 0, 0, 0)

                'If IsValid Then

                '    ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, _DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                'End If

                ErrorText &= ValidateCustomProperties(PropertyName, IsValid, Value)

            Catch ex As Exception
                IsValid = True
            End Try

            'FinalizeEntityPropertyValidation(PropertyName, IsValid, Value, ErrorText, False, True, IsRequired, 0, 0, 0, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso _
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyName, Value)

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            CustomValidateProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace

