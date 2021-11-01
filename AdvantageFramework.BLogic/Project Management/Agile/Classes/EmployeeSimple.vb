Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class EmployeeSimple

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _EmployeePictureURL As String = String.Empty
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
        Public Property EmployeePictureURL As String
            Get
                Try
                    If Picture IsNot Nothing AndAlso Picture.Length > 0 Then
                        _EmployeePictureURL = String.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(Picture))
                    Else
                        _EmployeePictureURL = String.Empty
                    End If
                Catch ex As Exception
                    _EmployeePictureURL = String.Empty
                End Try
                Return _EmployeePictureURL
            End Get
            Set(value As String)
                _EmployeePictureURL = value
            End Set
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
