Namespace BaseClasses

    <Serializable()>
    Public MustInherit Class BaseClass
        Implements System.ComponentModel.IDataErrorInfo,  _
                   AdvantageFramework.BaseClasses.Interfaces.IValidatingClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        <System.NonSerialized()>
        Protected _DbContext As AdvantageFramework.BaseClasses.DbContext = Nothing
        <System.NonSerialized()>
        Protected _DataContext As AdvantageFramework.BaseClasses.DataContext = Nothing
        Protected _ErrorHashtable As Hashtable = Nothing
        Protected _EntityError As String = ""

#End Region

#Region " Properties "

        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public Property DbContext As AdvantageFramework.BaseClasses.DbContext
            Get
                DbContext = _DbContext
            End Get
            Set(ByVal value As AdvantageFramework.BaseClasses.DbContext)
                _DbContext = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public Property DataContext As AdvantageFramework.BaseClasses.DataContext
            Get
                DataContext = _DataContext
            End Get
            Set(ByVal value As AdvantageFramework.BaseClasses.DataContext)
                _DataContext = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public ReadOnly Property [Error] As String Implements System.ComponentModel.IDataErrorInfo.Error
            Get
                [Error] = _EntityError
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Default Public ReadOnly Property Item(ByVal PropertyName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
            Get
                Item = LoadErrorText(PropertyName)
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public Overridable ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = Nothing
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public Property [EntityError] As String
            Get
                [EntityError] = _EntityError
            End Get
            Set(ByVal value As String)
                _EntityError = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ErrorHashtable = New Hashtable

        End Sub
        Public Overridable Function LoadErrorText(ByVal PropertyName As String) As String

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
        Public Overridable Function HasError() As Boolean Implements Interfaces.IValidatingClass.HasError

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
        Public Overridable Function IsRequiredProperty(ByVal Type As System.Type, ByVal PropertyName As String) As Boolean Implements Interfaces.IValidatingClass.IsRequiredProperty

            'objects
            Dim PropertyIsRequired As Boolean = False

            Try

                PropertyIsRequired = AdvantageFramework.BaseClasses.IsRequiredProperty(Type, PropertyName)

            Catch ex As Exception
                PropertyIsRequired = False
            End Try

            IsRequiredProperty = PropertyIsRequired

        End Function
        Public Overridable Sub LoadPropertyAttributes(ByVal Type As System.Type, ByVal PropertyName As String, ByRef IsRequired As Boolean, _
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

                AdvantageFramework.BaseClasses.LoadPropertyAttributes(PropertyDescriptor, IsRequired, PropertyType, DisplayName)

            End If

        End Sub
        Public Overridable Function CreateXML() As String Implements Interfaces.IValidatingClass.CreateXML

            CreateXML = AdvantageFramework.BaseClasses.CreateXML(Me)

        End Function
        Public Overridable Function ImportFromXML(ByVal XML As String) As AdvantageFramework.BaseClasses.Entity Implements AdvantageFramework.BaseClasses.Interfaces.IValidatingClass.ImportFromXML

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

                If PropertyDescriptor.Attributes.OfType(Of System.Xml.Serialization.XmlIgnoreAttribute).Any = False AndAlso _
                        Not PropertyDescriptor.PropertyType Is GetType(Byte()) Then

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
            Dim IsRequired As Boolean = False
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim DisplayName As String = ""

            LoadPropertyAttributes(Me.GetType, PropertyName, IsRequired, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName)

            End If

            IsValid = True

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, False, IsRequired, True, 0, 0, 0)

                If IsValid Then

                    ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, _DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                End If

                ErrorText &= ValidateCustomProperties(PropertyName, IsValid, Value)

            Catch ex As Exception
                IsValid = True
            End Try

            FinalizeEntityPropertyValidation(PropertyName, IsValid, Value, ErrorText, False, True, IsRequired, 0, 0, 0, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso _
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
        Public Overridable Function IsEntityBeingAdded() As Boolean

            IsEntityBeingAdded = False

        End Function
        Public Overridable Sub SetRequiredFields()



        End Sub
        Public Overridable Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ValidateCustomProperties = ""

        End Function
        Public Overridable Function DuplicateEntity() As AdvantageFramework.BaseClasses.BaseClass

            'objects
            Dim Entity As AdvantageFramework.BaseClasses.BaseClass = Nothing
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

                    If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any Then

                        Try

                            Browsable = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).FirstOrDefault.Browsable

                        Catch ex As Exception
                            Browsable = True
                        End Try

                    End If

                    If Browsable Then

                        PropertyDescriptor.SetValue(Entity, PropertyDescriptor.GetValue(Me))

                    End If

                Next

            End If

            DuplicateEntity = Entity

        End Function
        Public Overridable Sub SetRequired(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal IsRequired As Boolean)

            AdvantageFramework.BaseClasses.SetRequired(PropertyDescriptor, IsRequired)

        End Sub
        Public Overridable Sub SetRequired(ByVal PropertyName As String, ByVal IsRequired As Boolean)

            AdvantageFramework.BaseClasses.SetRequired(Me, PropertyName, IsRequired)

        End Sub
        Public Overridable Sub SetPropertyValue(ByVal PropertyName As String, ByVal NewValue As Object)

            AdvantageFramework.BaseClasses.SetPropertyValue(Me, PropertyName, NewValue)

        End Sub
        Public Overridable Sub SetReadOnly(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal IsReadOnly As Boolean)

            AdvantageFramework.BaseClasses.SetReadOnly(PropertyDescriptor, IsReadOnly)

        End Sub
        Public Overridable Sub SetReadOnly(ByVal PropertyName As String, ByVal IsReadOnly As Boolean)

            AdvantageFramework.BaseClasses.SetReadOnly(Me, PropertyName, IsReadOnly)

        End Sub

#End Region

    End Class

End Namespace
