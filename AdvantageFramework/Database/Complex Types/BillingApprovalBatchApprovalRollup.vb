Namespace Database.ComplexTypes

	<System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="BillingApprovalBatchApprovalRollup")>
	<Serializable()>
	Public Class BillingApprovalBatchApprovalRollup
		Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

	Public Enum Properties
		RollupCount
				RollupType
				RollupID
				CampaignCode
				Description
				FunctionCode
				FunctionDescription
				FunctionDefaultDescription
				FunctionType
				FunctionTypeDescription
				FunctionHeadingDescription
				QuoteAmount
				Actuals
				BilledReceived
				BilledHold
				NonBillableFee
				Unbilled
				OpenPO
				QuantityHours
				Quantity
				ApprovedAmount
				TempCutoffApprovedAmount
				QuoteNet
				UnbilledNet
				TempUnbilledNet
				ApprovedNet
				TempApprovedNet
				ApprovedMarkupAmount
				ApprovedResaleTax
				ApprovedVendorTax
				ApprovedTax
				QuoteMarkup
				QuoteResaleTax
				QuoteVendorTax
				UnbilledMarkup
				UnbilledResaleTax
				UnbilledVendorTax
				UnbilledTax
				QuoteQuantityHours
				ActualQuantityHours
				TempMarkup
				TempResaleTax
				TempTotal
				TempUnbilledMU
				TempUnbilledTax
				TempUnbilledNR
				TempUnbilledTot
				TempUnbilledPO
			End Enum

#End Region

#Region " Variables "

        Private _RollupCount As Nullable(Of Integer) = Nothing
		        Private _RollupType As Nullable(Of Short) = Nothing
		        Private _RollupID As Nullable(Of Integer) = Nothing
		        Private _CampaignCode As String = Nothing
		        Private _Description As String = Nothing
		        Private _FunctionCode As String = Nothing
		        Private _FunctionDescription As String = Nothing
		        Private _FunctionDefaultDescription As String = Nothing
		        Private _FunctionType As String = Nothing
		        Private _FunctionTypeDescription As String = Nothing
		        Private _FunctionHeadingDescription As String = Nothing
		        Private _QuoteAmount As Nullable(Of Decimal) = Nothing
		        Private _Actuals As Nullable(Of Decimal) = Nothing
		        Private _BilledReceived As Nullable(Of Decimal) = Nothing
		        Private _BilledHold As Nullable(Of Decimal) = Nothing
		        Private _NonBillableFee As Nullable(Of Decimal) = Nothing
		        Private _Unbilled As Nullable(Of Decimal) = Nothing
		        Private _OpenPO As Nullable(Of Decimal) = Nothing
		        Private _QuantityHours As Nullable(Of Decimal) = Nothing
		        Private _Quantity As Nullable(Of Decimal) = Nothing
		        Private _ApprovedAmount As Nullable(Of Decimal) = Nothing
		        Private _TempCutoffApprovedAmount As Nullable(Of Decimal) = Nothing
		        Private _QuoteNet As Nullable(Of Decimal) = Nothing
		        Private _UnbilledNet As Nullable(Of Decimal) = Nothing
		        Private _TempUnbilledNet As Nullable(Of Decimal) = Nothing
		        Private _ApprovedNet As Nullable(Of Decimal) = Nothing
		        Private _TempApprovedNet As Nullable(Of Decimal) = Nothing
		        Private _ApprovedMarkupAmount As Nullable(Of Decimal) = Nothing
		        Private _ApprovedResaleTax As Nullable(Of Decimal) = Nothing
		        Private _ApprovedVendorTax As Nullable(Of Decimal) = Nothing
		        Private _ApprovedTax As Nullable(Of Decimal) = Nothing
		        Private _QuoteMarkup As Nullable(Of Decimal) = Nothing
		        Private _QuoteResaleTax As Nullable(Of Decimal) = Nothing
		        Private _QuoteVendorTax As Nullable(Of Decimal) = Nothing
		        Private _UnbilledMarkup As Nullable(Of Decimal) = Nothing
		        Private _UnbilledResaleTax As Nullable(Of Decimal) = Nothing
		        Private _UnbilledVendorTax As Nullable(Of Decimal) = Nothing
		        Private _UnbilledTax As Nullable(Of Decimal) = Nothing
		        Private _QuoteQuantityHours As Nullable(Of Decimal) = Nothing
		        Private _ActualQuantityHours As Nullable(Of Decimal) = Nothing
		        Private _TempMarkup As Nullable(Of Decimal) = Nothing
		        Private _TempResaleTax As Nullable(Of Decimal) = Nothing
		        Private _TempTotal As Nullable(Of Decimal) = Nothing
		        Private _TempUnbilledMU As Nullable(Of Decimal) = Nothing
		        Private _TempUnbilledTax As Nullable(Of Decimal) = Nothing
		        Private _TempUnbilledNR As Nullable(Of Decimal) = Nothing
		        Private _TempUnbilledTot As Nullable(Of Decimal) = Nothing
		        Private _TempUnbilledPO As Nullable(Of Decimal) = Nothing
		
