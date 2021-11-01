Namespace AccountReceivable.Classes

    <Serializable()>
    Public Class ImportAccountReceivableStaging
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsOnHold
            ImportARInvoiceNumber
            ClientCode
            DivisionCode
            ProductCode
            OfficeCode
            InvoiceDate
            InvoiceAmount
            SaleAmount
            CostOfSalesAmount
            OffsetAmount
            StateAmount
            CountyAmount
            CityAmount
            GLACodeAR
            GLACodeSales
            GLACodeCOS
            GLACodeOffset
            GLACodeState
            GLACodeCounty
            GLACodeCity
            SalesClassCode
            ClientPO
            RecordType
            DueDate
        End Enum

#End Region

#Region " Variables "

        Private _AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
        Private _Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
        Private _Products As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
        Private _GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
        'Private _GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing
        Private _SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
        Private _Offices As Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing
        Private _DistinctARDescriptions As Generic.List(Of String) = Nothing
        Private _Modified As Boolean = False

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
        Public WriteOnly Property Clients As Generic.List(Of AdvantageFramework.Database.Core.Client)
            Set(value As Generic.List(Of AdvantageFramework.Database.Core.Client))
                _Clients = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division)
            Set(value As Generic.List(Of AdvantageFramework.Database.Core.Division))
                _Divisions = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property Products As Generic.List(Of AdvantageFramework.Database.Core.Product)
            Set(value As Generic.List(Of AdvantageFramework.Database.Core.Product))
                _Products = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)
            Set(value As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount))
                _GeneralLedgerAccounts = value
            End Set
        End Property
        '<System.ComponentModel.Browsable(False), _
        'Xml.Serialization.XmlIgnore()> _
        'Public WriteOnly Property GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference)
        '    Set(value As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference))
        '        _GeneralLedgerOfficeCrossReferences = value
        '    End Set
        'End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public WriteOnly Property SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass))
                _SalesClasses = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property Offices As Generic.List(Of AdvantageFramework.Database.Core.Office)
            Set(value As Generic.List(Of AdvantageFramework.Database.Core.Office))
                _Offices = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property DistinctARDescriptions As Generic.List(Of String)
            Set(value As Generic.List(Of String))
                _DistinctARDescriptions = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public ReadOnly Property AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging
            Get
                AccountReceivableImportStaging = _AccountReceivableImportStaging
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsOnHold() As Boolean
            Get
                IsOnHold = _AccountReceivableImportStaging.IsOnHold.GetValueOrDefault(False)
            End Get
            Set(value As Boolean)
                _AccountReceivableImportStaging.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Import A/R Invoice Number")>
        Public Property ImportARInvoiceNumber() As String
            Get
                ImportARInvoiceNumber = _AccountReceivableImportStaging.ImportARInvoiceNumber
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.ImportARInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _AccountReceivableImportStaging.ClientCode
            End Get
            Set(value As String)
                If value Is Nothing Then
                    _AccountReceivableImportStaging.ClientCode = ""
                Else
                    _AccountReceivableImportStaging.ClientCode = value
                End If
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _AccountReceivableImportStaging.DivisionCode
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _AccountReceivableImportStaging.ProductCode
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Office", PropertyType:=BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountReceivableImportStaging.OfficeCode
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
                If value Is Nothing Then
                    _AccountReceivableImportStaging.InvoiceDate = ""
                Else
                    _AccountReceivableImportStaging.InvoiceDate = Format(CInt(_InvoiceDate.Value.Month), "0#") & "/" & Format(CInt(_InvoiceDate.Value.Day), "0#") & "/" & CInt(Mid(_InvoiceDate.Value.Year, 3, 2))
                End If
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property InvoiceAmount() As Nullable(Of Decimal)
            Get
                InvoiceAmount = _AccountReceivableImportStaging.InvoiceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.InvoiceAmount = value.GetValueOrDefault(0)
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", CustomColumnCaption:="Sales Amount")>
        Public Property SaleAmount() As Nullable(Of Decimal)
            Get
                SaleAmount = _AccountReceivableImportStaging.SaleAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.SaleAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Cost of Sales Amount")>
        Public Property CostOfSalesAmount() As Nullable(Of Decimal)
            Get
                CostOfSalesAmount = _AccountReceivableImportStaging.CostOfSalesAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.CostOfSalesAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OffsetAmount() As Nullable(Of Decimal)
            Get
                OffsetAmount = _AccountReceivableImportStaging.OffsetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.OffsetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="State Resale Amount")>
        Public Property StateAmount() As Nullable(Of Decimal)
            Get
                StateAmount = _AccountReceivableImportStaging.StateAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.StateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="County Resale Amount")>
        Public Property CountyAmount() As Nullable(Of Decimal)
            Get
                CountyAmount = _AccountReceivableImportStaging.CountyAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.CountyAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="City Resale Amount")>
        Public Property CityAmount() As Nullable(Of Decimal)
            Get
                CityAmount = _AccountReceivableImportStaging.CityAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AccountReceivableImportStaging.CityAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="A/R Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeAR() As String
            Get
                GLACodeAR = _AccountReceivableImportStaging.GLACodeAR
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeAR = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Sales Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeSales() As String
            Get
                GLACodeSales = _AccountReceivableImportStaging.GLACodeSales
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Cost of Sales Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeCOS() As String
            Get
                GLACodeCOS = _AccountReceivableImportStaging.GLACodeCOS
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeCOS = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Offset Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeOffset() As String
            Get
                GLACodeOffset = _AccountReceivableImportStaging.GLACodeOffset
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeOffset = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="State Tax Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeState() As String
            Get
                GLACodeState = _AccountReceivableImportStaging.GLACodeState
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeState = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="County Tax Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeCounty() As String
            Get
                GLACodeCounty = _AccountReceivableImportStaging.GLACodeCounty
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeCounty = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="City Tax Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeCity() As String
            Get
                GLACodeCity = _AccountReceivableImportStaging.GLACodeCity
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.GLACodeCity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class", PropertyType:=BaseClasses.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _AccountReceivableImportStaging.SalesClassCode
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientPO() As String
            Get
                ClientPO = _AccountReceivableImportStaging.ClientPO
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Type")>
        Public Property RecordType() As String
            Get
                RecordType = _AccountReceivableImportStaging.RecordType
            End Get
            Set(value As String)
                _AccountReceivableImportStaging.RecordType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _AccountReceivableImportStaging.DueDate
            End Get
            Set(value As Nullable(Of Date))
                _AccountReceivableImportStaging.DueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property RecordNumber() As Integer
            Get
                RecordNumber = _AccountReceivableImportStaging.RecordNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified() As Boolean
            Get
                Modified = _Modified
            End Get
            Set(value As Boolean)
                _Modified = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging)

            Dim MDY As String() = Nothing
            
            _AccountReceivableImportStaging = AccountReceivableImportStaging

            If Not String.IsNullOrEmpty(AccountReceivableImportStaging.InvoiceDate) Then

                MDY = AccountReceivableImportStaging.InvoiceDate.Split("/")

                If UBound(MDY) = 2 Then

                    Try

                        _InvoiceDate = DateSerial(MDY(2), MDY(0), MDY(1))

                    Catch ex As Exception
                        _InvoiceDate = Nothing
                    End Try
                    
                End If
                
            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = _AccountReceivableImportStaging.RecordNumber

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Function CustomValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

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
        Public Overrides Sub SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCOS.ToString

                        If Me.CostOfSalesAmount <> 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeOffset.ToString

                        If Me.OffsetAmount <> 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCity.ToString

                        If Me.CityAmount <> 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCounty.ToString

                        If Me.CountyAmount <> 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeState.ToString

                        If Me.StateAmount <> 0 Then

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
            Dim Session As AdvantageFramework.Security.Session = Nothing
            'Dim GeneralLedgerOfficeCrossReferenceCode As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ImportARInvoiceNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _DistinctARDescriptions Is Nothing Then

                            _DistinctARDescriptions = AdvantageFramework.AccountReceivable.GetDistinctARDescriptions(DbContext)

                        End If

                        If _DistinctARDescriptions.Contains(PropertyValue) Then

                            IsValid = False

                            ErrorText = "Invoice number exists."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ClientCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _Clients Is Nothing Then

                            _Clients = AdvantageFramework.AccountReceivable.GetActiveClients(DbContext)

                        End If

                        If _Clients.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid client."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.DivisionCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _Divisions Is Nothing Then

                            _Divisions = AdvantageFramework.AccountReceivable.GetActiveDivisions(DbContext)

                        End If

                        If _Divisions.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String) AndAlso
                                                             Entity.ClientCode = Me.ClientCode).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid division."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ProductCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _Products Is Nothing Then

                            _Products = AdvantageFramework.AccountReceivable.GetActiveProducts(DbContext)

                        End If

                        If _Products.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String) AndAlso
                                                            Entity.ClientCode = Me.ClientCode AndAlso
                                                            Entity.DivisionCode = Me.DivisionCode).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid product."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.OfficeCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _Offices Is Nothing Then

                            _Offices = AdvantageFramework.AccountReceivable.GetActiveOffices(DbContext)

                        End If

                        If _Offices.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid office."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.SalesClassCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _SalesClasses Is Nothing Then

                            _SalesClasses = AdvantageFramework.AccountReceivable.GetActiveSalesClasses(DbContext)

                        End If

                        If (From Entity In AdvantageFramework.AccountReceivable.GetActiveSalesClassesByRecordType(_SalesClasses, Me.RecordType)
                            Where Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid sales class."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeAR.ToString,
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCity.ToString,
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCOS.ToString,
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCounty.ToString,
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeOffset.ToString,
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeSales.ToString,
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeState.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _GeneralLedgerAccounts Is Nothing Then

                            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                            '_GeneralLedgerAccounts = AdvantageFramework.AccountReceivable.GetActiveGeneralLedgerAccounts(DbContext)
                            _GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session)).ToList

                        End If

                        'If _GeneralLedgerOfficeCrossReferences Is Nothing Then

                        '    _GeneralLedgerOfficeCrossReferences = AdvantageFramework.AccountReceivable.GetGeneralLedgerOfficeCrossReferences(DbContext)

                        'End If

                        'Try

                        '    GeneralLedgerOfficeCrossReferenceCode = (From Entity In _GeneralLedgerOfficeCrossReferences _
                        '                                             Where Entity.OfficeCode = Me.OfficeCode
                        '                                             Select Entity).SingleOrDefault.Code

                        'Catch ex As Exception
                        '    GeneralLedgerOfficeCrossReferenceCode = Nothing
                        'End Try

                        'If _GeneralLedgerAccounts.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String) AndAlso _
                        '                                                 (GeneralLedgerOfficeCrossReferenceCode IsNot Nothing AndAlso _
                        '                                                 Entity.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReferenceCode) OrElse _
                        '                                                 GeneralLedgerOfficeCrossReferenceCode Is Nothing).Any = False Then

                        '    IsValid = False

                        '    ErrorText = "Please enter a valid GL account."

                        'End If

                        If _GeneralLedgerAccounts.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid GL account."

                        End If

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.InvoiceAmount.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Invoice amount cannot be zero."

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.SaleAmount.ToString

                    PropertyValue = Value

                    If (PropertyValue) <> (InvoiceAmount - (StateAmount + CountyAmount + CityAmount)) Then

                        IsValid = False

                        ErrorText = "Sales plus total tax amount must equal invoice amount."

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.OffsetAmount.ToString

                    PropertyValue = Value

                    If PropertyValue <> Me.CostOfSalesAmount Then

                        IsValid = False

                        ErrorText = "Offset amount must equal cost of sales amount."

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.InvoiceAmount.ToString

                    PropertyValue = Value

                    If PropertyValue + Me.CostOfSalesAmount <> (Me.SaleAmount + Me.OffsetAmount + Me.StateAmount + Me.CountyAmount + Me.CityAmount) Then

                        IsValid = False

                        ErrorText = "Invoice amount plus cost of sales amount must equal sales plus offset plus total tax."

                    End If

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.RecordType.ToString

                    PropertyValue = Value

                    If PropertyValue <> "M" AndAlso PropertyValue <> "P" Then

                        IsValid = False

                        ErrorText = "Invalid type."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Protected Overrides Sub ClearNonRequiredPropertiesWithInvalidBlankValues(ByVal PropertyName As String, ByRef Value As Object)

            Select Case PropertyName

                Case AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.DivisionCode.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.ProductCode.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCity.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCOS.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeCounty.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeOffset.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.GLACodeState.ToString, _
                        AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.SalesClassCode.ToString
                    
                    Value = Nothing

            End Select

        End Sub

#End Region

    End Class

End Namespace

