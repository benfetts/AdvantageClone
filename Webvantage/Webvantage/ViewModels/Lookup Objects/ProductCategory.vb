Namespace ViewModels.LookupObjects

    Public Class ProductCategory
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ProductCategoryCode
            ProductCategoryName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ProductCategoryCode As String
        Public Property ProductCategoryName As String
        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (ProductCategoryCode + Space(1) + ProductCategoryName).ToLower
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


