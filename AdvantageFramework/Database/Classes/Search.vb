Namespace Database.Classes

    <Serializable()>
    Public Class Search

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            DivisionCode
            ProductCode
            GroupID
            Group
            MatchingText
            Link
            ID1
            ID2
            ID3
            ID4
            ID5
            ID6
            ID7
            ID8
            ID9
            ID10
            GroupCount
            DateForSort
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID() As Integer

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

        Public Property GroupID() As Nullable(Of Byte)

        Public Property Group() As String

        Public Property MatchingText() As String

        Public Property Link() As String

        Public Property ID1() As Nullable(Of Integer)

        Public Property ID2() As Nullable(Of Integer)

        Public Property ID3() As Nullable(Of Integer)

        Public Property ID4() As Nullable(Of Integer)

        Public Property ID5() As Nullable(Of Integer)

        Public Property ID6() As String

        Public Property ID7() As String

        Public Property ID8() As String

        Public Property ID9() As String

        Public Property ID10() As String

        Public Property GroupCount() As Nullable(Of Integer)

        Public Property DateForSort() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
