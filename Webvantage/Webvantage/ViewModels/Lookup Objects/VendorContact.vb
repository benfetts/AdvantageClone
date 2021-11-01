Namespace ViewModels.LookupObjects

    Public Class VendorContact
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorContactCode
            FirstName
            LastName
            MiddleInitial
            FullName
            EmailAddress
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property VendorContactCode As String
        Public Property FirstName As String
        Public Property LastName As String
        Public Property MiddleInitial As String
        Public Property FullName As String
            Get
                If String.IsNullOrWhiteSpace(MiddleInitial) Then

                    Return FirstName & " " & LastName

                Else

                    Return FirstName & " " & MiddleInitial & ". " & LastName

                End If
            End Get
            Set(value As String)

            End Set
        End Property
        Public Property EmailAddress As String
        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (VendorContactCode + Space(1) + FirstName + Space(1) + MiddleInitial + Space(1) + LastName + Space(1) + FullName + Space(1) + EmailAddress).ToLower
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


