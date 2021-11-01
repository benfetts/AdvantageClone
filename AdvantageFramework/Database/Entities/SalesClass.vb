Namespace Database.Entities

	<Table("SALES_CLASS")>
	Public Class SalesClass
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			SalesClassTypeCode
			IsInactive
			BillingRateDetails
			Jobs
			JobTypes
			InternetOrders
			MagazineOrders
			NewspaperOrders
			OutOfHomeOrders
			RadioOrders
			TVOrders
			SalesClassFormats
			OfficeSalesClassAccounts
			MediaPlanDetails
			RadioOrderLegacies
			TVOrderLegacies
			MediaATBRevisions
			BudgetDetails
			DigitalResults

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(30)>
		<Column("SC_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(1)>
		<Column("SC_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesClassTypeCode() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property Jobs As ICollection(Of Database.Entities.Job)
        Public Overridable Property JobTypes As ICollection(Of Database.Entities.JobType)
        Public Overridable Property InternetOrders As ICollection(Of Database.Entities.InternetOrder)
        Public Overridable Property MagazineOrders As ICollection(Of Database.Entities.MagazineOrder)
        Public Overridable Property NewspaperOrders As ICollection(Of Database.Entities.NewspaperOrder)
        Public Overridable Property OutOfHomeOrders As ICollection(Of Database.Entities.OutOfHomeOrder)
        Public Overridable Property RadioOrders As ICollection(Of Database.Entities.RadioOrder)
        Public Overridable Property TVOrders As ICollection(Of Database.Entities.TVOrder)
        Public Overridable Property SalesClassFormats As ICollection(Of Database.Entities.SalesClassFormat)
        Public Overridable Property OfficeSalesClassAccounts As ICollection(Of Database.Entities.OfficeSalesClassAccount)
        Public Overridable Property MediaPlanDetails As ICollection(Of Database.Entities.MediaPlanDetail)
        Public Overridable Property RadioOrderLegacies As ICollection(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property TVOrderLegacies As ICollection(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property MediaATBRevisions As ICollection(Of Database.Entities.MediaATBRevision)
        Public Overridable Property BudgetDetails As ICollection(Of Database.Entities.BudgetDetail)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.SalesClass.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).SalesClasses
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
