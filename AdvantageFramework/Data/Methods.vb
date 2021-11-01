Namespace Data

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

        <System.Runtime.CompilerServices.Extension>
        Public Function RemoveRowsByValue(ByRef DataTable As System.Data.DataTable, ColumnName As String, Value As Object) As Boolean

            'objects
            Dim RowsRemoved As Boolean = False

            If DataTable IsNot Nothing Then

                If DataTable.Columns.Contains(ColumnName) Then

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(ColumnName) = Value).ToList

                        DataTable.Rows.Remove(DataRow)
                        RowsRemoved = True

                    Next

                End If

            End If

            RemoveRowsByValue = RowsRemoved

        End Function
        '<System.Runtime.CompilerServices.Extension()>
        'Public Iterator Function Batch(Of TSource)(Source As IEnumerable(Of TSource), Size As Integer) As IEnumerable(Of IEnumerable(Of TSource))

        '    Dim Bucket As TSource() = Nothing
        '    Dim Count As Integer = 0

        '    For Each Item In Source

        '        If Bucket Is Nothing Then

        '            Bucket = New TSource(Size - 1) {}

        '        End If

        '        Bucket(Math.Min(System.Threading.Interlocked.Increment(Count), Count - 1)) = Item

        '        If Count <> Size Then

        '            Continue For

        '        End If

        '        Yield Bucket

        '        Bucket = Nothing
        '        Count = 0

        '    Next

        '    If Bucket IsNot Nothing AndAlso Count > 0 Then

        '        Yield Bucket.Take(Count).ToArray()

        '    End If

        'End Function
        '<System.Runtime.CompilerServices.Extension()>
        'Public Iterator Function Batch(Of TSource)(Source As Generic.List(Of TSource), Size As Integer) As IEnumerable(Of Generic.List(Of TSource))

        '    Dim Bucket As TSource() = Nothing
        '    Dim Count As Integer = 0

        '    For Each Item In Source

        '        If Bucket Is Nothing Then

        '            Bucket = New TSource(Size - 1) {}

        '        End If

        '        Bucket(Math.Min(System.Threading.Interlocked.Increment(Count), Count - 1)) = Item

        '        If Count <> Size Then

        '            Continue For

        '        End If

        '        Yield Bucket.ToList

        '        Bucket = Nothing
        '        Count = 0

        '    Next

        '    If Bucket IsNot Nothing AndAlso Count > 0 Then

        '        Yield Bucket.Take(Count).ToList

        '    End If

        'End Function
        '<System.Runtime.CompilerServices.Extension()>
        'Public Function Batch(ByVal items As IEnumerable(Of T), ByVal maxItems As Integer) As IEnumerable(Of IEnumerable(Of T))
        '    Return items.[Select](Function(item, inx) New With {item, inx
        '    }).GroupBy(Function(x) x.inx / maxItems).[Select](Function(g) g.[Select](Function(x) x.item))
        'End Function
        <System.Runtime.CompilerServices.Extension()>
        Public Iterator Function Batch(Of T)(ByVal source As System.Collections.Generic.IEnumerable(Of T), ByVal size As Integer) As IEnumerable(Of IEnumerable(Of T))
            If size <= 0 Then Throw New ArgumentOutOfRangeException("size", "Must be greater than zero.")

            Using enumerator As IEnumerator(Of T) = source.GetEnumerator()

                While enumerator.MoveNext()
                    Yield TakeIEnumerator(enumerator, size)
                End While
            End Using
        End Function

        Private Iterator Function TakeIEnumerator(Of T)(ByVal source As IEnumerator(Of T), ByVal size As Integer) As IEnumerable(Of T)
            Dim i As Integer = 0

            Do
                Yield source.Current
            Loop While System.Threading.Interlocked.Increment(i) < size AndAlso source.MoveNext()
        End Function
#End Region

    End Module

End Namespace
