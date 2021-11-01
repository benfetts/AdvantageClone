Namespace Database.Entities

	<Table("RATE_CARD_HDR")>
	Public Class RateCard
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Type
			Code
			VendorCode
			Description
			IsInactive
			DateFrom
			DateTo
			MaterialClose
			SpaceClose
			CommissionPercent
			NetCharge
			NetChargeDescription
			ProductionCharge
			ProductionDescription
			NetDiscountAmount
			NetDiscountDescription
			BleedPercent
			PositionPercent
			PremiumPercent
			IsContract
			ContractClientCode
			PositionInfo
			RateInfo
			MiscInfo
			ClosingInfo
			ContractInfo
			Vendor
			RateCardDetails
			RateCardColorCharges

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("RATE_CARD_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(1)>
		<Column("RATE_CARD_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<Required>
		<MaxLength(10)>
		<Column("RATE_CARD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorCode)>
		Public Property VendorCode() As String
		<MaxLength(40)>
		<Column("RATE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Short
		<Column("DATE_FROM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property DateFrom() As Nullable(Of Date)
		<Column("DATE_TO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property DateTo() As Nullable(Of Date)
		<Column("MATL_CLOSE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaterialClose() As Nullable(Of Integer)
		<Column("SPACE_CLOSE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SpaceClose() As Nullable(Of Integer)
		<Column("COMM_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommissionPercent() As Nullable(Of Decimal)
		<Column("NET_CHARGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetCharge() As Nullable(Of Decimal)
		<MaxLength(60)>
		<Column("NET_CHARGE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetChargeDescription() As String
		<Column("PRODUCTION_CHARGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("PRODUCTION_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionDescription() As String
		<Column("NET_DISC_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetDiscountAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("NET_DISC_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetDiscountDescription() As String
		<Column("BLEED_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BleedPercent() As Nullable(Of Decimal)
		<Column("POSITION_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PositionPercent() As Nullable(Of Decimal)
		<Column("PREMIUM_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PremiumPercent() As Nullable(Of Decimal)
		<Required>
		<Column("CONTRACT_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsContract() As Short
		<MaxLength(6)>
		<Column("CONTRACT_CLIENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContractClientCode() As String
		<Column("POSITION_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PositionInfo() As String
		<Column("RATE_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateInfo() As String
		<Column("MISC_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiscInfo() As String
		<Column("CLOSING_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClosingInfo() As String
		<Column("CONTRACT_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContractInfo() As String

        Public Overridable Property Vendor As Database.Entities.Vendor
        Public Overridable Property RateCardDetails As ICollection(Of Database.Entities.RateCardDetail)
        Public Overridable Property RateCardColorCharges As ICollection(Of Database.Entities.RateCardColorCharge)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects 
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If Me.IsEntityBeingAdded() Then

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).RateCards
                        Where Entity.Code.ToUpper = Me.Code.ToUpper AndAlso
                                                  Entity.VendorCode.ToUpper = Me.VendorCode.ToUpper
                        Select Entity).Any Then

                        IsValid = False
                        ErrorText = "Please enter a unqiue rate card."

                    End If

                End If

            End If

            ValidateEntity = ErrorText

        End Function

#End Region

	End Class

End Namespace
