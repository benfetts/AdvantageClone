Namespace EnumUtilities

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetEnumDataTable(ByVal EnumType As System.Type, ByVal NameOnly As Boolean) As System.Data.DataTable

            'objects
            Dim Values As System.Array = Nothing
            Dim Value As Long = Nothing
            Dim Name As String = ""
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing

            DataTable = New System.Data.DataTable

            DataTable.Columns.Add("Name")

            If NameOnly = False Then

                DataTable.Columns.Add("Value")

            End If

            Values = [Enum].GetValues(EnumType)

            For Each Value In Values

                DataRow = DataTable.Rows.Add

                DataRow("Name") = GetNameAsWords(EnumType, Value)

                If NameOnly = False Then

                    DataRow("Value") = Value

                End If

            Next

            GetEnumDataTable = DataTable

        End Function
        Public Function GetEnumDataTable(ByVal EnumType As System.Type, ByVal NameOnly As Boolean, ByVal UseEnumObjects As Boolean) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            If UseEnumObjects Then

                DataTable = New System.Data.DataTable

                DataTable.Columns.Add("Name")

                If NameOnly = False Then

                    DataTable.Columns.Add("Value")

                End If

                For Each EnumObject In LoadEnumObjects(EnumType)

                    DataRow = DataTable.Rows.Add

                    DataRow("Name") = EnumObject.Description

                    If NameOnly = False Then

                        DataRow("Value") = EnumObject.Code

                    End If

                Next

            Else

                DataTable = GetEnumDataTable(EnumType, NameOnly)

            End If

            GetEnumDataTable = DataTable

        End Function
        Public Function GetEnumDataTableOld(ByVal EnumType As System.Type, ByVal CodeType As System.Type) As System.Data.DataTable

            'objects
            Dim Values As System.Array = Nothing
            Dim Value As Int16 = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            DataTable.Columns.Add(New DataColumn("Value", CodeType))
            DataTable.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))

            Values = [Enum].GetValues(EnumType)

            For Each Value In Values

                DataRow = DataTable.Rows.Add

                DataRow("Name") = GetNameAsWords(EnumType, Value)

                DataRow("Value") = Value

            Next

            GetEnumDataTableOld = DataTable

        End Function
        Public Function GetEnumDataTableBlank(CodeType As System.Type) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = New System.Data.DataTable

            DataTable.Columns.Add(New DataColumn("Value", CodeType))
            DataTable.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))

            GetEnumDataTableBlank = DataTable

        End Function
        Public Function GetEnumDataTable(ByVal EnumType As System.Type, ByVal CodeType As System.Type) As System.Data.DataTable

            'objects
            Dim Values As System.Array = Nothing
            Dim Value As Int16 = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            DataTable.Columns.Add(New DataColumn("Code", CodeType))
            DataTable.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))

            Values = [Enum].GetValues(EnumType)

            For Each Value In Values

                DataRow = DataTable.Rows.Add

                DataRow("Description") = GetNameAsWords(EnumType, Value)

                DataRow("Code") = Value

            Next

            GetEnumDataTable = DataTable

        End Function
        Public Function GetEnumDictionary(ByVal EnumType As System.Type, Optional ByVal NameAsWords As Boolean = True) As Generic.Dictionary(Of Long, String)

            'objects
            Dim Values As System.Array = Nothing
            Dim Value As Long = Nothing
            Dim Name As String = ""
            Dim Dictionary As Generic.Dictionary(Of Long, String) = Nothing

            Dictionary = New Generic.Dictionary(Of Long, String)

            Values = [Enum].GetValues(EnumType)

            For Each Value In Values

                If NameAsWords Then

                    Dictionary.Add(Value, GetNameAsWords(EnumType, Value))

                Else

                    Dictionary.Add(Value, [Enum].Parse(EnumType, Value).ToString())

                End If

            Next

            GetEnumDictionary = Dictionary

        End Function
        Public Function GetEnumNameList(ByVal EnumType As System.Type, ByVal AsWords As Boolean) As Generic.List(Of String)

            'objects
            Dim Values As System.Array = Nothing
            Dim Value As Long = Nothing
            Dim NameList As Generic.List(Of String) = Nothing

            NameList = New Generic.List(Of String)

            Values = [Enum].GetValues(EnumType)

            For Each Value In Values

                If AsWords Then

                    NameList.Add(GetNameAsWords(EnumType, Value))

                Else

                    NameList.Add([Enum].Parse(EnumType, Value).ToString)

                End If

            Next

            GetEnumNameList = NameList

        End Function
        Public Function GetNameAsWords(ByVal EnumType As System.Type, ByVal Value As Long) As String

            'objects
            Dim Name As String = ""

            Name = [Enum].Parse(EnumType, Value).ToString

            GetNameAsWords = AdvantageFramework.StringUtilities.GetNameAsWords(Name)

        End Function
        Public Function GetNameAsWords(ByVal EnumType As System.Type, ByVal Value As Integer) As String

            'objects
            Dim Name As String = ""

            Name = [Enum].Parse(EnumType, Value).ToString

            GetNameAsWords = AdvantageFramework.StringUtilities.GetNameAsWords(Name)

        End Function
        Public Function GetNameAsWords(ByVal EnumType As System.Type, ByVal Value As Short) As String

            'objects
            Dim Name As String = ""

            Name = [Enum].Parse(EnumType, Value).ToString

            GetNameAsWords = AdvantageFramework.StringUtilities.GetNameAsWords(Name)

        End Function
        Public Function GetValue(ByVal EnumType As System.Type, ByVal EnumName As String) As Object

            GetValue = [Enum].Parse(EnumType, EnumName.Replace(" ", ""))

        End Function
        Public Function GetValue(ByVal EnumMember As [Enum]) As Object

            GetValue = [Enum].Parse(EnumMember.GetType, EnumMember.ToString)

        End Function
        Public Function IsMemberOfEnum(ByVal EnumType As System.Type, ByVal Value As Object) As Boolean

            IsMemberOfEnum = [Enum].IsDefined(EnumType, Value)

        End Function
        Public Function LoadEnumObjects(ByVal EnumType As System.Type) As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            'objects
            Dim EnumObjectsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            EnumObjectsList = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            For Each EnumName In AdvantageFramework.EnumUtilities.GetEnumNameList(EnumType, False)

                EnumObjectAttribute = System.Attribute.GetCustomAttribute(EnumType.GetField(EnumName), GetType(AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))

                If EnumObjectAttribute IsNot Nothing Then

                    EnumObjectsList.Add(EnumObjectAttribute)

                End If

            Next

            LoadEnumObjects = EnumObjectsList

        End Function
        Public Function LoadEnumObject(ByVal EnumType As System.Type, ByVal Code As String) As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute

            'objects
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            For Each EnumName In AdvantageFramework.EnumUtilities.GetEnumNameList(EnumType, False)

                EnumObjectAttribute = System.Attribute.GetCustomAttribute(EnumType.GetField(EnumName), GetType(AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))

                If EnumObjectAttribute IsNot Nothing Then

                    If EnumObjectAttribute.Code = Code Then

                        Exit For

                    End If

                End If

            Next

            LoadEnumObject = EnumObjectAttribute

        End Function
        Public Function LoadEnumObject(ByVal EnumMember As [Enum]) As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute

            'objects
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            Try

                EnumObjectAttribute = System.Attribute.GetCustomAttribute(EnumMember.GetType.GetField(EnumMember.ToString), GetType(AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))

            Catch ex As Exception
                EnumObjectAttribute = Nothing
            End Try

            LoadEnumObject = EnumObjectAttribute

        End Function
        Public Function LoadEnumObjectDescription(ByVal EnumType As System.Type, ByVal Code As String) As String

            'objects
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim Description As String = ""

            EnumObjectAttribute = LoadEnumObject(EnumType, Code)

            If EnumObjectAttribute IsNot Nothing Then

                Description = EnumObjectAttribute.Description

            End If

            LoadEnumObjectDescription = Description

        End Function

#End Region

    End Module

End Namespace

