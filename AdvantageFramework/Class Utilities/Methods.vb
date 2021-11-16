Namespace ClassUtilities

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function GetPropertyValueFromObject(ByVal [Object] As Object, ByVal PropertyName As String) As Object

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim Properties As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim PropertyValue As Object = Nothing

            Try

                Properties = System.ComponentModel.TypeDescriptor.GetProperties([Object].GetType)

                PropertyDescriptor = (From [Property] In Properties _
                                      Where DirectCast([Property], System.ComponentModel.PropertyDescriptor).Name.ToUpper = PropertyName.ToUpper _
                                      Select [Property]).FirstOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            Finally

                If PropertyDescriptor IsNot Nothing Then

                    PropertyValue = PropertyDescriptor.GetValue([Object])

                End If

            End Try

            GetPropertyValueFromObject = PropertyValue

        End Function
        Public Function GetPropertyDescriptorByPropertyNameFromType(ByVal FieldName As String, ByVal Type As System.Type) As System.ComponentModel.PropertyDescriptor

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim Properties As System.ComponentModel.PropertyDescriptorCollection = Nothing

            Try

                Properties = System.ComponentModel.TypeDescriptor.GetProperties(Type)

                PropertyDescriptor = (From [Property] In Properties _
                                      Where DirectCast([Property], System.ComponentModel.PropertyDescriptor).Name.ToUpper = FieldName.ToUpper _
                                      Select [Property]).FirstOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            GetPropertyDescriptorByPropertyNameFromType = PropertyDescriptor

        End Function
        Public Function GetParameterContent(ParameterDictionary As Generic.Dictionary(Of String, Object)) As String

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim XmlDictionaryWriter As System.Xml.XmlDictionaryWriter = Nothing
            Dim DataContractSerializer As System.Runtime.Serialization.DataContractSerializer = Nothing
            Dim ParameterContent As String = Nothing
            Dim KnownTypes As List(Of Type) = Nothing

            KnownTypes = New List(Of Type) From {GetType(List(Of String))}
            KnownTypes.Add(GetType(List(Of Integer)))

            MemoryStream = New System.IO.MemoryStream()
            XmlDictionaryWriter = System.Xml.XmlDictionaryWriter.CreateTextWriter(MemoryStream)

            XmlDictionaryWriter.WriteStartDocument(True)

            DataContractSerializer = New System.Runtime.Serialization.DataContractSerializer(GetType(Generic.Dictionary(Of String, Object)), KnownTypes)
            DataContractSerializer.WriteStartObject(XmlDictionaryWriter, ParameterDictionary)
            DataContractSerializer.WriteObjectContent(XmlDictionaryWriter, ParameterDictionary)
            DataContractSerializer.WriteEndObject(XmlDictionaryWriter)

            XmlDictionaryWriter.WriteEndDocument()
            XmlDictionaryWriter.Flush()

            ParameterContent = System.Text.Encoding.ASCII.GetString(MemoryStream.ToArray())

            MemoryStream.Flush()
            MemoryStream.Close()

            GetParameterContent = ParameterContent

        End Function
        Public Function ReadObjectContentInDocument(InputString As String) As Generic.Dictionary(Of String, Object)

            'objects
            Dim XmlDictionaryReader As System.Xml.XmlDictionaryReader = Nothing
            Dim DataContractSerializer As System.Runtime.Serialization.DataContractSerializer = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim KnownTypes As List(Of Type) = Nothing

            KnownTypes = New List(Of Type) From {GetType(List(Of String))}
            KnownTypes.Add(GetType(List(Of Integer)))

            XmlDictionaryReader = System.Xml.XmlDictionaryReader.CreateTextReader(System.Text.Encoding.ASCII.GetBytes(InputString), New System.Xml.XmlDictionaryReaderQuotas())

            DataContractSerializer = New System.Runtime.Serialization.DataContractSerializer(GetType(Generic.Dictionary(Of String, Object)), KnownTypes)

            ParameterDictionary = CType(DataContractSerializer.ReadObject(XmlDictionaryReader, True), Generic.Dictionary(Of String, Object))

            XmlDictionaryReader.Close()

            ReadObjectContentInDocument = ParameterDictionary

        End Function
        Public Function GetUnderlyingType(ByVal PropertyType As System.Type) As System.Type

            'objects
            Dim UnderlyingType As System.Type = Nothing

            Try

                If Nullable.GetUnderlyingType(PropertyType) IsNot Nothing Then

                    UnderlyingType = Nullable.GetUnderlyingType(PropertyType)

                Else

                    UnderlyingType = PropertyType

                End If

            Catch ex As Exception
                UnderlyingType = PropertyType
            Finally
                GetUnderlyingType = UnderlyingType
            End Try

        End Function
        '<System.Runtime.CompilerServices.Extension()>
        'Public Function GetAllExceptionMessages(Exception As Exception) As String

        '    Dim Messages As IEnumerable(Of String) = Exception.FromHierarchy(Function(Except) Except.InnerException).[Select](Function(Except) Except.Message)

        '    GetAllExceptionMessages = String.Join(Environment.NewLine, Messages)

        'End Function

#End Region

    End Module

End Namespace

