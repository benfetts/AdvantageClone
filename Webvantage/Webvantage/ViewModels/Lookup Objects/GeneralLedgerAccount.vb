Namespace ViewModels.LookupObjects

    Public Class GeneralLedgerAccount
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GeneralLedgerCode
            GeneralLedgerDescription
            IncludeInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property GeneralLedgerCode As String
        Public Property GeneralLedgerDescription As String
        Public Property IncludeInactive As Boolean
        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (GeneralLedgerCode + Space(1) + GeneralLedgerDescription).ToLower
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


