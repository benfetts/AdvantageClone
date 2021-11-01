Namespace ViewModels.LookupObjects

    Public Class Tax
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TaxCode
            TaxDescription
            TaxStatePct
            TaxCountyPct
            TaxCityPct
            TaxResale
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property TaxCode As String
        Public Property TaxDescription As String
        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (TaxCode + Space(1) + TaxDescription).ToLower
            End Get
        End Property
        Public Property TaxStatePct As Nullable(Of Decimal)
        Public Property TaxCountyPct As Nullable(Of Decimal)
        Public Property TaxCityPct As Nullable(Of Decimal)
        Public Property TaxResale As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


