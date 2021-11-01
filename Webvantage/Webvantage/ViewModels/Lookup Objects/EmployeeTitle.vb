Namespace ViewModels.LookupObjects

    Public Class EmployeeTitle
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTitleID
            EmployeeTitle
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeTitleID As Integer
        Public Property EmployeeTitle As String

        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (EmployeeTitle + Space(1)).ToLower
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