#End Region

#Region " Properties "

	<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property RollupCount() As Nullable(Of Integer)
		Get
			RollupCount = _RollupCount
		End Get
		Set
			_RollupCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property RollupType() As Nullable(Of Short)
		Get
			RollupType = _RollupType
		End Get
		Set
			_RollupType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property RollupID() As Nullable(Of Integer)
		Get
			RollupID = _RollupID
		End Get
		Set
			_RollupID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property CampaignCode() As String
		Get
			CampaignCode = _CampaignCode
		End Get
		Set
			_CampaignCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Description() As String
		Get
			Description = _Description
		End Get
		Set
			_Description = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionCode() As String
		Get
			FunctionCode = _FunctionCode
		End Get
		Set
			_FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionDescription() As String
		Get
			FunctionDescription = _FunctionDescription
		End Get
		Set
			_FunctionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionDefaultDescription() As String
		Get
			FunctionDefaultDescription = _FunctionDefaultDescription
		End Get
		Set
			_FunctionDefaultDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionType() As String
		Get
			FunctionType = _FunctionType
		End Get
		Set
			_FunctionType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionTypeDescription() As String
		Get
			FunctionTypeDescription = _FunctionTypeDescription
		End Get
		Set
			_FunctionTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionHeadingDescription() As String
		Get
			FunctionHeadingDescription = _FunctionHeadingDescription
		End Get
		Set
			_FunctionHeadingDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuoteAmount() As Nullable(Of Decimal)
		Get
			QuoteAmount = _QuoteAmount
		End Get
		Set
			_QuoteAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Actuals() As Nullable(Of Decimal)
		Get
			Actuals = _Actuals
		End Get
		Set
			_Actuals = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BilledReceived() As Nullable(Of Decimal)
		Get
			BilledReceived = _BilledReceived
		End Get
		Set
			_BilledReceived = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BilledHold() As Nullable(Of Decimal)
		Get
			BilledHold = _BilledHold
		End Get
		Set
			_BilledHold = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property NonBillableFee() As Nullable(Of Decimal)
		Get
			NonBillableFee = _NonBillableFee
		End Get
		Set
			_NonBillableFee = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Unbilled() As Nullable(Of Decimal)
		Get
			Unbilled = _Unbilled
		End Get
		Set
			_Unbilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property OpenPO() As Nullable(Of Decimal)
		Get
			OpenPO = _OpenPO
		End Get
		Set
			_OpenPO = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuantityHours() As Nullable(Of Decimal)
		Get
			QuantityHours = _QuantityHours
		End Get
		Set
			_QuantityHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Quantity() As Nullable(Of Decimal)
		Get
			Quantity = _Quantity
		End Get
		Set
			_Quantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedAmount() As Nullable(Of Decimal)
		Get
			ApprovedAmount = _ApprovedAmount
		End Get
		Set
			_ApprovedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempCutoffApprovedAmount() As Nullable(Of Decimal)
		Get
			TempCutoffApprovedAmount = _TempCutoffApprovedAmount
		End Get
		Set
			_TempCutoffApprovedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuoteNet() As Nullable(Of Decimal)
		Get
			QuoteNet = _QuoteNet
		End Get
		Set
			_QuoteNet = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property UnbilledNet() As Nullable(Of Decimal)
		Get
			UnbilledNet = _UnbilledNet
		End Get
		Set
			_UnbilledNet = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempUnbilledNet() As Nullable(Of Decimal)
		Get
			TempUnbilledNet = _TempUnbilledNet
		End Get
		Set
			_TempUnbilledNet = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedNet() As Nullable(Of Decimal)
		Get
			ApprovedNet = _ApprovedNet
		End Get
		Set
			_ApprovedNet = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempApprovedNet() As Nullable(Of Decimal)
		Get
			TempApprovedNet = _TempApprovedNet
		End Get
		Set
			_TempApprovedNet = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedMarkupAmount() As Nullable(Of Decimal)
		Get
			ApprovedMarkupAmount = _ApprovedMarkupAmount
		End Get
		Set
			_ApprovedMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedResaleTax() As Nullable(Of Decimal)
		Get
			ApprovedResaleTax = _ApprovedResaleTax
		End Get
		Set
			_ApprovedResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedVendorTax() As Nullable(Of Decimal)
		Get
			ApprovedVendorTax = _ApprovedVendorTax
		End Get
		Set
			_ApprovedVendorTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedTax() As Nullable(Of Decimal)
		Get
			ApprovedTax = _ApprovedTax
		End Get
		Set
			_ApprovedTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuoteMarkup() As Nullable(Of Decimal)
		Get
			QuoteMarkup = _QuoteMarkup
		End Get
		Set
			_QuoteMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuoteResaleTax() As Nullable(Of Decimal)
		Get
			QuoteResaleTax = _QuoteResaleTax
		End Get
		Set
			_QuoteResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuoteVendorTax() As Nullable(Of Decimal)
		Get
			QuoteVendorTax = _QuoteVendorTax
		End Get
		Set
			_QuoteVendorTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property UnbilledMarkup() As Nullable(Of Decimal)
		Get
			UnbilledMarkup = _UnbilledMarkup
		End Get
		Set
			_UnbilledMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property UnbilledResaleTax() As Nullable(Of Decimal)
		Get
			UnbilledResaleTax = _UnbilledResaleTax
		End Get
		Set
			_UnbilledResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property UnbilledVendorTax() As Nullable(Of Decimal)
		Get
			UnbilledVendorTax = _UnbilledVendorTax
		End Get
		Set
			_UnbilledVendorTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property UnbilledTax() As Nullable(Of Decimal)
		Get
			UnbilledTax = _UnbilledTax
		End Get
		Set
			_UnbilledTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuoteQuantityHours() As Nullable(Of Decimal)
		Get
			QuoteQuantityHours = _QuoteQuantityHours
		End Get
		Set
			_QuoteQuantityHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ActualQuantityHours() As Nullable(Of Decimal)
		Get
			ActualQuantityHours = _ActualQuantityHours
		End Get
		Set
			_ActualQuantityHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempMarkup() As Nullable(Of Decimal)
		Get
			TempMarkup = _TempMarkup
		End Get
		Set
			_TempMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempResaleTax() As Nullable(Of Decimal)
		Get
			TempResaleTax = _TempResaleTax
		End Get
		Set
			_TempResaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempTotal() As Nullable(Of Decimal)
		Get
			TempTotal = _TempTotal
		End Get
		Set
			_TempTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempUnbilledMU() As Nullable(Of Decimal)
		Get
			TempUnbilledMU = _TempUnbilledMU
		End Get
		Set
			_TempUnbilledMU = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempUnbilledTax() As Nullable(Of Decimal)
		Get
			TempUnbilledTax = _TempUnbilledTax
		End Get
		Set
			_TempUnbilledTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempUnbilledNR() As Nullable(Of Decimal)
		Get
			TempUnbilledNR = _TempUnbilledNR
		End Get
		Set
			_TempUnbilledNR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempUnbilledTot() As Nullable(Of Decimal)
		Get
			TempUnbilledTot = _TempUnbilledTot
		End Get
		Set
			_TempUnbilledTot = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempUnbilledPO() As Nullable(Of Decimal)
		Get
			TempUnbilledPO = _TempUnbilledPO
		End Get
		Set
			_TempUnbilledPO = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
		
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RollupCount.ToString

        End Function

#End Region

	End Class

End Namespace
