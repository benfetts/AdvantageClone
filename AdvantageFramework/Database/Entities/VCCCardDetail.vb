Namespace Database.Entities

    <Table("VCC_CARD_DTL")>
    Public Class VCCCardDetail
        Inherits BaseClasses.Entity
        Implements Interfaces.IVCCCardDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            Action
            Amount
            CreatedByUserCode
            CreatedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("VCC_CARD_ID", Order:=1)>
        <Key>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Column("SEQ_NBR", Order:=2)>
        <Key>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SequenceNumber() As Short

        <Column("ACTION")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Action() As Short Implements Interfaces.IVCCCardDetail.Action

        <Column("AMOUNT")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property Amount() As Decimal Implements Interfaces.IVCCCardDetail.Amount

        <Column("REFERENCE_NUMBER")>
        <MaxLength(12)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ReferenceNumber() As String Implements Interfaces.IVCCCardDetail.ReferenceNumber

        <Column("REJECT_MESSAGE")>
        <MaxLength(74)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property RejectMessage() As String Implements Interfaces.IVCCCardDetail.RejectMessage

        <Column("USER_CREATED")>
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreatedByUserCode() As String

        <Column("CREATED_DATE", TypeName:="smalldatetime")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreatedDate() As Date

        <Column("PROCESS_DATETIME", TypeName:="datetime")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProcessDateTime() As Date Implements Interfaces.IVCCCardDetail.ProcessDateTime

        <Column("MERCHANT_NAME")>
        <MaxLength(25)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MerchantName() As String Implements Interfaces.IVCCCardDetail.MerchantName

        <ForeignKey("ID")>
        Public Property VCCCard As VCCCard

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
