Namespace Database.Entities

	<Table("PARTNER_ALLOC_DTL")>
	Public Class PartnerAllocationDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OrderNumber
			PartnerCode
			PercentAllocation

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ORDER_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property OrderNumber() As Integer
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PARTNER_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Partner", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PartnerCode)>
		Public Property PartnerCode() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
		<Column("PCT_ALLOC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PercentAllocation() As Decimal


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.PartnerAllocationDetail.Properties.PartnerCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).PartnerAllocationDetails
                            Where Entity.PartnerCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.OrderNumber = Me.OrderNumber
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique partner code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
