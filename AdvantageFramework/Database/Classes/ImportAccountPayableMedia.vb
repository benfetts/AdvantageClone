Namespace Database.Classes

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
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
        Private _ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayableMedia.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableID() As Integer
            Get
                ImportAccountPayableID = _ImportAccountPayableMedia.ImportAccountPayableID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.SalesClassCode, IsImportDefaultProperty:=True)>
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
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

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableMedia = New AdvantageFramework.Database.Entities.ImportAccountPayableMedia

        End Sub
        Public Sub New(ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia, ByVal ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader)

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
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Classes.ImportAccountPayableMedia.Properties.OrderLineNumber.ToString

                        If Me.IsLegacyBroadcastOrder Then

                            SetRequired(PropertyDescriptor, False)

                        Else

                            SetRequired(PropertyDescriptor, True)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim BroadcastImportCrossReference As AdvantageFramework.Database.Entities.BroadcastImportCrossReference = Nothing
            Dim PrintImportCrossReference As AdvantageFramework.Database.Entities.PrintImportCrossReference = Nothing
            Dim XRefMediaType As String = Nothing
            Dim AccountPayableAvailableMagazineOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableAvailableMagazineOrders) = Nothing
            Dim AccountPayableAvailableInternetOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableAvailableInternetOrders) = Nothing
            Dim AccountPayableAvailableNewspaperOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableAvailableNewspaperOrders) = Nothing
            Dim AccountPayableAvailableOutOfHomeOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableAvailableOutOfHomeOrders) = Nothing
            Dim AccountPayableAvailableRadioOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableAvailableRadioOrders) = Nothing
            Dim AccountPayableAvailableTVOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableAvailableTVOrders) = Nothing
            Dim OfficeCode As String = Nothing
            Dim AllowVendorNotOnOrder As Boolean = False

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.ImportAccountPayableMedia.Properties.MediaType.ToString

                    PropertyValue = Value

                    If IsValid AndAlso PropertyValue <> "I" AndAlso PropertyValue <> "M" AndAlso PropertyValue <> "N" AndAlso PropertyValue <> "O" AndAlso PropertyValue <> "R" AndAlso PropertyValue <> "T" Then

                        IsValid = False

                        ErrorText = "Please enter a valid media type."

                    End If

                Case AdvantageFramework.Database.Classes.ImportAccountPayableMedia.Properties.OrderID.ToString

                    PropertyValue = Value

                    Select Case Me.MediaType

                        Case "T"

                            XRefMediaType = "TV"

                        Case "R"

                            XRefMediaType = "RA"

                        Case "I", "M", "N", "O"

                            XRefMediaType = Me.MediaType

                        Case Else

                            XRefMediaType = Nothing

                    End Select

                    If Me.MediaType = "T" OrElse Me.MediaType = "R" Then

                        Try

                            If Me.MediaType = "T" Then

                                BroadcastImportCrossReference = AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.LoadByImportOrderNumberAndMediaType(ObjectContext, PropertyValue, "T")

                                If BroadcastImportCrossReference Is Nothing Then

                                    BroadcastImportCrossReference = AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.LoadByImportOrderNumberAndMediaType(ObjectContext, PropertyValue, "TV")

                                End If

                            ElseIf Me.MediaType = "R" Then

                                BroadcastImportCrossReference = AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.LoadByImportOrderNumberAndMediaType(ObjectContext, PropertyValue, "R")

                                If BroadcastImportCrossReference Is Nothing Then

                                    BroadcastImportCrossReference = AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.LoadByImportOrderNumberAndMediaType(ObjectContext, PropertyValue, "RA")

                                End If

                            End If

                        Catch ex As Exception
                            BroadcastImportCrossReference = Nothing
                        End Try

                        If BroadcastImportCrossReference Is Nothing Then

                            IsValid = False

                            ErrorText = "Import Order Number Cross Reference Missing."

                        End If

                    ElseIf Me.MediaType IsNot Nothing Then

                        Try

                            Using DataContext As New AdvantageFramework.Database.DataContext(DirectCast(ObjectContext.Connection, System.Data.EntityClient.EntityConnection).StoreConnection.ConnectionString, ObjectContext.UserCode)

                                PrintImportCrossReference = AdvantageFramework.Database.Procedures.PrintImportCrossReference.LoadByImportOrderNumberAndMediaType(DataContext, PropertyValue, XRefMediaType)

                            End Using

                        Catch ex As Exception
                            PrintImportCrossReference = Nothing
                        End Try

                        If PrintImportCrossReference Is Nothing Then

                            IsValid = False

                            ErrorText = "Import Order Number Cross Reference Missing."

                        End If

                    End If

                Case AdvantageFramework.Database.Classes.ImportAccountPayableMedia.Properties.MediaOfficeCode.ToString

                    PropertyValue = Value

                    If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso _ImportAccountPayableHeader.OfficeCode <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Office does not match header."

                    End If

                Case AdvantageFramework.Database.Classes.ImportAccountPayableMedia.Properties.OrderNumber.ToString

                    If Value IsNot Nothing Then

                        PropertyValue = Value

                        If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled Then

                            OfficeCode = Me.OfficeCode

                        End If

                        AllowVendorNotOnOrder = AdvantageFramework.Agency.GetOptionAPAllowOrderNotMatchingVendor(ObjectContext)

                        Select Case Me.MediaType

                            Case "T"

                                AccountPayableAvailableTVOrdersList = ObjectContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.AccountPayableAvailableTVOrders) _
                                                                        (String.Format("exec advsp_ap_available_tv_orders {0},{1},{2},{3},{4},{5},{6}", _
                                                                         If(AllowVendorNotOnOrder, "NULL", "'" & Me.VendorCode & "'"), _
                                                                         If(String.IsNullOrEmpty(OfficeCode), "NULL", "'" & OfficeCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.MediaClientCode), "NULL", "'" & Me.MediaClientCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.MediaDivisionCode), "NULL", "'" & Me.MediaDivisionCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.MediaProductCode), "NULL", "'" & Me.MediaProductCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.Month), "NULL", "'" & Me.Month & "'"), _
                                                                         If(Me.Year IsNot Nothing, Me.Year, "NULL"))).ToList

                                If AccountPayableAvailableTVOrdersList.Where(Function(O) O.OrderNumber = CInt(PropertyValue)).Any = False Then

                                    IsValid = False

                                    ErrorText = "Order Number is required."

                                End If

                            Case "R"

                                AccountPayableAvailableRadioOrdersList = ObjectContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.AccountPayableAvailableRadioOrders) _
                                                                        (String.Format("exec advsp_ap_available_radio_orders {0},{1},{2},{3},{4},{5},{6}", _
                                                                         If(AllowVendorNotOnOrder, "NULL", "'" & Me.VendorCode & "'"), _
                                                                         If(String.IsNullOrEmpty(OfficeCode), "NULL", "'" & OfficeCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.MediaClientCode), "NULL", "'" & Me.MediaClientCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.MediaDivisionCode), "NULL", "'" & Me.MediaDivisionCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.MediaProductCode), "NULL", "'" & Me.MediaProductCode & "'"), _
                                                                         If(String.IsNullOrEmpty(Me.Month), "NULL", "'" & Me.Month & "'"), _
                                                                         If(Me.Year IsNot Nothing, Me.Year, "NULL"))).ToList

                                If AccountPayableAvailableRadioOrdersList.Where(Function(O) O.OrderNumber = CInt(PropertyValue)).Any = False Then

                                    IsValid = False

                                    ErrorText = "Order Number is required."

                                End If

                            Case "M"

                                AccountPayableAvailableMagazineOrdersList = ObjectContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.AccountPayableAvailableMagazineOrders) _
                                                                                (String.Format("exec advsp_ap_available_magazine_orders {0},{1},{2},{3},{4}", _
                                                                                 If(AllowVendorNotOnOrder, "NULL", "'" & Me.VendorCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(OfficeCode), "NULL", "'" & OfficeCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaClientCode), "NULL", "'" & Me.MediaClientCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaDivisionCode), "NULL", "'" & Me.MediaDivisionCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaProductCode), "NULL", "'" & Me.MediaProductCode & "'"))).ToList

                                If AccountPayableAvailableMagazineOrdersList.Where(Function(O) O.OrderNumber = CInt(PropertyValue)).Any = False Then

                                    IsValid = False

                                    ErrorText = "Order Number is required."

                                End If

                            Case "I"

                                AccountPayableAvailableInternetOrdersList = ObjectContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.AccountPayableAvailableInternetOrders) _
                                                                                (String.Format("exec advsp_ap_available_internet_orders {0},{1},{2},{3},{4}", _
                                                                                 If(AllowVendorNotOnOrder, "NULL", "'" & Me.VendorCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(OfficeCode), "NULL", "'" & OfficeCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaClientCode), "NULL", "'" & Me.MediaClientCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaDivisionCode), "NULL", "'" & Me.MediaDivisionCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaProductCode), "NULL", "'" & Me.MediaProductCode & "'"))).ToList

                                If AccountPayableAvailableInternetOrdersList.Where(Function(O) O.OrderNumber = CInt(PropertyValue)).Any = False Then

                                    IsValid = False

                                    ErrorText = "Order Number is required."

                                End If

                            Case "N"

                                AccountPayableAvailableNewspaperOrdersList = ObjectContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.AccountPayableAvailableNewspaperOrders) _
                                                                                (String.Format("exec advsp_ap_available_newspaper_orders {0},{1},{2},{3},{4}", _
                                                                                 If(AllowVendorNotOnOrder, "NULL", "'" & Me.VendorCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(OfficeCode), "NULL", "'" & OfficeCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaClientCode), "NULL", "'" & Me.MediaClientCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaDivisionCode), "NULL", "'" & Me.MediaDivisionCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaProductCode), "NULL", "'" & Me.MediaProductCode & "'"))).ToList

                                If AccountPayableAvailableNewspaperOrdersList.Where(Function(O) O.OrderNumber = CInt(PropertyValue)).Any = False Then

                                    IsValid = False

                                    ErrorText = "Order Number is required."

                                End If

                            Case "O"

                                AccountPayableAvailableOutOfHomeOrdersList = ObjectContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.AccountPayableAvailableOutOfHomeOrders) _
                                                                                (String.Format("exec advsp_ap_available_outofhome_orders {0},{1},{2},{3},{4}", _
                                                                                 If(AllowVendorNotOnOrder, "NULL", "'" & Me.VendorCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(OfficeCode), "NULL", "'" & OfficeCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaClientCode), "NULL", "'" & Me.MediaClientCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaDivisionCode), "NULL", "'" & Me.MediaDivisionCode & "'"), _
                                                                                 If(String.IsNullOrEmpty(Me.MediaProductCode), "NULL", "'" & Me.MediaProductCode & "'"))).ToList

                                If AccountPayableAvailableOutOfHomeOrdersList.Where(Function(O) O.OrderNumber = CInt(PropertyValue)).Any = False Then

                                    IsValid = False

                                    ErrorText = "Order Number is required."

                                End If

                        End Select

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

