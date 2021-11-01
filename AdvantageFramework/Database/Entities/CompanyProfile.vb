Namespace Database.Entities

	<Table("COMPANY_PROFILE")>
	Public Class CompanyProfile
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientCode
			DivisionCode
			ProductCode
			IndustryID
			SpecialtyID
			RegionCode
			Revenue
			NumberOfEmployees
			CaseStudyDone
			UseAsReference
			Notes
			CreatedByUserCode
			CreateDate
			ModifiedByUserCode
            ModifiedDate
            TurnoverPercent
            ClientType1ID
            ClientType2ID
            ClientType3ID
            CompanyProfileAffiliations
			Industry
			Region
            Specialty
            ClientType1
            ClientType2
            ClientType3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("COMPANY_PROFILE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<Column("INDUSTRY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IndustryID() As Nullable(Of Integer)
		<Column("SPECIALTY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SpecialtyID() As Nullable(Of Integer)
		<MaxLength(20)>
		<Column("REGION_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RegionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("REVENUE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Revenue() As Nullable(Of Decimal)
		<Column("NUM_EMPLOYEES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NumberOfEmployees() As Nullable(Of Integer)
		<Required>
		<Column("CASE_STUDY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CaseStudyDone() As Boolean
		<Required>
		<Column("REFERENCE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseAsReference() As Boolean
		<Column("NOTES", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Notes() As String
		<Required>
		<MaxLength(100)>
		<Column("CREATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDate() As Date
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(5, 2)>
        <Column("TURNOVER_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", UseMinValue:=True, MinValue:=0, UseMaxValue:=True, MaxValue:=999.99)>
        Public Property TurnoverPercent() As Nullable(Of Decimal)
        <Column("CLIENT_TYPE1_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientType1ID() As Nullable(Of Integer)
        <Column("CLIENT_TYPE2_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientType2ID() As Nullable(Of Integer)
        <Column("CLIENT_TYPE3_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientType3ID() As Nullable(Of Integer)

        Public Overridable Property CompanyProfileAffiliations As ICollection(Of Database.Entities.CompanyProfileAffiliation)
        Public Overridable Property Industry As Database.Entities.Industry
        Public Overridable Property Region As Database.Entities.PrintSpecRegion
        Public Overridable Property Specialty As Database.Entities.Specialty
        Public Overridable Property ClientType1 As Database.Entities.ClientType1
        Public Overridable Property ClientType2 As Database.Entities.ClientType2
        Public Overridable Property ClientType3 As Database.Entities.ClientType3

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.CompanyProfile

            Dim EntityCopy As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.CompanyProfile

            With EntityCopy
                .ClientCode = Me.ClientCode
                .DivisionCode = Me.DivisionCode
                .ProductCode = Me.ProductCode
                .IndustryID = Me.IndustryID
                .SpecialtyID = Me.SpecialtyID
                .RegionCode = Me.RegionCode
                .Revenue = Me.Revenue
                .NumberOfEmployees = Me.NumberOfEmployees
                .CaseStudyDone = Me.CaseStudyDone
                .UseAsReference = Me.UseAsReference
                .Notes = Me.Notes
                .CreatedByUserCode = Me.CreatedByUserCode
                .CreateDate = Me.CreateDate
                .ModifiedByUserCode = Me.ModifiedByUserCode
                .ModifiedDate = Me.ModifiedDate
                .TurnoverPercent = Me.TurnoverPercent
                .ClientType1ID = Me.ClientType1ID
                .ClientType2ID = Me.ClientType2ID
                .ClientType3ID = Me.ClientType3ID
            End With

            Copy = EntityCopy

        End Function

#End Region

	End Class

End Namespace
