Namespace Database.Entities

	<Table("JOB_TYPE")>
	Public Class JobType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			IsInactive
			SalesClassCode
			SalesClass
			VendorPricings
			CreativeBriefTemplates

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(10)>
		<Column("JT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Code() As String
		<Required>
		<MaxLength(30)>
		<Column("JT_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Description() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Sales Class", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String

        Public Overridable Property SalesClass As Database.Entities.SalesClass
        Public Overridable Property VendorPricings As ICollection(Of Database.Entities.VendorPricing)
        Public Overridable Property CreativeBriefTemplates As ICollection(Of Database.Entities.CreativeBriefTemplate)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.JobType.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        If AdvantageFramework.Database.Procedures.JobType.LoadByJobTypeCode(DirectCast(_DbContext, AdvantageFramework.Database.DbContext), Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "Job Type Code already exists in the system"

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.JobType.Properties.SalesClassCode.ToString

                    If AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DirectCast(_DbContext, AdvantageFramework.Database.DbContext), Value) Is Nothing Then

                        IsValid = False
                        ErrorText = "Sales Class does not exists in the system"

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
