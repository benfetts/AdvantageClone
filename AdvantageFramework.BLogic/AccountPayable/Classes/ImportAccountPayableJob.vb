Namespace AccountPayable.Classes

    <Serializable()>
    Public Class ImportAccountPayableJob
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportAccountPayableID
            PONumber
            POLine
            JobNumber
            JobComponentNumber
            FunctionCode
            JobQuantity
            JobNetAmount
            JobVendorTax
            JobGLACode
            JobComment
            JobOfficeCode
            JobClientCode
            ClientName
            JobDivisionCode
            DivisionName
            JobProductCode
            ProductName
            PreviouslyPostedNetAmount
            PONetAmount
            PONetVariance
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
        Private _ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader = Nothing
        Private _PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _AccountPayableProductionPurchaseOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders) = Nothing
        Private _PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing
        Private _AccountPayableAvailableProductionJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs) = Nothing
        Private _JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
        Private _Functions As IEnumerable = Nothing

#End Region

#Region " Properties "

        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor)
            Set(value As Generic.List(Of System.ComponentModel.PropertyDescriptor))
                _PropertyDescriptors = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property AccountPayableProductionPurchaseOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders))
                _AccountPayableProductionPurchaseOrders = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail))
                _PurchaseOrderDetails = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property AccountPayableAvailableProductionJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs)
            Set(value As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs))
                _AccountPayableAvailableProductionJobs = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent))
                _JobComponents = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property Functions As IEnumerable
            Set(value As IEnumerable)
                _Functions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayableJob.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableID() As Integer
            Get
                ImportAccountPayableID = _ImportAccountPayableJob.ImportAccountPayableID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PONumber() As Nullable(Of Integer)
            Get
                PONumber = _ImportAccountPayableJob.PONumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property POLine() As Nullable(Of Integer)
            Get
                POLine = _ImportAccountPayableJob.POLine
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.POLine = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _ImportAccountPayableJob.JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _ImportAccountPayableJob.JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableJob.JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _ImportAccountPayableJob.FunctionCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobQuantity() As Nullable(Of Decimal)
            Get
                JobQuantity = _ImportAccountPayableJob.JobQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property JobNetAmount() As Nullable(Of Decimal)
            Get
                JobNetAmount = _ImportAccountPayableJob.JobNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobVendorTax() As Nullable(Of Decimal)
            Get
                JobVendorTax = _ImportAccountPayableJob.JobVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property JobGLACode() As String
            Get
                JobGLACode = _ImportAccountPayableJob.GLACode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComment() As String
            Get
                JobComment = _ImportAccountPayableJob.JobComment
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobOfficeCode() As String
            Get
                JobOfficeCode = _ImportAccountPayableJob.OfficeCodeDetail
            End Get
            Set(value As String)
                _ImportAccountPayableJob.OfficeCodeDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, CustomColumnCaption:="Client Code")>
        Public Property JobClientCode() As String
            Get
                JobClientCode = _ImportAccountPayableJob.ClientCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ImportAccountPayableJob.ClientName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, CustomColumnCaption:="Division Code")>
        Public Property JobDivisionCode() As String
            Get
                JobDivisionCode = _ImportAccountPayableJob.DivisionCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _ImportAccountPayableJob.DivisionName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, CustomColumnCaption:="Product Code")>
        Public Property JobProductCode() As String
            Get
                JobProductCode = _ImportAccountPayableJob.ProductCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
            Get
                ProductName = _ImportAccountPayableJob.ProductName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PreviouslyPostedNetAmount() As Nullable(Of Decimal)
            Get
                PreviouslyPostedNetAmount = _ImportAccountPayableJob.PreviouslyPostedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.PreviouslyPostedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PONetAmount() As Nullable(Of Decimal)
            Get
                PONetAmount = _ImportAccountPayableJob.PONetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.PONetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public ReadOnly Property PONetVariance() As Nullable(Of Decimal)
            Get
                If _ImportAccountPayableJob.ID <> 0 AndAlso _ImportAccountPayableJob.PONumber IsNot Nothing Then
                    PONetVariance = PONetAmount.GetValueOrDefault(0) - (JobNetAmount.GetValueOrDefault(0) + JobVendorTax.GetValueOrDefault(0) + PreviouslyPostedNetAmount.GetValueOrDefault(0))
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _ImportAccountPayableHeader.OfficeCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsNonBillable() As Nullable(Of Short)
            Get
                IsNonBillable = _ImportAccountPayableJob.IsNonBillable.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableJob.IsNonBillable = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableJob = New AdvantageFramework.Database.Entities.ImportAccountPayableJob
            _ImportAccountPayableHeader = New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader

        End Sub
        Public Sub New(ByVal ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob,
                       ByVal ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader)

            _ImportAccountPayableJob = ImportAccountPayableJob
            _ImportAccountPayableHeader = ImportAccountPayableHeader

        End Sub
        Public Sub SetBillingRateFlags(ByVal BillingRate As AdvantageFramework.Database.Classes.BillingRate)

            If BillingRate Is Nothing Then

                _ImportAccountPayableJob.IsNonBillable = 0
                _ImportAccountPayableJob.CommissionPercent = 0
                _ImportAccountPayableJob.TaxCommission = 0
                _ImportAccountPayableJob.TaxCommissionOnly = 0
                _ImportAccountPayableJob.SalesTaxCode = Nothing
                _ImportAccountPayableJob.Rate = Nothing

            Else

                _ImportAccountPayableJob.IsNonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                _ImportAccountPayableJob.CommissionPercent = BillingRate.COMM.GetValueOrDefault(0)
                _ImportAccountPayableJob.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                _ImportAccountPayableJob.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)
                _ImportAccountPayableJob.SalesTaxCode = BillingRate.TAX_CODE

                If BillingRate.BILLING_RATE.GetValueOrDefault(0) <> 0 Then

                    _ImportAccountPayableJob.Rate = BillingRate.BILLING_RATE

                End If

            End If

        End Sub
        Public Sub SetBillingRateFlags(ByVal BillingRate As AdvantageFramework.Database.Classes.BillingRate,
                                       ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail)

            If BillingRate Is Nothing Then

                _ImportAccountPayableJob.TaxCommission = 0
                _ImportAccountPayableJob.TaxCommissionOnly = 0

            Else

                _ImportAccountPayableJob.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                _ImportAccountPayableJob.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

            End If

            If PurchaseOrderDetail.Job IsNot Nothing AndAlso PurchaseOrderDetail.Job.Product IsNot Nothing Then

                _ImportAccountPayableJob.SalesTaxCode = PurchaseOrderDetail.Job.Product.ProductionTaxCode

            End If

            _ImportAccountPayableJob.CommissionPercent = BillingRate.COMM.GetValueOrDefault(0)

            If BillingRate.BILLING_RATE.GetValueOrDefault(0) <> 0 Then

                _ImportAccountPayableJob.Rate = BillingRate.BILLING_RATE

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = _ImportAccountPayableJob.ID

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportAccountPayableJob

            GetEntity = _ImportAccountPayableJob

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

                    Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.POLine.ToString

                        If Me.PONumber IsNot Nothing Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.JobOfficeCode.ToString

                        If _ImportAccountPayableHeader.IsInterCompanyTransactionsEnabled OrElse _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
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

            SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                If PropertyDescriptor.Attributes.OfType(Of System.Xml.Serialization.XmlIgnoreAttribute).Any = False AndAlso
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

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyName, Value)

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            CustomValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim IsValidFunction As Boolean = False

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.JobOfficeCode.ToString

                    PropertyValue = Value

                    If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso _ImportAccountPayableHeader.OfficeCode <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Office does not match header."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.PONumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso _ImportAccountPayableHeader.VendorCode IsNot Nothing Then

                        If _AccountPayableProductionPurchaseOrders Is Nothing Then

                            _AccountPayableProductionPurchaseOrders = AdvantageFramework.AccountPayable.GetOpenPurchaseOrders(DbContext, DbContext.UserCode)

                        End If

                        If Not _AccountPayableProductionPurchaseOrders.Where(Function(Entity) Entity.VendorCode = _ImportAccountPayableHeader.VendorCode AndAlso Entity.Number = DirectCast(PropertyValue, Integer)).Any Then

                            IsValid = False

                            ErrorText = "Invalid PO Number."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.POLine.ToString

                    PropertyValue = Value

                    If Me.PONumber IsNot Nothing Then

                        If _PurchaseOrderDetails Is Nothing Then

                            _PurchaseOrderDetails = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadAllIncomplete(DbContext).ToList

                        End If

                        If Not (From Entity In _PurchaseOrderDetails
                                Where Entity.PurchaseOrderNumber = Me.PONumber AndAlso
                                      Entity.LineNumber = DirectCast(PropertyValue, Integer)
                                Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Invalid PO Line."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.JobNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _AccountPayableAvailableProductionJobs Is Nothing Then

                            _AccountPayableAvailableProductionJobs = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, Nothing, Nothing, Nothing, Nothing)

                        End If

                        If _AccountPayableAvailableProductionJobs.Where(Function(Entity) Entity.Number = DirectCast(PropertyValue, Integer) AndAlso
                                Entity.ClientCode = If(Me.JobClientCode IsNot Nothing, Me.JobClientCode, Entity.ClientCode) AndAlso
                                Entity.DivisionCode = If(Me.JobDivisionCode IsNot Nothing, Me.JobDivisionCode, Entity.DivisionCode) AndAlso
                                Entity.ProductCode = If(Me.JobProductCode IsNot Nothing, Me.JobProductCode, Entity.ProductCode) AndAlso
                                (_ImportAccountPayableHeader.IsAPLimitByOfficeEnabled = False OrElse (_ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso Entity.OfficeCode = _ImportAccountPayableHeader.OfficeCode))).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid Job Number."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.JobComponentNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.JobNumber IsNot Nothing Then

                        If _JobComponents Is Nothing Then

                            _JobComponents = AdvantageFramework.AccountPayable.GetOpenJobComponentsForJobs(DbContext)

                        End If

                        If _JobComponents.Where(Function(Entity) Entity.JobNumber = Me.JobNumber AndAlso Entity.Number = DirectCast(PropertyValue, Short)).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid job component."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob.Properties.FunctionCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _Functions Is Nothing Then

                            _Functions = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "V")

                        End If

                        For Each [Function] In _Functions

                            If [Function].Code = PropertyValue Then

                                IsValidFunction = True

                                Exit For

                            End If

                        Next

                        If Not IsValidFunction Then

                            IsValid = False

                            ErrorText = "Please enter a valid function code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

