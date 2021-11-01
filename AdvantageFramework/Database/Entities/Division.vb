Namespace Database.Entities

	<Table("DIVISION")>
	Public Class Division
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ClientCode
			Code
			Name
			Address
			Address2
			City
			County
			State
			Country
			Zip
			IsActive
			BillingAddress
			BillingAddress2
			BillingCity
			BillingCounty
			BillingState
			BillingZip
			BillingCountry
			AttentionLine
			SortName
			BatchName
			Client
			Products
			Jobs
			BillingRateDetails
			EmployeeTimeForecastOfficeDetailJobComponents
			Campaigns
			DivisionSortKeys
			StandardComments
			MediaATBs
			DigitalResults

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.ClientCode & "|" & Me.Code
            End Get
        End Property
        <Key>
		<Required>
		<MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DIV_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("DIV_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("DIV_SADDRESS1", TypeName:="varchar")>
		Public Property Address() As String
		<MaxLength(40)>
		<Column("DIV_SADDRESS2", TypeName:="varchar")>
		Public Property Address2() As String
		<MaxLength(30)>
		<Column("DIV_SCITY", TypeName:="varchar")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("DIV_SCOUNTY", TypeName:="varchar")>
		Public Property County() As String
		<MaxLength(10)>
		<Column("DIV_SSTATE", TypeName:="varchar")>
		Public Property State() As String
		<MaxLength(20)>
		<Column("DIV_SCOUNTRY", TypeName:="varchar")>
		Public Property Country() As String
		<MaxLength(10)>
		<Column("DIV_SZIP", TypeName:="varchar")>
		Public Property Zip() As String
		<Column("ACTIVE_FLAG")>
		Public Property IsActive() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("DIV_BADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingAddress() As String
		<MaxLength(40)>
		<Column("DIV_BADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingAddress2() As String
		<MaxLength(30)>
		<Column("DIV_BCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCity() As String
		<MaxLength(20)>
		<Column("DIV_BCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCounty() As String
		<MaxLength(10)>
		<Column("DIV_BSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingState() As String
		<MaxLength(10)>
		<Column("DIV_BZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingZip() As String
		<MaxLength(20)>
		<Column("DIV_BCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCountry() As String
		<MaxLength(40)>
		<Column("DIV_ATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AttentionLine() As String
		<MaxLength(20)>
		<Column("DIV_ALPHA_SORT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortName() As String
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchName() As String

        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property Products As ICollection(Of Database.Entities.Product)
        Public Overridable Property Jobs As ICollection(Of Database.Entities.Job)
        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property Campaigns As ICollection(Of Database.Entities.Campaign)
        Public Overridable Property DivisionSortKeys As ICollection(Of Database.Entities.DivisionSortKey)
        Public Overridable Property StandardComments As ICollection(Of Database.Entities.StandardComment)
        Public Overridable Property MediaATBs As ICollection(Of Database.Entities.MediaATB)
		Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
		Public Overridable Property MediaPlans As ICollection(Of Database.Entities.MediaPlan)

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Division.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Divisions
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                     Entity.ClientCode = Me.ClientCode
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique division code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function


#End Region

	End Class

End Namespace
