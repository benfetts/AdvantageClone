Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_CRM_PROSPECTS")>
    Public Class CRMProspectsReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            ClientInactive
            DivisionCode
            DivisionName
            DivisionInactive
            ProductCode
            ProductName
            ProductInactive
            IndustryDescription
            SpecialtyDescription
            Region
            Revenue
            NumberOfEmployees
            CaseStudyDone
            UseAsReference
            Notes
            LeadDate
            SourceDescription
            LastActivityDate
            LastActivityType
            LastActivityEmployee
            LastActivitySubject
            LastActivityBody
            LastContactDate
            Probability
            RatingDescription
            CurrentProvider
            TotalOpportunityValue
            DefaultAECode
            DefaultAEName
            SoldDate
            LostDate
            TurnoverPercent
            Type1Code
            Type1Description
            Type2Code
            Type2Description
            Type3Code
            Type3Description

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <MaxLength(6)>
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("ClientName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
        <Column("ClientInactive")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientInactive As Boolean
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DivisionName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
        <Column("DivisionInactive")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionInactive As Boolean
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("ProductName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName() As String
        <Column("ProductInactive")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductInactive As Boolean
        <MaxLength(100)>
        <Column("IndustryDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndustryDescription() As String
        <MaxLength(100)>
        <Column("SpecialtyDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SpecialtyDescription() As String
        <MaxLength(40)>
        <Column("Region", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Region() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("Revenue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Revenue() As Decimal
        <Column("NumberOfEmployees")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NumberOfEmployees() As Nullable(Of Integer)
        <Column("CaseStudyDone")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CaseStudyDone() As Nullable(Of Boolean)
        <Column("UseAsReference")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseAsReference() As Nullable(Of Boolean)
		<Column("Notes", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Notes() As String
		<Column("LeadDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LeadDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("SourceDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SourceDescription() As String
		<Column("LastActivityDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastActivityDate() As Nullable(Of Date)
		<MaxLength(18)>
		<Column("LastActivityType", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastActivityType() As String
		<MaxLength(64)>
		<Column("LastActivityEmployee", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastActivityEmployee() As String
		<MaxLength(254)>
		<Column("LastActivitySubject", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastActivitySubject() As String
		<Column("LastActivityBody")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastActivityBody() As String
        <Column("LastContactDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastContactDate() As Nullable(Of Date)
        <Column("Probability")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Probability() As Nullable(Of Byte)
        <MaxLength(100)>
        <Column("RatingDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RatingDescription() As String
        <MaxLength(100)>
        <Column("CurrentProvider", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentProvider() As String
        <Column("TotalOpportunityValue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalOpportunityValue() As Nullable(Of Decimal)
        <MaxLength(6)>
        <Column("DefaultAECode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAECode() As String
        <MaxLength(64)>
        <Column("DefaultAEName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAEName() As String
        <Column("SoldDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SoldDate() As Nullable(Of Date)
        <Column("LostDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LostDate() As Nullable(Of Date)

        <Column("TurnoverPercent")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TurnoverPercent() As Nullable(Of Decimal)

        <Column("Type1Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type1Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("Type1Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type1Description() As String

        <Column("Type2Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type2Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("Type2Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type2Description() As String

        <Column("Type3Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type3Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("Type3Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type3Description() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
