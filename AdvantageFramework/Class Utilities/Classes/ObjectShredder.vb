Namespace ClassUtilities

    Public Class ObjectShredder(Of T)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FieldInfoArray As System.Reflection.FieldInfo() = Nothing
        Private _OrdinalMap As Dictionary(Of String, Integer) = Nothing
        Private _PropertyInfoArray As System.Reflection.PropertyInfo() = Nothing
        Private _Type As Type = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            _Type = GetType(T)
            _FieldInfoArray = _Type.GetFields
            _PropertyInfoArray = _Type.GetProperties
            _OrdinalMap = New Dictionary(Of String, Integer)

        End Sub
        Public Function ShredObject(ByVal DataTable As DataTable, ByVal Instance As T) As Object()

            'objects
            Dim FieldInfoArray As System.Reflection.FieldInfo() = Nothing
            Dim PropertyInfoArray As System.Reflection.PropertyInfo() = Nothing
            Dim ValuesArray As Object() = Nothing
            Dim FieldInfo As System.Reflection.FieldInfo = Nothing
            Dim PropertyInfo As System.Reflection.PropertyInfo = Nothing

            FieldInfoArray = _FieldInfoArray
            PropertyInfoArray = _PropertyInfoArray

            If (Not Instance.GetType Is GetType(T)) Then

                Me.ExtendTable(DataTable, Instance.GetType)

                FieldInfoArray = Instance.GetType.GetFields
                PropertyInfoArray = Instance.GetType.GetProperties

            End If

            ValuesArray = New Object(DataTable.Columns.Count - 1) {}

            For Each FieldInfo In FieldInfoArray

                ValuesArray(_OrdinalMap.Item(FieldInfo.Name)) = FieldInfo.GetValue(Instance)

            Next

            For Each PropertyInfo In PropertyInfoArray

                ValuesArray(_OrdinalMap.Item(PropertyInfo.Name)) = PropertyInfo.GetValue(Instance, Nothing)

            Next

            ShredObject = ValuesArray

        End Function
        Public Function Shred(ByVal Source As IEnumerable(Of T), ByVal DataTable As DataTable, ByVal LoadOption As LoadOption?) As DataTable

            'objects
            Dim ShreddedDataTable As System.Data.DataTable = Nothing

            If GetType(T).IsPrimitive Then

                ShreddedDataTable = Me.ShredPrimitive(Source, DataTable, LoadOption)

            Else

                If DataTable Is Nothing Then

                    DataTable = New DataTable(GetType(T).Name)

                End If

                DataTable = Me.ExtendTable(DataTable, GetType(T))

                DataTable.BeginLoadData()

                Using Enumerator As IEnumerator(Of T) = Source.GetEnumerator

                    Do While Enumerator.MoveNext

                        If LoadOption.HasValue Then

                            DataTable.LoadDataRow(Me.ShredObject(DataTable, Enumerator.Current), LoadOption.Value)

                        Else

                            DataTable.LoadDataRow(Me.ShredObject(DataTable, Enumerator.Current), True)

                        End If

                    Loop

                End Using

                DataTable.EndLoadData()

                ShreddedDataTable = DataTable

            End If

            Shred = ShreddedDataTable

        End Function
        Public Function ShredPrimitive(ByVal Source As IEnumerable(Of T), ByVal DataTable As DataTable, ByVal LoadOption As LoadOption?) As DataTable

            'objects
            Dim ValuesArray As Object() = Nothing

            If DataTable Is Nothing Then

                DataTable = New DataTable(GetType(T).Name)

            End If

            If Not DataTable.Columns.Contains("Value") Then

                DataTable.Columns.Add("Value", GetType(T))

            End If

            DataTable.BeginLoadData()

            Using Enumerator As IEnumerator(Of T) = Source.GetEnumerator

                ValuesArray = New Object(DataTable.Columns.Count - 1) {}

                Do While Enumerator.MoveNext

                    ValuesArray(DataTable.Columns.Item("Value").Ordinal) = Enumerator.Current

                    If LoadOption.HasValue Then

                        DataTable.LoadDataRow(ValuesArray, LoadOption.Value)

                    Else

                        DataTable.LoadDataRow(ValuesArray, True)

                    End If

                Loop

            End Using

            DataTable.EndLoadData()

            ShredPrimitive = DataTable

        End Function
        Public Function ExtendTable(ByVal DataTable As DataTable, ByVal Type As Type) As DataTable

            'objects
            Dim FieldInfo As System.Reflection.FieldInfo = Nothing
            Dim PropertyInfo As System.Reflection.PropertyInfo = Nothing
            Dim DataColumn As DataColumn = Nothing

            For Each FieldInfo In Type.GetFields

                If Not _OrdinalMap.ContainsKey(FieldInfo.Name) Then

                    DataColumn = IIf(DataTable.Columns.Contains(FieldInfo.Name), DataTable.Columns.Item(FieldInfo.Name), DataTable.Columns.Add(FieldInfo.Name, FieldInfo.FieldType))

                    _OrdinalMap.Add(FieldInfo.Name, DataColumn.Ordinal)

                End If

            Next

            For Each PropertyInfo In Type.GetProperties

                If Not _OrdinalMap.ContainsKey(PropertyInfo.Name) Then

                    DataColumn = IIf(DataTable.Columns.Contains(PropertyInfo.Name), DataTable.Columns.Item(PropertyInfo.Name), DataTable.Columns.Add(PropertyInfo.Name, PropertyInfo.PropertyType))

                    _OrdinalMap.Add(PropertyInfo.Name, DataColumn.Ordinal)

                End If

            Next

            ExtendTable = DataTable

        End Function

#End Region

    End Class

End Namespace
