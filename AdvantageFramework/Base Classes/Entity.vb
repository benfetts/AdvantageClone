Namespace BaseClasses

    <Serializable()>
    Public MustInherit Class Entity
        Implements System.ComponentModel.IDataErrorInfo,
                   AdvantageFramework.BaseClasses.Interfaces.IValidatingClass,
                   System.Data.Entity.Core.Objects.DataClasses.IEntityWithKey

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        <System.NonSerialized>
        Protected _DataContext As AdvantageFramework.BaseClasses.DataContext = Nothing
        <System.NonSerialized>
        Protected _DbContext As AdvantageFramework.BaseClasses.DbContext = Nothing
        Protected _DatabaseAction As AdvantageFramework.Database.Action = AdvantageFramework.Database.Action.Updating
        Protected _ErrorHashtable As Hashtable = Nothing
        Protected _EntityError As String = ""

#End Region

#Region " Properties "

        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <System.ComponentModel.DataAnnotations.Schema.NotMapped>
        Public Property DatabaseAction As AdvantageFramework.Database.Action
            Get
                DatabaseAction = _DatabaseAction
            End Get
            Set(ByVal value As AdvantageFramework.Database.Action)
                _DatabaseAction = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <System.ComponentModel.DataAnnotations.Schema.NotMapped>
        Public Property DbContext As AdvantageFramework.BaseClasses.DbContext
            Get
                DbContext = _DbContext
            End Get
            Set(ByVal value As AdvantageFramework.BaseClasses.DbContext)
                _DbContext = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <NotMapped>
        Public Property DataContext As AdvantageFramework.BaseClasses.DataContext
            Get
                DataContext = _DataContext
            End Get
            Set(ByVal value As AdvantageFramework.BaseClasses.DataContext)
                _DataContext = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <NotMapped>
        Public ReadOnly Property [Error] As String Implements System.ComponentModel.IDataErrorInfo.Error
            Get
                [Error] = _EntityError
            End Get
        End Property
        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <NotMapped>
        Default Public ReadOnly Property Item(ByVal PropertyName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
            Get
                Item = LoadErrorText(PropertyName)
            End Get
        End Property
        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <NotMapped>
        Public Property [EntityError] As String
            Get
                [EntityError] = _EntityError
            End Get
            Set(ByVal value As String)
                _EntityError = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        <Xml.Serialization.XmlIgnore()>
        <NotMapped>
        Public Property EntityKey As System.Data.Entity.Core.EntityKey Implements System.Data.Entity.Core.Objects.DataClasses.IEntityWithKey.EntityKey

#End Region

#Region " Methods "

        Public Sub New()

            _ErrorHashtable = New Hashtable

        End Sub
        Public Function LoadErrorText(ByVal PropertyName As String) As String

            'objects
            Dim ErrorText As String = ""

            Try

                ErrorText = _ErrorHashtable(PropertyName)

            Catch ex As Exception
                ErrorText = ""
            Finally
                LoadErrorText = ErrorText
            End Try

        End Function
        Public Function HasError() As Boolean Implements Interfaces.IValidatingClass.HasError

            'objects
            Dim EntityHasError As Boolean = False

            Try

                If String.IsNullOrWhiteSpace(_EntityError) = False Then

                    EntityHasError = True

                End If

            Catch ex As Exception
                EntityHasError = False
            End Try

            HasError = EntityHasError

        End Function
        Public Function IsRequiredProperty(ByVal Type As System.Type, ByVal PropertyName As String) As Boolean Implements Interfaces.IValidatingClass.IsRequiredProperty

            'objects
            Dim PropertyIsRequired As Boolean = False

            Try

                PropertyIsRequired = AdvantageFramework.BaseClasses.IsRequiredProperty(Type, PropertyName)

            Catch ex As Exception
                PropertyIsRequired = False
            End Try

            IsRequiredProperty = PropertyIsRequired

        End Function
        Public Overridable Sub LoadPropertyAttributes(ByVal PropertyName As String,
                                                      ByRef IsEntityKey As Boolean, ByRef IsNullable As Boolean, ByRef IsRequired As Boolean,
                                                      ByRef MaxLength As Integer, ByRef Precision As Integer, ByRef Scale As Integer,
                                                      ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

            LoadPropertyAttributes(Me.GetType, PropertyName, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

        End Sub
        Public Shared Sub LoadPropertyAttributes(PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                 ByRef IsEntityKey As Boolean, ByRef IsNullable As Boolean, ByRef IsRequired As Boolean,
                                                 ByRef MaxLength As Integer, ByRef Precision As Integer, ByRef Scale As Integer,
                                                 ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

            'objects
            Dim DecimalPrecisionAttribute As AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute = Nothing
            Dim RequiredAttribute As System.ComponentModel.DataAnnotations.RequiredAttribute = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                RequiredAttribute = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.RequiredAttribute).FirstOrDefault
                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault

                If PropertyDescriptor.PropertyType Is GetType(System.Nullable) OrElse
                        RequiredAttribute Is Nothing OrElse
                        (RequiredAttribute IsNot Nothing AndAlso RequiredAttribute.AllowEmptyStrings) OrElse
                        EntityAttribute Is Nothing OrElse
                        (EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False) Then

                    IsNullable = True

                End If

                IsEntityKey = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.KeyAttribute).Any

                If PropertyDescriptor.PropertyType Is GetType(String) Then

                    If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).Any Then

                        MaxLength = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).FirstOrDefault.Length

                    End If

                End If

                If PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Decimal)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(Decimal) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Double)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(Double) Then

                    If PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).Any Then

                        DecimalPrecisionAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault

                        If DecimalPrecisionAttribute IsNot Nothing Then

                            Precision = DecimalPrecisionAttribute.Precision
                            Scale = DecimalPrecisionAttribute.Scale

                        End If

                    End If

                End If

                IsRequired = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.RequiredAttribute).Any

                AdvantageFramework.BaseClasses.LoadPropertyAttributes(PropertyDescriptor, IsRequired, PropertyType, DisplayName)

            End If

        End Sub
        Public Shared Sub LoadPropertyAttributes(ByVal Type As System.Type, ByVal PropertyName As String,
                                          ByRef IsEntityKey As Boolean, ByRef IsNullable As Boolean, ByRef IsRequired As Boolean,
                                          ByRef MaxLength As Integer, ByRef Precision As Integer, ByRef Scale As Integer,
                                          ByRef PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByRef DisplayName As String)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim DecimalPrecisionAttribute As AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute = Nothing
            Dim RequiredAttribute As System.ComponentModel.DataAnnotations.RequiredAttribute = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Type).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = PropertyName).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                If PropertyDescriptor.PropertyType Is GetType(System.Nullable) OrElse
                        RequiredAttribute Is Nothing OrElse
                        (RequiredAttribute IsNot Nothing AndAlso RequiredAttribute.AllowEmptyStrings) OrElse
                        EntityAttribute Is Nothing OrElse
                        (EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False) Then

                    IsNullable = True

                End If

                IsEntityKey = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.KeyAttribute).Any

                If PropertyDescriptor.PropertyType Is GetType(String) Then

                    If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).Any Then

                        MaxLength = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).FirstOrDefault.Length

                    End If

                End If

                If PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Decimal)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(Decimal) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Double)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(Double) Then

                    If PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).Any Then

                        DecimalPrecisionAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault

                        If DecimalPrecisionAttribute IsNot Nothing Then

                            Precision = DecimalPrecisionAttribute.Precision
                            Scale = DecimalPrecisionAttribute.Scale

                        End If

                    End If

                End If

                IsRequired = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.RequiredAttribute).Any

                AdvantageFramework.BaseClasses.LoadPropertyAttributes(PropertyDescriptor, IsRequired, PropertyType, DisplayName)

            End If

        End Sub
        Public Function CreateXML() As String Implements Interfaces.IValidatingClass.CreateXML

            CreateXML = AdvantageFramework.BaseClasses.CreateXML(Me)

        End Function
        Public Function ImportFromXML(ByVal XML As String) As AdvantageFramework.BaseClasses.Entity Implements Interfaces.IValidatingClass.ImportFromXML

            ImportFromXML = AdvantageFramework.BaseClasses.ImportFromXML(XML, Me.GetType)

        End Function
        Public Overridable Function ValidateEntity(ByRef IsValid As Boolean) As String Implements Interfaces.IValidatingClass.ValidateEntity

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(Me.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                If PropertyDescriptor.PropertyType IsNot GetType(Byte()) AndAlso (PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String)) Then

                    OldValue = PropertyDescriptor.GetValue(Me)
                    Value = OldValue

                    PropertyErrorText = ValidateEntityProperty(PropertyDescriptor.Name, PropertyIsValid, Value)

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

            ValidateEntity = ErrorText

        End Function
        Public Overridable Function ValidateEntityProperty(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String Implements Interfaces.IValidatingClass.ValidateEntityProperty

            'objects
            Dim ErrorText As String = ""
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim DisplayName As String = Nothing

            IsValid = True

            LoadPropertyAttributes(PropertyName, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision,
                                   Scale, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName)

            End If

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, IsEntityKey, IsRequired, IsNullable, MaxLength, Precision, Scale)

                If IsValid Then

                    If PropertyType <> PropertyTypes.Default Then

                        Select Case PropertyType

                            Case PropertyTypes.FunctionCode, PropertyTypes.EmployeeFunctionCode, PropertyTypes.VendorFunctionCode, PropertyTypes.ClientCode, PropertyTypes.DivisionCode, PropertyTypes.ProductCode,
                                    PropertyTypes.EmployeeCode, PropertyTypes.VendorCode, PropertyTypes.GeneralLedgerAccountCode, PropertyTypes.OfficeCode, PropertyTypes.CurrencyCode, PropertyTypes.BankCode,
                                    PropertyTypes.SalesTaxCode, PropertyTypes.DepartmentTeamCode, PropertyTypes.ClientContactID, PropertyTypes.PurchaseOrderApprovalRuleCode, PropertyTypes.ServiceFeeTypeCode,
                                    PropertyTypes.SalesClassCode, PropertyTypes.RoleCode, PropertyTypes.EmployeeTitleID, PropertyTypes.VendorTermCode, PropertyTypes.FunctionHeadingID, PropertyTypes.IndirectCategoryType,
                                    PropertyTypes.JobNumber, PropertyTypes.PostPeriodCode, PropertyTypes.WebsiteTypeCode, PropertyTypes.PTORule, PropertyTypes.MarketCode, PropertyTypes.AdSizeCode, PropertyTypes.DaypartID,
                                    PropertyTypes.JobVersionDatabaseType, PropertyTypes.TaskCode, PropertyTypes.Phase, PropertyTypes.PartnerCode, PropertyTypes.DaypartTypeID, PropertyTypes.ExpenseEmployee, PropertyTypes.Blackplate,
                                    PropertyTypes.EmployeeCategoryID, PropertyTypes.MediaPlanID, PropertyTypes.MediaPlanDetailID, PropertyTypes.IndirectCategory,
                                    PropertyTypes.LocationID, PropertyTypes.Status, PropertyTypes.DaypartCode, PropertyTypes.ProductCategory, PropertyTypes.ContactTypeID,
                                    PropertyTypes.ClientDiscount

                                If _DbContext IsNot Nothing AndAlso _DbContext.IsDisposed = False Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(_DbContext.Database.Connection.ConnectionString, _DbContext.UserCode)

                                        ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                                    End Using

                                Else

                                    _DbContext = Nothing

                                    If _DataContext IsNot Nothing AndAlso _DataContext.IsDisposed Then

                                        _DataContext = Nothing

                                    End If

                                End If

                            Case Else

                                ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, _DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                        End Select

                    End If

                End If

                ErrorText &= ValidateCustomProperties(PropertyName, IsValid, Value)

            Catch ex As Exception
                IsValid = True
            End Try

            FinalizeEntityPropertyValidation(PropertyName, IsValid, Value, ErrorText, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyName, Value)

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function
        Protected Overridable Sub ClearNonRequiredPropertiesWithInvalidBlankValues(ByVal PropertyName As String, ByRef Value As Object)



        End Sub
        Protected Overridable Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                   ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                   ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)



        End Sub
        Public Function IsEntityBeingAdded() As Boolean

            'objects
            Dim EntityIsBeingAdded As Boolean = False
            Dim EntityKey As System.Data.Entity.Core.EntityKey = Nothing

            Try

                If Me.EntityKey Is Nothing Then

                    EntityIsBeingAdded = True

                ElseIf Me.EntityKey.IsTemporary Then

                    EntityIsBeingAdded = True

                End If

            Catch ex As Exception
                EntityIsBeingAdded = True
            Finally
                IsEntityBeingAdded = EntityIsBeingAdded
            End Try

        End Function
        Public Overridable Sub SetRequiredFields()



        End Sub
        Public Overridable Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ValidateCustomProperties = ""

        End Function
        Public Overridable Function DuplicateEntity() As AdvantageFramework.BaseClasses.Entity

            'objects
            Dim Entity As AdvantageFramework.BaseClasses.Entity = Nothing
            Dim Browsable As Boolean = False

            Try

                If Me.GetType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                    Entity = System.Activator.CreateInstance(Me.GetType)

                End If

            Catch ex As Exception
                Entity = Nothing
            End Try

            If Entity IsNot Nothing Then

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(Me.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    Browsable = True

                    If PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String) Then

                        If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any Then

                            Try

                                Browsable = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).FirstOrDefault.Browsable

                            Catch ex As Exception
                                Browsable = True
                            End Try

                        End If

                        If Browsable Then

                            If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.KeyAttribute).Any = False Then

                                PropertyDescriptor.SetValue(Entity, PropertyDescriptor.GetValue(Me))

                            End If

                        End If

                    End If

                Next

            End If

            DuplicateEntity = Entity

        End Function
        Public Sub SetRequired(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal IsRequired As Boolean)

            AdvantageFramework.BaseClasses.SetRequired(PropertyDescriptor, IsRequired)

        End Sub
        Public Sub SetRequired(ByVal PropertyName As String, ByVal IsRequired As Boolean)

            AdvantageFramework.BaseClasses.SetRequired(Me, PropertyName, IsRequired)

        End Sub
        Public Sub SetPropertyValue(ByVal PropertyName As String, ByVal NewValue As Object)

            AdvantageFramework.BaseClasses.SetPropertyValue(Me, PropertyName, NewValue)

        End Sub
        Public Shared Function LoadPropertyMaxLength(PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As Integer

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If PropertyDescriptor IsNot Nothing Then

                LoadPropertyAttributes(PropertyDescriptor, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyMaxLength = MaxLength

        End Function
        Public Shared Function LoadPropertyMaxLength(EntityType As Type, PropertyName As String) As Integer

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If EntityType IsNot Nothing AndAlso String.IsNullOrWhiteSpace(PropertyName) = False Then

                LoadPropertyAttributes(EntityType, PropertyName, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyMaxLength = MaxLength

        End Function
        Public Shared Function LoadPropertyPrecision(EntityType As Type, PropertyName As String) As Integer

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If EntityType IsNot Nothing AndAlso String.IsNullOrWhiteSpace(PropertyName) = False Then

                LoadPropertyAttributes(EntityType, PropertyName, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyPrecision = Precision

        End Function
        Public Shared Function LoadPropertyPrecision(PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As Integer

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If PropertyDescriptor IsNot Nothing Then

                LoadPropertyAttributes(PropertyDescriptor, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyPrecision = Precision

        End Function
        Public Shared Function LoadPropertyScale(EntityType As Type, PropertyName As String) As Integer

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If EntityType IsNot Nothing AndAlso String.IsNullOrWhiteSpace(PropertyName) = False Then

                LoadPropertyAttributes(EntityType, PropertyName, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyScale = Scale

        End Function
        Public Shared Function LoadPropertyScale(PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As Integer

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If PropertyDescriptor IsNot Nothing Then

                LoadPropertyAttributes(PropertyDescriptor, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyScale = Scale

        End Function
        Public Shared Function LoadProperty(EntityType As Type, PropertyName As String) As System.ComponentModel.PropertyDescriptor

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If EntityType IsNot Nothing Then

                Try

                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(EntityType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = PropertyName).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

            End If

            LoadProperty = PropertyDescriptor

        End Function
        Public Shared Function LoadProperty(EnumProperty As [Enum]) As System.ComponentModel.PropertyDescriptor

            LoadProperty = LoadProperty(EnumProperty.GetType.DeclaringType, EnumProperty.ToString)

        End Function
        Public Shared Function LoadPropertyIsNullable(PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As Boolean

            'objects
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Integer = 0
            Dim Scale As Integer = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim DisplayName As String = ""

            If PropertyDescriptor IsNot Nothing Then

                LoadPropertyAttributes(PropertyDescriptor, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            End If

            LoadPropertyIsNullable = IsNullable

        End Function

#End Region

    End Class

End Namespace
