Namespace BaseClasses

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum OperatorTypes
            IsEqualTo = 0
            DoesNotEqual = 1
            StartsWith = 2
            Contains = 3
            EndsWith = 4
        End Enum

        Public Enum PropertyTypes
            [Default]
            Email
            SocialSecurityNumber
            Code
            EmployeeCode
            FunctionCode
            ClientCode
            DivisionCode
            ProductCode
            VendorCode
            GeneralLedgerAccountCode
            OfficeCode
            CurrencyCode
            BankCode
            SalesTaxCode
            DepartmentTeamCode
            ClientContactID
            PurchaseOrderApprovalRuleCode
            ServiceFeeTypeCode
            SalesClassCode
            RoleCode
            EmployeeTitleID
            ZipCode
            VendorTermCode
            ImportVendorCategoryCode
            EmployeeFunctionCode
            VendorFunctionCode
            FunctionHeadingID
            IndirectCategoryType
            JobNumber
            PostPeriodCode
            [File]
            [Folder]
            WebsiteTypeCode
            JobComponent
            PTORule
            MarketCode
            AdSizeCode
            DaypartID
            JobVersionDatabaseType
            TaskCode
            Phase
            PartnerCode
            JobComponentID
            DaypartTypeID
            ExpenseEmployee
            Blackplate
            CycleTypes
            AccountReceivable
            CampaignDetailType
            EmployeeCategoryID
            PostPeriodStatus
            MediaPlanID
            MediaPlanDetailID
            MediaType
            IndirectCategory
            LocationID
            ProductCategory
            Status
            DaypartCode
            InvoiceCategory
            CustomProductionInvoice
            CustomMagazineInvoice
            CustomNewspaperInvoice
            CustomInternetInvoice
            CustomOutdoorInvoice
            CustomRadioInvoice
            CustomTVInvoice
            InternetType
            CampaignCode
            CampaignID
            AdNumber
            AvalaraTaxID
            OverheadAccountCode
            JobProcess
            BillingCoopCode
            ContactTypeID
            VCCStatus
            OutOfHomeType
            InternetCostType
            NewspaperCostRate
            DocumentType
            OrderProcess
            RateType
            StateCode
            JobTemplateMapping
            GeneralLedgerSource
            BuyerEmployeeCode
            AdServerAdvertiserID
            AdServerCampaignID
            AdServerSiteID
            AssignComboInvoiceBy
            AssignProductionInvoiceBy
            AssignMediaInvoiceBy
            AdServerPlacementID
            DoubleClickReportRelativeDateRange
            NielsenTVBook
            NielsenRadioPeriod
            NielsenRadioDaypart
            MediaDemographic
            CableNetworkStation
            NielsenMarket
            NielsenRadioStation
            NielsenTVStation
            BroadcastOrderLineNumber
            NCCTVSyscode
            MediaRFPAvailLineStatus
            ClientDiscount
            YearMonth
            ProductionAdvancedBillingIncome
            MediaMetric
            AlertTemplate
            AlertState
            NielsenCountyState
            Year
            BroadcastMediaType
            MediaTrafficRevision
            MediaTrafficCreativeGroup
            CampaignID2
            'StationID
            MediaChannelID
            MediaTacticID
            Assignment
            MediaPlanEstimateTemplateMediaType
            QuarterYear
            MediaPlanEstimateTemplate
            MediaPlanDetailPeriodType
        End Enum

        Public Enum DefaultColumnTypes
            [None]
            ReversedCheckBox
            StandardCheckBox
            ImageWhenCheckedCheckBox
            ColorPicker
            Memo
            JobDescription
            JobComponentDescription
            AccountReceivableSequenceNumber
            AccountReceivableType
            AccountReceivableClientCode
            OfficeName
            DepartmentTeamName
            GeneralLedgerAccountDescription
            ClientName
            DivisionName
            ProductName
            SalesClassDescription
            FunctionDescription
            EmployeeName
            VendorName
            ProductCategoryDescription
            HyperLink
            ClientContactName
            CampaignName
            AdNumberDescription
            BillingCoopDescription
            ImageWhenUnCheckedCheckBox
            TaskDescription
            CampaignCode
            MarketDescription
            AdSizeDescription
            InternetTypeDescription
            MediaPlanDetailDescription
            StateName
            BuyerEmployeeName
            Time
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        <System.Runtime.CompilerServices.Extension>
        Public Function KeyValuesFor(DbContext As System.Data.Entity.DbContext, EntityObject As Object) As Object()

            'objects
            Dim DbEntityEntry As System.Data.Entity.Infrastructure.DbEntityEntry = Nothing

            System.Diagnostics.Contracts.Contract.Requires(DbContext IsNot Nothing)
            System.Diagnostics.Contracts.Contract.Requires(EntityObject IsNot Nothing)

            DbEntityEntry = DbContext.Entry(EntityObject)

            KeyValuesFor = DbContext.KeysFor(EntityObject.[GetType]()).[Select](Function(PK) DbEntityEntry.[Property](PK).CurrentValue).ToArray()

        End Function
        <System.Runtime.CompilerServices.Extension>
        Public Function KeysFor(DbContext As System.Data.Entity.DbContext, EntityType As Type) As Generic.List(Of String)

            'objects
            Dim MetadataWorkspace As System.Data.Entity.Core.Metadata.Edm.MetadataWorkspace = Nothing
            Dim ObjectItemCollection As System.Data.Entity.Core.Metadata.Edm.ObjectItemCollection = Nothing
            Dim EdmEntityType As System.Data.Entity.Core.Metadata.Edm.EntityType = Nothing

            System.Diagnostics.Contracts.Contract.Requires(DbContext IsNot Nothing)
            System.Diagnostics.Contracts.Contract.Requires(EntityType IsNot Nothing)

            EntityType = System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(EntityType)

            MetadataWorkspace = DirectCast(DbContext, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.MetadataWorkspace
            ObjectItemCollection = DirectCast(MetadataWorkspace.GetItemCollection(System.Data.Entity.Core.Metadata.Edm.DataSpace.OSpace), System.Data.Entity.Core.Metadata.Edm.ObjectItemCollection)

            EdmEntityType = MetadataWorkspace.GetItems(Of System.Data.Entity.Core.Metadata.Edm.EntityType)(System.Data.Entity.Core.Metadata.Edm.DataSpace.OSpace).SingleOrDefault(Function(SubType) ObjectItemCollection.GetClrType(SubType) = EntityType)

            If EdmEntityType Is Nothing Then

                KeysFor = New Generic.List(Of String)

            Else

                KeysFor = EdmEntityType.KeyMembers.[Select](Function(k) k.Name).ToList

            End If

        End Function
        Public Function BuildDoesNotContainsExpression(Of TElement, TValue)(ByVal ValueSelector As System.Linq.Expressions.Expression(Of Func(Of TElement, TValue)), ByVal Values As IEnumerable(Of TValue)) As System.Linq.Expressions.Expression(Of Func(Of TElement, Boolean))

            'objects
            Dim ParameterExpression As System.Linq.Expressions.ParameterExpression = Nothing
            Dim NotEqualsExpression As System.Collections.Generic.IEnumerable(Of System.Linq.Expressions.BinaryExpression) = Nothing
            Dim BinaryExpression As System.Linq.Expressions.BinaryExpression = Nothing

            If IsNothing(ValueSelector) Then

                Throw New ArgumentNullException("ValueSelector")

            End If

            If IsNothing(Values) Then

                Throw New ArgumentNullException("Values")

            End If

            ParameterExpression = ValueSelector.Parameters.SingleOrDefault()

            If Not Values.Any Then

                BuildDoesNotContainsExpression = Function(Element) True

            Else

                NotEqualsExpression = Values.Select(Function(Value) System.Linq.Expressions.Expression.NotEqual(ValueSelector.Body, System.Linq.Expressions.Expression.Constant(Value, GetType(TValue))))

                BinaryExpression = NotEqualsExpression.Aggregate(Function(Accumulate, NotEquals) System.Linq.Expressions.Expression.And(Accumulate, NotEquals))

                BuildDoesNotContainsExpression = System.Linq.Expressions.Expression.Lambda(Of Func(Of TElement, Boolean))(BinaryExpression, ParameterExpression)

            End If

        End Function
        Public Function BuildContainsExpression(Of TElement, TValue)(ByVal ValueSelector As System.Linq.Expressions.Expression(Of Func(Of TElement, TValue)), ByVal Values As IEnumerable(Of TValue)) As System.Linq.Expressions.Expression(Of Func(Of TElement, Boolean))

            'objects
            Dim ParameterExpression As System.Linq.Expressions.ParameterExpression = Nothing
            Dim EqualsExpression As System.Collections.Generic.IEnumerable(Of System.Linq.Expressions.BinaryExpression) = Nothing
            Dim BinaryExpression As System.Linq.Expressions.BinaryExpression = Nothing

            If IsNothing(ValueSelector) Then

                Throw New ArgumentNullException("ValueSelector")

            End If

            If IsNothing(Values) Then

                Throw New ArgumentNullException("Values")

            End If

            ParameterExpression = ValueSelector.Parameters.SingleOrDefault()

            If Not Values.Any Then

                BuildContainsExpression = Function(Element) False

            Else

                EqualsExpression = Values.Select(Function(Value) System.Linq.Expressions.Expression.Equal(ValueSelector.Body, System.Linq.Expressions.Expression.Constant(Value, GetType(TValue))))

                BinaryExpression = EqualsExpression.Aggregate(Function(Accumulate, Equals) System.Linq.Expressions.Expression.Or(Accumulate, Equals))

                BuildContainsExpression = System.Linq.Expressions.Expression.Lambda(Of Func(Of TElement, Boolean))(BinaryExpression, ParameterExpression)

            End If

        End Function
        Public Function ApplyWhere(ByVal QuerySource As IQueryable, ByVal ColumnName As String, ByVal OperatorType As AdvantageFramework.BaseClasses.OperatorTypes, ByVal Value As String) As IQueryable

            'objects
            Dim ParameterExpression As System.Linq.Expressions.ParameterExpression = Nothing
            Dim Expression As System.Linq.Expressions.Expression = Nothing
            Dim MethodCallExpression As System.Linq.Expressions.MethodCallExpression = Nothing
            Dim DataBoundType As System.Type = Nothing
            Dim MemberExpression As System.Linq.Expressions.MemberExpression = Nothing
            Dim UnaryExpression As System.Linq.Expressions.UnaryExpression = Nothing
            Dim PropertyMethodCallExpression As System.Linq.Expressions.MethodCallExpression = Nothing
            Dim ConstantExpression As System.Linq.Expressions.ConstantExpression = Nothing
            Dim LambdaExpression As System.Linq.Expressions.LambdaExpression = Nothing
            Dim QueryFiltered As IQueryable = Nothing

            Try

                If QuerySource IsNot Nothing Then

                    DataBoundType = System.Type.GetType(QuerySource.ElementType.AssemblyQualifiedName)
                    'parameter
                    ParameterExpression = System.Linq.Expressions.Expression.Parameter(DataBoundType, DataBoundType.Name)
                    'clear objects
                    ConstantExpression = Nothing
                    MemberExpression = Nothing
                    UnaryExpression = Nothing
                    PropertyMethodCallExpression = Nothing
                    Expression = Nothing
                    LambdaExpression = Nothing
                    'right side of equation
                    ConstantExpression = System.Linq.Expressions.Expression.Constant(Value)
                    'left side of equation (converted to to string)
                    MemberExpression = Expressions.Expression.Property(ParameterExpression, DataBoundType.GetProperty(ColumnName))
                    UnaryExpression = Expressions.Expression.Convert(MemberExpression, GetType(Object))
                    PropertyMethodCallExpression = Expressions.Expression.Call(UnaryExpression, GetType(Object).GetMethod("ToString", New System.Type() {}))
                    'set equation (aka - filter)
                    Select Case OperatorType

                        Case AdvantageFramework.BaseClasses.OperatorTypes.Contains

                            Expression = Expressions.Expression.Call(PropertyMethodCallExpression, GetType(String).GetMethod("Contains", New System.Type() {GetType(String)}), ConstantExpression)

                        Case AdvantageFramework.BaseClasses.OperatorTypes.StartsWith

                            Expression = Expressions.Expression.Call(PropertyMethodCallExpression, GetType(String).GetMethod("StartsWith", New System.Type() {GetType(String)}), ConstantExpression)

                        Case AdvantageFramework.BaseClasses.OperatorTypes.EndsWith

                            Expression = Expressions.Expression.Call(PropertyMethodCallExpression, GetType(String).GetMethod("EndsWith", New System.Type() {GetType(String)}), ConstantExpression)

                        Case AdvantageFramework.BaseClasses.OperatorTypes.IsEqualTo

                            Expression = Expressions.Expression.Equal(PropertyMethodCallExpression, ConstantExpression)

                        Case AdvantageFramework.BaseClasses.OperatorTypes.DoesNotEqual

                            Expression = Expressions.Expression.NotEqual(PropertyMethodCallExpression, ConstantExpression)

                    End Select
                    'set the equation on type
                    LambdaExpression = System.Linq.Expressions.Expression.Lambda(Expression, ParameterExpression)

                    If LambdaExpression IsNot Nothing Then
                        'build expression
                        MethodCallExpression = System.Linq.Expressions.Expression.Call(GetType(Queryable), "Where", New Type() {DataBoundType}, DirectCast(QuerySource, IQueryable).Expression, LambdaExpression)
                        'get query
                        QueryFiltered = DirectCast(QuerySource, IQueryable).Provider.CreateQuery(MethodCallExpression)

                    End If

                End If

            Catch ex As Exception
                QueryFiltered = Nothing
            End Try

            ApplyWhere = QueryFiltered

        End Function
        Public Function CreateXML(ByVal AFObject As Object) As String

            'objects
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim StringWriter As System.IO.StringWriter = Nothing
            Dim XML As String = ""

            Try

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(AFObject.GetType)
                StringWriter = New System.IO.StringWriter

                XmlSerializer.Serialize(StringWriter, AFObject)

                StringWriter.Close()

            Catch ex As Exception

                If StringWriter IsNot Nothing Then

                    StringWriter.Close()
                    StringWriter = Nothing

                End If

            Finally

                If StringWriter IsNot Nothing Then

                    XML = StringWriter.ToString

                End If

                CreateXML = XML

            End Try

        End Function
        Public Function ImportFromXML(ByVal XML As String, ByVal AFObjectType As System.Type) As Object

            'objects
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim StringReader As System.IO.StringReader = Nothing
            Dim AFObject As Object = Nothing

            Try

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(AFObjectType)
                StringReader = New System.IO.StringReader(XML)

                AFObject = XmlSerializer.Deserialize(StringReader)

            Catch ex As Exception
                AFObject = Nothing
            Finally
                ImportFromXML = AFObject
            End Try

        End Function
        Public Function IsRequiredProperty(ByVal Type As System.Type, ByVal PropertyName As String) As Boolean

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim PropertyIsRequired As Boolean = False

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Type).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = PropertyName).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        PropertyIsRequired = EntityAttribute.IsRequired

                    End If

                End Try

            End If

            IsRequiredProperty = PropertyIsRequired

        End Function
        Public Function ValidatePropertyType(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext,
                                             ByVal DataContext As AdvantageFramework.BaseClasses.DataContext,
                                             ByVal ClassObject As Object,
                                             ByVal ClassType As System.Type,
                                             ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes,
                                             ByRef Value As Object, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = ""
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim IsEntityBeingAdded As Boolean = False
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            Select Case PropertyType

                Case PropertyTypes.DivisionCode

                    If ClassType IsNot Nothing AndAlso ClassObject IsNot Nothing Then

                        PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                        If PropertyDescriptors.SelectMany(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute)().ToList).Any() Then

                            Try

                                ClientCode = (From PropertyDescriptor In PropertyDescriptors.Where(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute)().Any = True)
                                              Where PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault.PropertyType = PropertyTypes.ClientCode
                                              Select PropertyDescriptor.GetValue(ClassObject)).FirstOrDefault

                            Catch ex As Exception
                                ClientCode = Nothing
                            End Try

                        End If

                        If ClientCode Is Nothing Then

                            Try

                                ClientCode = (From PropertyDescriptor In PropertyDescriptors
                                              Where PropertyDescriptor.Name.ToUpper = "CLIENTCODE"
                                              Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                            Catch ex As Exception
                                ClientCode = Nothing
                            End Try

                        End If

                    End If

                Case PropertyTypes.ProductCode

                    If ClassType IsNot Nothing AndAlso ClassObject IsNot Nothing Then

                        PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                        If PropertyDescriptors.SelectMany(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute)().ToList).Any() Then

                            Try

                                ClientCode = (From PropertyDescriptor In PropertyDescriptors.Where(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute)().Any = True)
                                              Where PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault.PropertyType = PropertyTypes.ClientCode
                                              Select PropertyDescriptor.GetValue(ClassObject)).FirstOrDefault

                            Catch ex As Exception
                                ClientCode = Nothing
                            End Try

                        End If

                        If ClientCode Is Nothing Then

                            Try

                                ClientCode = (From PropertyDescriptor In PropertyDescriptors
                                              Where PropertyDescriptor.Name.ToUpper = "CLIENTCODE"
                                              Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                            Catch ex As Exception
                                ClientCode = Nothing
                            End Try

                        End If

                        If PropertyDescriptors.SelectMany(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute)().ToList).Any() Then

                            Try

                                DivisionCode = (From PropertyDescriptor In PropertyDescriptors.Where(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute)().Any = True)
                                                Where PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault.PropertyType = PropertyTypes.DivisionCode
                                                Select PropertyDescriptor.GetValue(ClassObject)).FirstOrDefault

                            Catch ex As Exception
                                DivisionCode = Nothing
                            End Try

                        End If

                        If DivisionCode Is Nothing Then

                            Try

                                DivisionCode = (From PropertyDescriptor In PropertyDescriptors
                                                Where PropertyDescriptor.Name.ToUpper = "DIVISIONCODE"
                                                Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                            Catch ex As Exception
                                DivisionCode = Nothing
                            End Try

                        End If

                    End If

            End Select

            If PropertyType <> PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, PropertyType, Value, IsValid, ClientCode, DivisionCode)

                If PropertyType = PropertyTypes.Code AndAlso Not (TypeOf ClassObject Is AdvantageFramework.Database.Entities.ImportEmployeeStaging OrElse TypeOf ClassObject Is AdvantageFramework.Database.Entities.ImportVendorStaging) Then

                    Try

                        If TypeOf ClassObject Is AdvantageFramework.BaseClasses.Entity Then

                            IsEntityBeingAdded = CType(ClassObject, AdvantageFramework.BaseClasses.Entity).IsEntityBeingAdded()

                        ElseIf TypeOf ClassObject Is AdvantageFramework.BaseClasses.EntityBase Then

                            IsEntityBeingAdded = CType(ClassObject, AdvantageFramework.BaseClasses.EntityBase).IsEntityBeingAdded()

                        ElseIf TypeOf ClassObject Is AdvantageFramework.BaseClasses.BaseClass Then

                            IsEntityBeingAdded = CType(ClassObject, AdvantageFramework.BaseClasses.BaseClass).IsEntityBeingAdded()

                        End If

                    Catch ex As Exception
                        IsEntityBeingAdded = False
                    End Try

                    If IsEntityBeingAdded = False AndAlso IsValid = False AndAlso Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                        ErrorText = ""
                        IsValid = True

                    End If

                End If

            End If

            ValidatePropertyType = ErrorText

        End Function
        Public Function ValidatePropertyType(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext,
                                             ByVal DataContext As AdvantageFramework.BaseClasses.DataContext,
                                             ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes,
                                             ByRef Value As Object, ByRef IsValid As Boolean, Optional ByVal ClientCode As String = "",
                                             Optional ByVal DivisionCode As String = "", Optional ByVal ProductCode As String = "") As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim ContinueChecking As Boolean = True

            PropertyValue = Value

            If IsNothing(Value) OrElse Value Is Nothing Then

                If PropertyType <> PropertyTypes.Code Then

                    ContinueChecking = False
                    IsValid = False

                End If

            End If

            If ContinueChecking Then

                Select Case PropertyType

                    Case PropertyTypes.Code

                        If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                            IsValid = False

                        End If

                    Case PropertyTypes.Email

                        If AdvantageFramework.StringUtilities.IsValidEmailAddress(PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.SocialSecurityNumber

                        If AdvantageFramework.StringUtilities.IsValidSocialSecurityNumber(Value, True) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.FunctionCode

                        If (From [Function] In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Functions
                            Where [Function].Code = DirectCast(PropertyValue, String)
                            Select [Function]).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.EmployeeFunctionCode

                        If (From [Function] In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Functions
                            Where [Function].Code = DirectCast(PropertyValue, String) AndAlso
                                  [Function].Type = "E"
                            Select [Function]).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.VendorFunctionCode

                        If (From [Function] In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Functions
                            Where [Function].Code = DirectCast(PropertyValue, String) AndAlso
                                  [Function].Type = "V"
                            Select [Function]).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ClientCode

                        If (From Client In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Clients
                            Where Client.Code = DirectCast(PropertyValue, String)
                            Select Client).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.DivisionCode

                        If ClientCode IsNot Nothing AndAlso ClientCode <> "" Then

                            If (From Division In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Divisions
                                Where Division.Code = DirectCast(PropertyValue, String) AndAlso
                                      Division.ClientCode = ClientCode
                                Select Division).Any = False Then

                                IsValid = False

                            End If

                        End If

                    Case PropertyTypes.ProductCode

                        If ClientCode IsNot Nothing AndAlso ClientCode <> "" AndAlso DivisionCode IsNot Nothing AndAlso DivisionCode <> "" Then

                            If (From Product In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Products
                                Where Product.Code = DirectCast(PropertyValue, String) AndAlso
                                      Product.ClientCode = ClientCode AndAlso
                                      Product.DivisionCode = DivisionCode
                                Select Product).Any = False Then

                                IsValid = False

                            End If

                        End If

                    Case PropertyTypes.ProductCategory

                        If ClientCode IsNot Nothing AndAlso ClientCode <> "" AndAlso DivisionCode IsNot Nothing AndAlso DivisionCode <> "" AndAlso ProductCode IsNot Nothing AndAlso ProductCode <> "" Then

                            If (From ProductCategory In DirectCast(DbContext, AdvantageFramework.Database.DbContext).ProductCategories
                                Where ProductCategory.Code = DirectCast(PropertyValue, String) AndAlso
                                      ProductCategory.ClientCode = ClientCode AndAlso
                                      ProductCategory.DivisionCode = DivisionCode AndAlso
                                      ProductCategory.ProductCode = ProductCode
                                Select ProductCategory).Any = False Then

                                IsValid = False

                            End If

                        End If

                    Case PropertyTypes.EmployeeCode

                        If (From Employee In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Employees
                            Where Employee.Code = DirectCast(PropertyValue, String)
                            Select Employee).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.VendorCode

                        If (From Vendor In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Vendors
                            Where Vendor.Code = DirectCast(PropertyValue, String)
                            Select Vendor).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.GeneralLedgerAccountCode

                        If (From GeneralLedgerAccount In DirectCast(DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerAccounts
                            Where GeneralLedgerAccount.Code = DirectCast(PropertyValue, String)
                            Select GeneralLedgerAccount).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.OfficeCode

                        If (From Office In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Offices
                            Where Office.Code = DirectCast(PropertyValue, String)
                            Select Office).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CurrencyCode

                        If (From CurrencyCode In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CurrencyCodes
                            Where CurrencyCode.Code = DirectCast(PropertyValue, String)
                            Select CurrencyCode).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.BankCode

                        If (From Bank In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Banks
                            Where Bank.Code = DirectCast(PropertyValue, String)
                            Select Bank).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.SalesTaxCode

                        If (From SalesTax In DirectCast(DbContext, AdvantageFramework.Database.DbContext).SalesTaxes
                            Where SalesTax.TaxCode = DirectCast(PropertyValue, String)
                            Select SalesTax).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.DepartmentTeamCode

                        If (From DepartmentTeam In DirectCast(DbContext, AdvantageFramework.Database.DbContext).DepartmentTeams
                            Where DepartmentTeam.Code = DirectCast(PropertyValue, String)
                            Select DepartmentTeam).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ClientContactID

                        If (From ClientContact In DirectCast(DbContext, AdvantageFramework.Database.DbContext).ClientContact
                            Where ClientContact.ContactID = DirectCast(PropertyValue, Integer)
                            Select ClientContact).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.PurchaseOrderApprovalRuleCode

                        If (From PurchaseOrderApprovalRule In DirectCast(DbContext, AdvantageFramework.Database.DbContext).PurchaseOrderApprovalRules
                            Where PurchaseOrderApprovalRule.Code = DirectCast(PropertyValue, String)
                            Select PurchaseOrderApprovalRule).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ServiceFeeTypeCode

                        If (From ServiceFeeType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).ServiceFeeTypes
                            Where ServiceFeeType.Code = DirectCast(PropertyValue, String)
                            Select ServiceFeeType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.SalesClassCode

                        If (From SalesClass In DirectCast(DbContext, AdvantageFramework.Database.DbContext).SalesClasses
                            Where SalesClass.Code = DirectCast(PropertyValue, String)
                            Select SalesClass).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.RoleCode

                        If (From Role In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Roles
                            Where Role.Code = DirectCast(PropertyValue, String)
                            Select Role).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.EmployeeTitleID

                        If (From EmployeeTitle In DirectCast(DbContext, AdvantageFramework.Database.DbContext).EmployeeTitles
                            Where EmployeeTitle.ID = DirectCast(PropertyValue, Integer)
                            Select EmployeeTitle).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ZipCode

                        If AdvantageFramework.StringUtilities.IsValidZip(Value) = False Then

                            If AdvantageFramework.StringUtilities.IsValidFullZipCode(Value) = False Then

                                IsValid = False

                            End If

                        End If

                    Case PropertyTypes.VendorTermCode

                        If (From VendorTerm In DirectCast(DbContext, AdvantageFramework.Database.DbContext).VendorTerms
                            Where VendorTerm.Code = DirectCast(PropertyValue, String)
                            Select VendorTerm).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ImportVendorCategoryCode

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ImportVendorCategories)).Any(Function(VenCat) VenCat.Code = PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.FunctionHeadingID

                        If (From FunctionHeading In DirectCast(DbContext, AdvantageFramework.Database.DbContext).FunctionHeadings
                            Where FunctionHeading.ID = DirectCast(PropertyValue, Integer)
                            Select FunctionHeading).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.IndirectCategoryType

                        If (From TimeCategoryType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).TimeCategoryTypes
                            Where TimeCategoryType.ID = DirectCast(PropertyValue, Short)
                            Select TimeCategoryType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.JobNumber

                        If (From Job In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Jobs
                            Where Job.Number = DirectCast(PropertyValue, Integer)
                            Select Job).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.PostPeriodCode

                        If (From PostPeriod In DirectCast(DbContext, AdvantageFramework.Database.DbContext).PostPeriods
                            Where PostPeriod.Code = DirectCast(PropertyValue, String)
                            Select PostPeriod).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.File

                        If My.Computer.FileSystem.FileExists(PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.Folder

                        If My.Computer.FileSystem.DirectoryExists(PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.WebsiteTypeCode

                        If (From WebsiteType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).WebsiteTypes
                            Where WebsiteType.Code = DirectCast(PropertyValue, String)
                            Select WebsiteType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.PTORule

                        If (From PTORule In DirectCast(DbContext, AdvantageFramework.Database.DbContext).PTORules
                            Where PTORule.ID = DirectCast(PropertyValue, Integer)
                            Select PTORule).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.MarketCode

                        If (From Market In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Markets
                            Where Market.Code = DirectCast(PropertyValue, String)
                            Select Market).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.AdSizeCode

                        If (From AdSize In DirectCast(DbContext, AdvantageFramework.Database.DbContext).AdSizes
                            Where AdSize.Code = DirectCast(PropertyValue, String)
                            Select AdSize).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.DaypartID

                        If (From Daypart In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Dayparts
                            Where Daypart.ID = DirectCast(PropertyValue, Integer)
                            Select Daypart).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.JobVersionDatabaseType

                        If (From JobVersionDatabaseType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).JobVersionDatabaseTypes
                            Where JobVersionDatabaseType.ID = DirectCast(PropertyValue, Integer)
                            Select JobVersionDatabaseType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.TaskCode

                        If DbContext IsNot Nothing Then

                            If (From Task In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Tasks
                                Where Task.Code = DirectCast(PropertyValue, String)
                                Select Task).Any = False Then

                                IsValid = False

                            End If

                        End If

                    Case PropertyTypes.Phase

                        If (From Phase In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Phases
                            Where Phase.ID = DirectCast(PropertyValue, Integer)
                            Select Phase).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.PartnerCode

                        If (From Partner In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Partners
                            Where Partner.Code = DirectCast(PropertyValue, String)
                            Select Partner).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.DaypartTypeID

                        If (From DaypartType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).DaypartTypes
                            Where DaypartType.ID = DirectCast(PropertyValue, Integer)
                            Select DaypartType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ExpenseEmployee

                        If (From Employee In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Employees
                            Where Employee.Code = DirectCast(PropertyValue, String) AndAlso
                                  Employee.EmployeeVendorCode IsNot Nothing AndAlso
                                  Employee.EmployeeVendorCode <> ""
                            Select Employee).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.Blackplate

                        If (From Blackplate In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Blackplates
                            Where Blackplate.Code = DirectCast(PropertyValue, String)
                            Select Blackplate).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CycleTypes

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CycleTypes)).Any(Function(CycleType) CycleType.Code = PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CampaignDetailType

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes)).Any(Function(CampaignDetailType) CampaignDetailType.Code = PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.EmployeeCategoryID

                        If (From EmployeeCategory In DirectCast(DbContext, AdvantageFramework.Database.DbContext).EmployeeCategories
                            Where EmployeeCategory.ID = DirectCast(PropertyValue, Integer)
                            Select EmployeeCategory).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.MediaPlanID

                        If (From MediaPlan In DirectCast(DbContext, AdvantageFramework.Database.DbContext).MediaPlans
                            Where MediaPlan.ID = DirectCast(PropertyValue, Integer)
                            Select MediaPlan).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.MediaPlanDetailID

                        If (From MediaPlanDetail In DirectCast(DbContext, AdvantageFramework.Database.DbContext).MediaPlanDetails
                            Where MediaPlanDetail.ID = DirectCast(PropertyValue, Integer)
                            Select MediaPlanDetail).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.MediaType

                        If (From MediaType In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountPayableImportMediaType))
                            Where MediaType.Code = DirectCast(PropertyValue, String)
                            Select MediaType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.IndirectCategory

                        If (From IndirectCategory In DirectCast(DbContext, AdvantageFramework.Database.DbContext).IndirectCategories
                            Where IndirectCategory.Code = DirectCast(PropertyValue, String)
                            Select IndirectCategory).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.LocationID

                        If (From Location In DirectCast(DataContext, AdvantageFramework.Database.DataContext).Locations
                            Where Location.ID = DirectCast(PropertyValue, String)
                            Select Location).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.Status

                        If (From Status In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Status
                            Where Status.Code = DirectCast(PropertyValue, String)
                            Select Status).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.DaypartCode

                        If (From Daypart In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Dayparts
                            Where Daypart.Code = DirectCast(PropertyValue, String)
                            Select Daypart).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.InvoiceCategory

                        If (From InvoiceCategory In DirectCast(DbContext, AdvantageFramework.Database.DbContext).InvoiceCategories
                            Where InvoiceCategory.Code = DirectCast(PropertyValue, String)
                            Select InvoiceCategory).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomProductionInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "PI"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomMagazineInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "MI"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomNewspaperInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "NI"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomInternetInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "II"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomOutdoorInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "OI"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomRadioInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "RI"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.CustomTVInvoice

                        If (From CustomReport In DirectCast(DbContext, AdvantageFramework.Database.DbContext).CustomReports
                            Where CustomReport.Name = DirectCast(PropertyValue, String) AndAlso
                                  CustomReport.LegacyModuleCode = "TI"
                            Select CustomReport).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.AdNumber

                        If (From Ad In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Ads
                            Where Ad.Number = DirectCast(PropertyValue, String)
                            Select Ad).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.AvalaraTaxID

                        If (From AvalaraTax In DirectCast(DataContext, AdvantageFramework.Database.DataContext).AvalaraTaxes
                            Where AvalaraTax.ID = DirectCast(PropertyValue, Integer)
                            Select AvalaraTax).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.OverheadAccountCode

                        If (From OverheadAccount In DirectCast(DbContext, AdvantageFramework.Database.DbContext).OverheadAccounts
                            Where OverheadAccount.Code = DirectCast(PropertyValue, String)
                            Select OverheadAccount).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.JobProcess

                        If (From JobProcess In DirectCast(DataContext, AdvantageFramework.Database.DataContext).JobProcesses
                            Where JobProcess.ID = DirectCast(PropertyValue, Short)
                            Select JobProcess).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ContactTypeID

                        If (From ContactType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).ContactTypes
                            Where ContactType.ID = DirectCast(PropertyValue, Integer)
                            Select ContactType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.VCCStatus

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VCCStatus)).Any(Function(VCCStatus) VCCStatus.Code = PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.OutOfHomeType

                        If (From OutOfHomeType In DirectCast(DbContext, AdvantageFramework.Database.DbContext).OutOfHomeTypes
                            Where OutOfHomeType.Code = DirectCast(PropertyValue, String)
                            Select OutOfHomeType).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.OrderProcess

                        If (From JobProcess In DirectCast(DataContext, AdvantageFramework.Database.DataContext).JobProcesses
                            Where (JobProcess.ID = 1 OrElse
                                   JobProcess.ID = 6 OrElse
                                   JobProcess.ID = 13) AndAlso
                                  JobProcess.ID = DirectCast(PropertyValue, Short)
                            Select JobProcess).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.RateType

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.RateType)).Any(Function(item) item.Code = PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.StateCode

                        If (From State In DirectCast(DbContext, AdvantageFramework.Database.DbContext).States
                            Where State.StateCode = DirectCast(PropertyValue, String)
                            Select State).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.GeneralLedgerSource

                        If (From GeneralLedgerSource In DirectCast(DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerSources
                            Where GeneralLedgerSource.Code = DirectCast(PropertyValue, String)
                            Select GeneralLedgerSource).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.BuyerEmployeeCode

                        If (From MediaBuyer In AdvantageFramework.Database.Procedures.MediaBuyer.LoadAllActive(DbContext)
                            Where MediaBuyer.EmployeeCode = DirectCast(PropertyValue, String)
                            Select MediaBuyer).Any = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.MediaRFPAvailLineStatus

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus)).Any(Function(item) item.Code = PropertyValue) = False Then

                            IsValid = False

                        End If

                    Case PropertyTypes.ClientDiscount

                        If (From ClientDiscount In DirectCast(DbContext, AdvantageFramework.Database.DbContext).ClientDiscounts
                            Where ClientDiscount.Code = DirectCast(PropertyValue, String)
                            Select ClientDiscount).Any = False Then

                            IsValid = False

                        End If

                End Select

            End If

            If IsValid = False Then

                ErrorText = LoadPropertyTypeErrorText(PropertyType)

            End If

            ValidatePropertyType = ErrorText

        End Function
        Public Function LoadPropertyTypeErrorText(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            'objects
            Dim ErrorText As String = ""

            Select Case PropertyType

                Case PropertyTypes.Code

                    ErrorText = "Please enter a valid code."

                Case PropertyTypes.Email

                    ErrorText = "Please enter a valid email address."

                Case PropertyTypes.SocialSecurityNumber

                    ErrorText = "Please enter a valid social security number."

                Case PropertyTypes.FunctionCode

                    ErrorText = "Please enter a valid function code."

                Case PropertyTypes.EmployeeFunctionCode

                    ErrorText = "Please enter a valid function code."

                Case PropertyTypes.VendorFunctionCode

                    ErrorText = "Please enter a valid function code."

                Case PropertyTypes.ClientCode

                    ErrorText = "Please enter a valid client code."

                Case PropertyTypes.DivisionCode

                    ErrorText = "Please enter a valid division code."

                Case PropertyTypes.ProductCode

                    ErrorText = "Please enter a valid product code."

                Case PropertyTypes.ProductCategory

                    ErrorText = "Please enter a valid product category code."

                Case PropertyTypes.EmployeeCode

                    ErrorText = "Please enter a valid employee code."

                Case PropertyTypes.VendorCode

                    ErrorText = "Please enter a valid vendor code."

                Case PropertyTypes.GeneralLedgerAccountCode

                    ErrorText = "Please enter a valid general ledger account code."

                Case PropertyTypes.OfficeCode

                    ErrorText = "Please enter a valid office code."

                Case PropertyTypes.CurrencyCode

                    ErrorText = "Please enter a valid currency code."

                Case PropertyTypes.BankCode

                    ErrorText = "Please enter a valid bank code."

                Case PropertyTypes.SalesTaxCode

                    ErrorText = "Please enter a valid sales tax code."

                Case PropertyTypes.DepartmentTeamCode

                    ErrorText = "Please enter a valid department team code."

                Case PropertyTypes.ClientContactID

                    ErrorText = "Please enter a valid client contact ID."

                Case PropertyTypes.PurchaseOrderApprovalRuleCode

                    ErrorText = "Please enter a valid PO approval rule code."

                Case PropertyTypes.ServiceFeeTypeCode

                    ErrorText = "Please enter a valid service fee type code."

                Case PropertyTypes.SalesClassCode

                    ErrorText = "Please enter a valid sales class code."

                Case PropertyTypes.RoleCode

                    ErrorText = "Please enter a valid role code."

                Case PropertyTypes.EmployeeTitleID

                    ErrorText = "Please enter a valid role code."

                Case PropertyTypes.ZipCode

                    ErrorText = "Please enter a valid zip code."

                Case PropertyTypes.VendorTermCode

                    ErrorText = "Please enter a valid vendor term code."

                Case PropertyTypes.ImportVendorCategoryCode

                    ErrorText = "Please enter a valid vendor category code."

                Case PropertyTypes.FunctionHeadingID

                    ErrorText = "Please enter a valid function heading ID."

                Case PropertyTypes.IndirectCategoryType

                    ErrorText = "Please enter a valid indirect category type."

                Case PropertyTypes.JobNumber

                    ErrorText = "Please enter a valid Job Number."

                Case PropertyTypes.PostPeriodCode

                    ErrorText = "Please enter a valid post period code."

                Case PropertyTypes.File

                    ErrorText = "Please enter a valid file."

                Case PropertyTypes.Folder

                    ErrorText = "Please enter a valid folder."

                Case PropertyTypes.WebsiteTypeCode

                    ErrorText = "Please enter a valid website type code."

                Case PropertyTypes.PTORule

                    ErrorText = "Please enter a valid PTO Rule."

                Case PropertyTypes.MarketCode

                    ErrorText = "Please enter a valid market code."

                Case PropertyTypes.AdSizeCode

                    ErrorText = "Please enter a valid ad size code."

                Case PropertyTypes.DaypartID, PropertyTypes.DaypartCode

                    ErrorText = "Please enter a valid daypart."

                Case PropertyTypes.JobVersionDatabaseType

                    ErrorText = "Please enter a valid job version database type."

                Case PropertyTypes.TaskCode

                    ErrorText = "Please enter a valid task code."

                Case PropertyTypes.Phase

                    ErrorText = "Please enter a valid phase."

                Case PropertyTypes.PartnerCode

                    ErrorText = "Please enter a valid partner code."

                Case PropertyTypes.DaypartTypeID

                    ErrorText = "Please enter a valid daypart type."

                Case PropertyTypes.ExpenseEmployee

                    ErrorText = "Please enter a valid employee code."

                Case PropertyTypes.JobComponent, PropertyTypes.JobComponentID

                    ErrorText = "Please enter a valid Job Component Number."

                Case PropertyTypes.Blackplate

                    ErrorText = "Please enter a valid blackplate."

                Case PropertyTypes.EmployeeCategoryID

                    ErrorText = "Please enter a valid category."

                Case PropertyTypes.IndirectCategory

                    ErrorText = "Please enter a valid indirect category."

                Case PropertyTypes.LocationID

                    ErrorText = "Please enter a valid location."

                Case PropertyTypes.Status

                    ErrorText = "Please enter a valid status."

                Case PropertyTypes.InvoiceCategory

                    ErrorText = "Please enter a valid invoice category."

                Case PropertyTypes.CustomProductionInvoice

                    ErrorText = "Please enter a valid custom production invoice."

                Case PropertyTypes.CustomMagazineInvoice

                    ErrorText = "Please enter a valid custom magazine invoice."

                Case PropertyTypes.CustomNewspaperInvoice

                    ErrorText = "Please enter a valid custom newspaper invoice."

                Case PropertyTypes.CustomInternetInvoice

                    ErrorText = "Please enter a valid custom internet invoice."

                Case PropertyTypes.CustomOutdoorInvoice

                    ErrorText = "Please enter a valid custom outdoor invoice."

                Case PropertyTypes.CustomRadioInvoice

                    ErrorText = "Please enter a valid custom radio invoice."

                Case PropertyTypes.CustomTVInvoice

                    ErrorText = "Please enter a valid custom tv invoice."

                Case PropertyTypes.AdNumber

                    ErrorText = "Please enter a valid ad number."

                Case PropertyTypes.AvalaraTaxID

                    ErrorText = "Please enter a valid avalara tax."

                Case PropertyTypes.OverheadAccountCode

                    ErrorText = "Please enter a valid overhead account code."

                Case PropertyTypes.JobProcess

                    ErrorText = "Please enter a valid job process."

                Case PropertyTypes.ContactTypeID

                    ErrorText = "Please enter a valid contact type."

                Case PropertyTypes.OrderProcess

                    ErrorText = "Please enter a valid order process."

                Case PropertyTypes.RateType

                    ErrorText = "Please enter a valid rate type."

                Case PropertyTypes.StateCode

                    ErrorText = "Please enter a valid state code."

                Case PropertyTypes.GeneralLedgerSource

                    ErrorText = "Please enter a valid GL source."

                Case PropertyTypes.BuyerEmployeeCode

                    ErrorText = "Please enter a valid buyer employee code."

                Case PropertyTypes.MediaRFPAvailLineStatus

                    ErrorText = "Please enter a valid status."

                Case Else

                    ErrorText = "Please enter a valid " & AdvantageFramework.StringUtilities.GetNameAsWords(PropertyType.ToString).ToLower & "."

            End Select

            LoadPropertyTypeErrorText = ErrorText

        End Function
        Public Function ValidateData(ByRef Value As Object, ByRef IsValid As Boolean, ByVal DisplayName As String, ByVal IsEntityKey As Boolean, ByVal IsRequired As Boolean, ByVal IsNullable As Boolean, ByVal MaxLength As Integer, ByVal Precision As Integer, ByVal Scale As Integer) As String

            'objects
            Dim ErrorText As String = ""
            Dim MinDate As Date = #1/1/1900#
            Dim MaxDate As Date = #6/6/2079#

            If IsNullable = False AndAlso IsEntityKey = False Then

                If Value Is Nothing Then

                    ErrorText = DisplayName & " is required. "
                    IsValid = False

                End If

            End If

            If IsValid Then

                If Value Is Nothing Then

                    If IsRequired Then

                        ErrorText = DisplayName & " is required. "
                        IsValid = False

                    End If

                ElseIf Value.GetType Is GetType(DateTime) OrElse
                        Value.GetType Is GetType(System.Nullable(Of DateTime)) Then

                    If IsRequired Then

                        If Not IsDate(Value) Then

                            ErrorText = DisplayName & " is required. "
                            IsValid = False

                        End If

                    End If

                    If IsValid Then

                        If IsDate(Value) Then

                            If CDate(Value) > MaxDate OrElse CDate(Value) < MinDate Then

                                ErrorText = String.Format("{0} is outside of the allowed date range ({1} - {2}).", DisplayName, MinDate.ToShortDateString, MaxDate.ToShortDateString)
                                IsValid = False

                            End If

                        End If

                    End If

                ElseIf Value.GetType Is GetType(String) Then

                    If IsRequired Then

                        If String.IsNullOrWhiteSpace(Value) Then

                            ErrorText = DisplayName & " is required. "
                            IsValid = False

                        End If

                    End If

                    If IsValid Then

                        If MaxLength > 0 Then

                            If Value.ToString.Length > MaxLength Then

                                ErrorText = DisplayName & " exceeds the maximum length of " & MaxLength & ". "
                                IsValid = False

                            End If

                        End If

                    End If

                ElseIf Value.GetType Is GetType(Decimal) OrElse
                        Value.GetType Is GetType(System.Nullable(Of Decimal)) Then

                    If IsRequired Then

                        If IsNumeric(Value) = False Then

                            ErrorText = DisplayName & " is required. "
                            IsValid = False

                        End If

                    End If

                    If Precision > 0 AndAlso Value <> 0 Then

                        If AdvantageFramework.StringUtilities.IsValidDecimal(Value, Precision, Scale) = False Then

                            ErrorText = DisplayName & " is an invalid value. "
                            IsValid = False

                        End If

                    End If

                ElseIf Value.GetType Is GetType(Long) OrElse
                        Value.GetType Is GetType(System.Nullable(Of Long)) OrElse
                        Value.GetType Is GetType(Integer) OrElse
                        Value.GetType Is GetType(System.Nullable(Of Integer)) OrElse
                        Value.GetType Is GetType(Short) OrElse
                        Value.GetType Is GetType(System.Nullable(Of Short)) Then

                    If IsRequired Then

                        If IsNumeric(Value) = False Then

                            ErrorText = DisplayName & " is required. "
                            IsValid = False

                        End If

                    End If

                ElseIf Value.GetType Is GetType(Byte) OrElse
                        Value.GetType Is GetType(System.Nullable(Of Byte)) Then

                    If IsRequired Then

                        If IsNothing(Value) Then

                            ErrorText = DisplayName & " is required. "
                            IsValid = False

                        End If

                    End If

                ElseIf Value.GetType Is GetType(Boolean) OrElse
                        Value.GetType Is GetType(System.Nullable(Of Boolean)) Then

                    If IsRequired Then

                        If IsNothing(Value) Then

                            ErrorText = DisplayName & " is required. "
                            IsValid = False

                        End If

                    End If

                End If

            End If

            ValidateData = ErrorText

        End Function
        Public Sub LoadPropertyAttributes(ByVal Type As System.Type, ByVal PropertyName As String, ByRef IsRequired As Boolean,
                                          ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Type).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = PropertyName).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                LoadPropertyAttributes(PropertyDescriptor, IsRequired, PropertyType, DisplayName)

            End If

        End Sub
        Public Sub LoadPropertyAttributes(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef IsRequired As Boolean,
                                          ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        IsRequired = EntityAttribute.IsRequired
                        PropertyType = EntityAttribute.PropertyType
                        DisplayName = EntityAttribute.CustomColumnCaption

                    End If

                End Try

            End If

        End Sub
        Public Sub SetRequired(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal IsRequired As Boolean)

            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

            Catch ex As Exception
                EntityAttribute = Nothing
            End Try

            If EntityAttribute IsNot Nothing Then

                EntityAttribute.IsRequired = IsRequired

            End If

        End Sub
        Public Sub SetRequired(ByRef ClassObject As Object, ByVal PropertyName As String, ByVal IsRequired As Boolean)

            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(ClassObject).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                SetRequired(PropertyDescriptor, IsRequired)

            End If

        End Sub
        Public Sub SetReadOnly(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal IsReadOnly As Boolean)

            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

            Catch ex As Exception
                EntityAttribute = Nothing
            End Try

            If EntityAttribute IsNot Nothing Then

                EntityAttribute.IsReadOnlyColumn = IsReadOnly

            End If

        End Sub
        Public Sub SetReadOnly(ByRef ClassObject As Object, ByVal PropertyName As String, ByVal IsReadOnly As Boolean)

            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(ClassObject).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                SetReadOnly(PropertyDescriptor, IsReadOnly)

            End If

        End Sub
        Public Sub SetPropertyValue(ByRef ClassObject As Object, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal NewValue As Object)

            'objects
            Dim UnderlyingType As System.Type = Nothing

            If PropertyDescriptor IsNot Nothing Then

                If NewValue IsNot Nothing Then

                    Try

                        UnderlyingType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

                    Catch ex As Exception
                        UnderlyingType = PropertyDescriptor.PropertyType
                    End Try

                    If UnderlyingType IsNot Nothing Then

                        PropertyDescriptor.SetValue(ClassObject, Convert.ChangeType(NewValue, UnderlyingType))

                    Else

                        PropertyDescriptor.SetValue(ClassObject, NewValue)

                    End If

                Else

                    PropertyDescriptor.SetValue(ClassObject, Nothing)

                End If

            End If

        End Sub
        Public Sub SetPropertyValue(ByRef ClassObject As Object, ByVal PropertyName As String, ByVal NewValue As Object)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ClassObject).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                      Where [Property].Name = PropertyName
                                      Select [Property]).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                SetPropertyValue(ClassObject, PropertyDescriptor, NewValue)

            End If

        End Sub
        Private Function LoadPropertyValueByPropertyType(ByVal ClassObject As Object, ByVal ClassType As System.Type, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            'objects
            Dim PropertyValue As Object = Nothing

            Select Case PropertyType

                Case PropertyTypes.ClientCode

                    Try

                        PropertyValue = (From PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                         Where PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault.PropertyType = PropertyTypes.ClientCode
                                         Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                    Catch ex As Exception
                        PropertyValue = Nothing
                    End Try

                    If PropertyValue Is Nothing Then

                        Try

                            PropertyValue = (From PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                             Where PropertyDescriptor.Name.ToUpper = "CLIENTCODE"
                                             Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                        Catch ex As Exception
                            PropertyValue = Nothing
                        End Try

                    End If

                Case PropertyTypes.DivisionCode

                    Try

                        PropertyValue = (From PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                         Where PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault.PropertyType = PropertyTypes.DivisionCode
                                         Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                    Catch ex As Exception
                        PropertyValue = Nothing
                    End Try

                    If PropertyValue Is Nothing Then

                        Try

                            PropertyValue = (From PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                             Where PropertyDescriptor.Name.ToUpper = "DIVISIONCODE"
                                             Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                        Catch ex As Exception
                            PropertyValue = Nothing
                        End Try

                    End If

                Case PropertyTypes.ProductCode

                    Try

                        PropertyValue = (From PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                         Where PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault.PropertyType = PropertyTypes.ProductCode
                                         Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                    Catch ex As Exception
                        PropertyValue = Nothing
                    End Try

                    If PropertyValue Is Nothing Then

                        Try

                            PropertyValue = (From PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                             Where PropertyDescriptor.Name.ToUpper = "PRODUCTCODE"
                                             Select PropertyDescriptor.GetValue(ClassObject)).SingleOrDefault

                        Catch ex As Exception
                            PropertyValue = Nothing
                        End Try

                    End If

                Case Else

                    PropertyValue = Nothing

            End Select

            LoadPropertyValueByPropertyType = PropertyValue

        End Function

#End Region

    End Module

End Namespace
