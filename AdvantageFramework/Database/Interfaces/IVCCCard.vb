Namespace Database.Interfaces

    Public Interface IVCCCard

#Region " Constants "



#End Region

#Region " Enum "

        Enum EnumCardType
            MediaOrder
            PurchaseOrder
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Property ID() As Integer

        Property VCCProviderID() As Short

        Property CardNumber() As String

        Property CardAmount() As Decimal

        Property ExpirationDate() As Date

        Property NumberOfUses() As Integer

        Property CreatedDate() As Date

        Property ModifiedByUserCode() As String

        Property ModifiedDate() As Nullable(Of Date)

        Property LastRefreshedDate() As Nullable(Of Date)

        Property CVCCode() As String

        Property Status() As String

        Property Reviewed() As Boolean

        Property Resolved() As Boolean

        Property FollowupDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Function CardType() As EnumCardType

        Function VCCCardDetails() As IEnumerable(Of Interfaces.IVCCCardDetail)

        Function VCCCardNotes() As IEnumerable(Of Interfaces.IVCCCardNote)

        Sub RefreshNotes(DbContext As AdvantageFramework.Database.DbContext)

#End Region

    End Interface

End Namespace

