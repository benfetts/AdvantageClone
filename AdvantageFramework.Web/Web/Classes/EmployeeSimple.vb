Namespace Database.Entities

    <Serializable()>
    Public Class EmployeeSimple

        Public Property Code As String = String.Empty
        Public Property FirstName As String = String.Empty
        Public Property MiddleInitial As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property NickName As String = String.Empty
        Public Property Picture As Byte() = Nothing
        Public ReadOnly Property FullName As String
            Get
                Return If(FirstName IsNot Nothing, FirstName & " ", "") & If(MiddleInitial IsNot Nothing, MiddleInitial & ". ", "") & If(LastName IsNot Nothing, LastName, "")
            End Get
        End Property
        Public ReadOnly Property FullNameWithNickName As String
            Get
                If NickName IsNot Nothing Then
                    Return If(NickName IsNot Nothing, NickName & " ", "") & If(LastName IsNot Nothing, LastName, "")
                Else
                    Return If(FirstName IsNot Nothing, FirstName & " ", "") & If(MiddleInitial IsNot Nothing, MiddleInitial & ". ", "") & If(LastName IsNot Nothing, LastName, "")
                End If
            End Get
        End Property
        Public Property Selected As Boolean = False
        Public ReadOnly Property EmployeePictureURL As String
            Get
                Try
                    If Picture IsNot Nothing AndAlso Picture.Length > 0 Then
                        Return String.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(Picture))
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                    Return String.Empty
                End Try
            End Get
        End Property
        Sub New()

        End Sub

    End Class

End Namespace
