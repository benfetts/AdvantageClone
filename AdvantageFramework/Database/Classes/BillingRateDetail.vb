Namespace Database.Classes

    <Serializable()>
    Public Class BillingRateDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BillingRateLevelID
            EmployeeCode
            EmployeeName
            EmployeeOfficeCode
            FunctionCode
            FunctionDescription
            FunctionType
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ProductOfficeCode
            SalesClassCode
            SalesClassDescription
            EffectiveDate
            RateAmount
            IsNonBillable
            IsFeeTime
            IsTaxCommission
            TaxCommission
            TaxCommissionOnly
            IsCommission
            IsTax
            TaxCode
            IsInactive
            EmployeeTitleID
            CurrentEmployeeTitleID
        End Enum

#End Region

#Region " Variables "

        Private _BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
        Private _ID As Integer = Nothing
        Private _BillingRateLevelID As Short = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeOfficeCode As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _ProductOfficeCode As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _EffectiveDate As Nullable(Of Date) = Nothing
        Private _RateAmount As Nullable(Of Decimal) = Nothing
        Private _IsNonBillable As Nullable(Of Short) = Nothing
        Private _IsFeeTime As Nullable(Of Short) = Nothing
        Private _IsTaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _IsCommission As Nullable(Of Decimal) = Nothing
        Private _IsTax As Nullable(Of Short) = Nothing
        Private _TaxCode As String = Nothing
        Private _IsInactive As Nullable(Of Short) = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
        Private _CurrentEmployeeTitleID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BillingRateLevelID() As Short
            Get
                BillingRateLevelID = _BillingRateLevelID
            End Get
            Set(ByVal value As Short)
                _BillingRateLevelID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Office", IsReadOnlyColumn:=True)>
        Public Property ProductOfficeCode() As String
            Get
                ProductOfficeCode = _ProductOfficeCode
            End Get
            Set(ByVal value As String)
                _ProductOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class", PropertyType:=BaseClasses.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.SalesClassDescription)>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function Type", IsReadOnlyColumn:=True)>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Current Employee Title", PropertyType:=BaseClasses.PropertyTypes.EmployeeTitleID)>
        Public Property CurrentEmployeeTitleID() As Nullable(Of Integer)
            Get
                CurrentEmployeeTitleID = _CurrentEmployeeTitleID
            End Get
            Set(value As Nullable(Of Integer))
                _CurrentEmployeeTitleID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Title", PropertyType:=BaseClasses.PropertyTypes.EmployeeTitleID)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
            Get
                EmployeeTitleID = _EmployeeTitleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EmployeeTitleID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Name", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.EmployeeName)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Office", IsReadOnlyColumn:=True)>
        Public Property EmployeeOfficeCode() As String
            Get
                EmployeeOfficeCode = _EmployeeOfficeCode
            End Get
            Set(ByVal value As String)
                _EmployeeOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EffectiveDate() As Nullable(Of Date)
            Get
                EffectiveDate = _EffectiveDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _EffectiveDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F3", CustomColumnCaption:="Rate")>
        Public Property RateAmount() As Nullable(Of Decimal)
            Get
                RateAmount = _RateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Non Billable")>
        Public Property IsNonBillable() As Nullable(Of Short)
            Get
                IsNonBillable = _IsNonBillable
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsNonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Markup Tax Flags")>
        Public Property IsTaxCommission() As Nullable(Of Short)
            Get
                IsTaxCommission = _IsTaxCommission
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsTaxCommission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TaxCommission() As Nullable(Of Short)
            Get
                GetTaxCommissionDetails()
                TaxCommission = _TaxCommission
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                GetTaxCommissionDetails()
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F3", CustomColumnCaption:="Markup Percent")>
        Public Property IsCommission() As Nullable(Of Decimal)
            Get
                IsCommission = _IsCommission
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _IsCommission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Tax Flag")>
        Public Property IsTax() As Nullable(Of Short)
            Get
                IsTax = _IsTax
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(ByVal value As String)
                _TaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Fee Time")>
        Public Property IsFeeTime() As Nullable(Of Short)
            Get
                IsFeeTime = _IsFeeTime
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsFeeTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(ByVal BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail, ByVal [Function] As AdvantageFramework.Database.Core.Function,
                       ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal Client As AdvantageFramework.Database.Core.Client,
                       ByVal Division As AdvantageFramework.Database.Core.Division, ByVal Product As AdvantageFramework.Database.Core.Product,
                       ByVal SalesClass As AdvantageFramework.Database.Entities.SalesClass)

            'objects
            'Dim [Function] As AdvantageFramework.Database.Core.Function = Nothing
            'Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            'Dim Client As AdvantageFramework.Database.Core.Client = Nothing
            'Dim Division As AdvantageFramework.Database.Core.Division = Nothing
            'Dim Product As AdvantageFramework.Database.Core.Product = Nothing
            'Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

            _BillingRateDetail = BillingRateDetail

            _ID = BillingRateDetail.ID
            _BillingRateLevelID = BillingRateDetail.BillingRateLevelID
            _EmployeeCode = BillingRateDetail.EmployeeCode
            _FunctionCode = BillingRateDetail.FunctionCode
            _ClientCode = BillingRateDetail.ClientCode
            _DivisionCode = BillingRateDetail.DivisionCode
            _ProductCode = BillingRateDetail.ProductCode
            _SalesClassCode = BillingRateDetail.SalesClassCode
            _EffectiveDate = BillingRateDetail.EffectiveDate
            _RateAmount = BillingRateDetail.RateAmount
            _IsNonBillable = BillingRateDetail.IsNonBillable
            _IsFeeTime = BillingRateDetail.IsFeeTime
            _IsTaxCommission = BillingRateDetail.IsTaxCommission
            _IsCommission = BillingRateDetail.IsCommission
            _IsTax = BillingRateDetail.IsTax
            _TaxCode = BillingRateDetail.TaxCode
            _IsInactive = BillingRateDetail.IsInactive
            _EmployeeTitleID = BillingRateDetail.EmployeeTitleID

            'If String.IsNullOrEmpty(_BillingRateDetail.ClientCode) = False Then

            '    Try

            '        Client = Clients.SingleOrDefault(Function(Entity) Entity.Code = _BillingRateDetail.ClientCode)

            '    Catch ex As Exception
            '        Client = Nothing
            '    End Try

            If Client IsNot Nothing Then

                _ClientName = Client.Name

            End If

            'End If

            'If String.IsNullOrEmpty(_BillingRateDetail.ClientCode) = False AndAlso String.IsNullOrEmpty(_BillingRateDetail.DivisionCode) = False Then

            '    Try

            '        Division = Divisions.SingleOrDefault(Function(Entity) Entity.Code = _BillingRateDetail.DivisionCode AndAlso Entity.ClientCode = _BillingRateDetail.ClientCode)

            '    Catch ex As Exception
            '        Division = Nothing
            '    End Try

            If Division IsNot Nothing Then

                _DivisionName = Division.Name

            End If

            'End If

            'If String.IsNullOrEmpty(_BillingRateDetail.ClientCode) = False AndAlso String.IsNullOrEmpty(_BillingRateDetail.DivisionCode) = False AndAlso String.IsNullOrEmpty(_BillingRateDetail.ProductCode) = False Then

            '    Try

            '        Product = Products.SingleOrDefault(Function(Entity) Entity.Code = _BillingRateDetail.ProductCode AndAlso Entity.DivisionCode = _BillingRateDetail.DivisionCode AndAlso Entity.ClientCode = _BillingRateDetail.ClientCode)

            '    Catch ex As Exception
            '        Product = Nothing
            '    End Try

            If Product IsNot Nothing Then

                _ProductName = Product.Name

            End If

            'End If

            'If String.IsNullOrEmpty(_BillingRateDetail.SalesClassCode) = False Then

            '    Try

            '        SalesClass = SalesClasses.SingleOrDefault(Function(Entity) Entity.Code = _BillingRateDetail.SalesClassCode)

            '    Catch ex As Exception
            '        SalesClass = Nothing
            '    End Try

            If SalesClass IsNot Nothing Then

                _SalesClassDescription = SalesClass.Description

            End If

            'End If

            'If String.IsNullOrEmpty(_BillingRateDetail.FunctionCode) = False Then

            '    Try

            '        [Function] = Functions.SingleOrDefault(Function(Entity) Entity.Code = _BillingRateDetail.FunctionCode)

            '    Catch ex As Exception
            '        [Function] = Nothing
            '    End Try

            If [Function] IsNot Nothing Then

                _FunctionType = [Function].Type
                _FunctionDescription = [Function].Description

            End If

            'End If

            'If String.IsNullOrEmpty(_BillingRateDetail.EmployeeCode) = False Then

            '    Try

            '        Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = _BillingRateDetail.EmployeeCode)

            '    Catch ex As Exception
            '        Employee = Nothing
            '    End Try

            If Employee IsNot Nothing Then

                _CurrentEmployeeTitleID = Employee.EmployeeTitleID
                _EmployeeName = Employee.ToString

            End If

            ' End If

        End Sub
        Private Sub GetTaxCommissionDetails()

            Try

                Select Case _IsTaxCommission

                    Case Entities.MarkupTaxFlags.MarkupNotTaxable

                        _TaxCommission = CShort(0)
                        _TaxCommissionOnly = CShort(0)

                    Case Entities.MarkupTaxFlags.TaxMarkup

                        _TaxCommission = CShort(1)
                        _TaxCommissionOnly = CShort(0)

                    Case Entities.MarkupTaxFlags.TaxMarkupOnly

                        _TaxCommission = CShort(0)
                        _TaxCommissionOnly = CShort(1)

                    Case Else

                        _TaxCommission = Nothing
                        _TaxCommissionOnly = Nothing

                End Select

            Catch ex As Exception
                _TaxCommission = Nothing
                _TaxCommissionOnly = Nothing
            End Try

        End Sub
        Public Function GetBillingRateDetail(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.BillingRateDetail

            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing

            If _BillingRateDetail Is Nothing AndAlso Me.ID > 0 Then

                _BillingRateDetail = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateDetailID(DbContext, Me.ID)

            End If

            If _BillingRateDetail Is Nothing Then

                BillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

            Else

                BillingRateDetail = _BillingRateDetail

            End If

            BillingRateDetail.ID = _ID
            BillingRateDetail.BillingRateLevelID = _BillingRateLevelID
            BillingRateDetail.EmployeeCode = _EmployeeCode
            BillingRateDetail.FunctionCode = _FunctionCode
            BillingRateDetail.ClientCode = _ClientCode
            BillingRateDetail.DivisionCode = _DivisionCode
            BillingRateDetail.ProductCode = _ProductCode
            BillingRateDetail.SalesClassCode = _SalesClassCode
            BillingRateDetail.EffectiveDate = _EffectiveDate
            BillingRateDetail.RateAmount = _RateAmount
            BillingRateDetail.IsNonBillable = _IsNonBillable
            BillingRateDetail.IsFeeTime = _IsFeeTime
            BillingRateDetail.IsTaxCommission = _IsTaxCommission
            BillingRateDetail.IsCommission = _IsCommission
            BillingRateDetail.IsTax = _IsTax
            BillingRateDetail.TaxCode = _TaxCode
            BillingRateDetail.IsInactive = _IsInactive
            BillingRateDetail.EmployeeTitleID = _EmployeeTitleID

            If BillingRateDetail.IsEntityBeingAdded() AndAlso BillingRateDetail.ID <> 0 Then

                DbContext.BillingRateDetails.Attach(BillingRateDetail)

            End If

            GetBillingRateDetail = BillingRateDetail

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            _BillingRateDetail = GetBillingRateDetail(_DbContext)

            SetRequiredFields()

            _BillingRateDetail.DbContext = _DbContext

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            Try

                BillingRateLevel = (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).BillingRateLevels
                                    Where Entity.ID = Me.BillingRateLevelID
                                    Select Entity).FirstOrDefault

            Catch ex As Exception
                BillingRateLevel = Nothing
            End Try

            If BillingRateLevel IsNot Nothing Then

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(_BillingRateDetail).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each PropertyDescriptor In PropertyDescriptors

                    Select Case PropertyDescriptor.Name

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.ClientCode.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsClientIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.DivisionCode.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.ProductCode.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.SalesClassCode.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.FunctionCode.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.EmployeeTitleID.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.EmployeeCode.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.EffectiveDate.ToString

                            SetRequired(PropertyDescriptor, BillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0))

                    End Select

                Next

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ' Objects
            Dim ErrorText As String = ""

            ErrorText = _BillingRateDetail.ValidateEntityProperty(PropertyName, IsValid, Value)

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing

            _BillingRateDetail = GetBillingRateDetail(_DbContext)

            _BillingRateDetail.DbContext = _DbContext

            ErrorText = _BillingRateDetail.ValidateEntityProperty(PropertyName, IsValid, Value)

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace
