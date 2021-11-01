Namespace Database.Entities

    <Table("VCC_CARD")>
    Public Class VCCCard
        Inherits BaseClasses.Entity
        Implements Database.Interfaces.IVCCCard

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VCCProviderID
            CardNumber
            CardAmount
            NumberOfUses
            OrderNumber
            LineNumber
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("VCC_CARD_ID")>
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer Implements Interfaces.IVCCCard.ID

        <Column("VCC_PROVIDER_ID")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VCCProviderID() As Short Implements Interfaces.IVCCCard.VCCProviderID

        <Column("CARD_NUMBER", TypeName:="varchar(MAX)")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CardNumber() As String Implements Interfaces.IVCCCard.CardNumber

        <Column("CARD_AMOUNT")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property CardAmount() As Decimal Implements Interfaces.IVCCCard.CardAmount

        <Column("EXPIRATION_DATE", TypeName:="smalldatetime")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ExpirationDate() As Date Implements Interfaces.IVCCCard.ExpirationDate

        <Column("NBR_OF_USES")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NumberOfUses() As Integer Implements Interfaces.IVCCCard.NumberOfUses

        <Column("ORDER_NBR")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderNumber() As Integer

        <Column("LINE_NBR")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LineNumber() As Short

        <Column("USER_CREATED")>
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreatedByUserCode() As String

        <Column("CREATED_DATE", TypeName:="smalldatetime")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreatedDate() As Date Implements Interfaces.IVCCCard.CreatedDate

        <Column("USER_MODIFIED")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ModifiedByUserCode() As String Implements Interfaces.IVCCCard.ModifiedByUserCode

        <Column("MODIFIED_DATE", TypeName:="smalldatetime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ModifiedDate() As Nullable(Of Date) Implements Interfaces.IVCCCard.ModifiedDate

        <Column("LAST_REFRESHED_DATE", TypeName:="datetime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastRefreshedDate() As Nullable(Of Date) Implements Interfaces.IVCCCard.LastRefreshedDate

        <Column("CVC_CODE")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CVCCode() As String Implements Interfaces.IVCCCard.CVCCode

        <Column("STATUS")>
        <Required>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Status() As String Implements Interfaces.IVCCCard.Status

        <Column("REVIEWED"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Reviewed() As Boolean Implements Interfaces.IVCCCard.Reviewed

        <Column("RESOLVED"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Resolved() As Boolean Implements Interfaces.IVCCCard.Resolved

        <Column("FOLLOWUP_DATE", TypeName:="smalldatetime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Follow-up Date")>
        Public Property FollowupDate() As Nullable(Of Date) Implements Interfaces.IVCCCard.FollowupDate

        <Column("CARD_CTS")>
        <Required>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CardCTS() As String

        Public Overridable Property VCCCardDetails As ICollection(Of VCCCardDetail)
        Public Overridable Property VCCCardNotes As ICollection(Of VCCCardNote)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Function CardType() As Interfaces.IVCCCard.EnumCardType Implements Interfaces.IVCCCard.CardType

            CardType = Interfaces.IVCCCard.EnumCardType.MediaOrder

        End Function
        Public Function GetVCCCardDetails() As IEnumerable(Of Interfaces.IVCCCardDetail) Implements Interfaces.IVCCCard.VCCCardDetails

            GetVCCCardDetails = Me.VCCCardDetails.ToList

        End Function
        Public Function GetVCCCardNotes() As IEnumerable(Of Interfaces.IVCCCardNote) Implements Interfaces.IVCCCard.VCCCardNotes

            GetVCCCardNotes = Me.VCCCardNotes.ToList

        End Function
        Public Sub RefreshNotes(DbContext As AdvantageFramework.Database.DbContext) Implements Interfaces.IVCCCard.RefreshNotes

            Me.VCCCardNotes = DbContext.VCCCards.Find(Me.ID).VCCCardNotes.ToList

        End Sub

#End Region

    End Class

End Namespace
