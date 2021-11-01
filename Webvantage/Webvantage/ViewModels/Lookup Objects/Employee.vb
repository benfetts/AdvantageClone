Namespace ViewModels.LookupObjects

    Public Class Employee
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            FirstName
            MiddleInitial
            LastName
            FullName
            EmployeeTitle
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode As String
        Public Property FirstName As String
        Public Property MiddleInitial As String
        Public Property LastName As String
        Public Property EmployeeTitle As String

        Public ReadOnly Property FullName As String
            Get
                If String.IsNullOrWhiteSpace(MiddleInitial) Then

                    Return FirstName & " " & LastName

                Else

                    Return FirstName & " " & MiddleInitial & ". " & LastName

                End If
            End Get
        End Property

        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (EmployeeCode + Space(1) + FirstName + Space(1) + MiddleInitial + Space(1) + LastName + Space(1) + FullName).ToLower
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


