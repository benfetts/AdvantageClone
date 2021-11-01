Namespace ViewModels.LookupObjects

    Public Class Vendor
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            VendorName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property VendorCode As String
        Public Property VendorName As String
        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (VendorCode + Space(1) + VendorName).ToLower
            End Get
        End Property
        Public Property IncludeMediaVendors As Boolean
        Public Property LimitbyDefaultFunction As Boolean

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


