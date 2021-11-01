Namespace EnumUtilities

    <HideModuleName()> _
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

        Public Function GetEnumDataTable(EnumType As System.Type, NameOnly As Boolean) As System.Data.DataTable

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
        Public Function GetEnumDataTableOld(EnumType As System.Type, CodeType As System.Type) As System.Data.DataTable

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
        Public Function GetEnumDataTable(EnumType As System.Type, CodeType As System.Type) As System.Data.DataTable

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
        Public Function GetEnumDictionaryShort(EnumType As System.Type, Optional NameAsWords As Boolean = True) As Generic.Dictionary(Of Short, String)

            'objects
            Dim Values As System.Array = Nothing
            Dim Value As Long = Nothing
            Dim Name As String = ""
            Dim Dictionary As Generic.Dictionary(Of Short, String) = Nothing

            Dictionary = New Generic.Dictionary(Of Short, String)

            Values = [Enum].GetValues(EnumType)

            For Each Value In Values

                If NameAsWords Then

                    Dictionary.Add(Value, GetNameAsWords(EnumType, Value))

                Else

                    Dictionary.Add(Value, [Enum].Parse(EnumType, Value).ToString())

                End If

            Next

            GetEnumDictionaryShort = Dictionary

        End Function
        Public Function GetEnumDictionary(EnumType As System.Type, Optional NameAsWords As Boolean = True) As Generic.Dictionary(Of Long, String)

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
        Public Function GetEnumNameList(EnumType As System.Type, AsWords As Boolean) As Generic.List(Of String)

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
        Public Function GetNameAsWords(EnumType As System.Type, Value As Long) As String

            'objects
            Dim Name As String = ""

            Name = [Enum].Parse(EnumType, Value).ToString

            GetNameAsWords = Name.GetNameAsWords

        End Function
        Public Function GetNameAsWords(EnumType As System.Type, Value As Integer) As String

            'objects
            Dim Name As String = ""

            Name = [Enum].Parse(EnumType, Value).ToString

            GetNameAsWords = Name.GetNameAsWords

        End Function
        Public Function GetNameAsWords(EnumType As System.Type, Value As Short) As String

            'objects
            Dim Name As String = ""

            Name = [Enum].Parse(EnumType, Value).ToString

            GetNameAsWords = Name.GetNameAsWords

        End Function
        Public Function GetValue(EnumType As System.Type, EnumName As String) As Object

            GetValue = [Enum].Parse(EnumType, EnumName.Replace(" ", ""))

        End Function
        Public Function GetValue(EnumMember As [Enum]) As Object

            GetValue = [Enum].Parse(EnumMember.GetType, EnumMember.ToString)

        End Function
        Public Function IsMemberOfEnum(EnumType As System.Type, Value As Object) As Boolean

            IsMemberOfEnum = [Enum].IsDefined(EnumType, Value)

        End Function

#End Region

    End Module

End Namespace

