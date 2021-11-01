Namespace Database.Views

    <Table("V_ETF_OFFDTLCAT_AE")>
    Public Class ETFOfficeDetailIndirectCategoryAlternateEmployee
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeForecastID
            EmployeeTimeForecastOfficeDetailID
            EmployeeTimeForecastOfficeDetailIndirectCategoryID
            EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployeeID
            EmployeeTimeForecastOfficeDetailAlternateEmployeeID
            AlternateEmployeeDescription
            AlternateEmployeeTitleID
            AlternateEmployeeTitle
            AlternateEmployeeOfficeCode
            AlternateEmployeeOfficeDescription
            Hours
            BillRate
            CostRate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <Column("EmployeeTimeForecastID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastID() As Integer
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailID() As Integer
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailIndirectCategoryID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailIndirectCategoryID() As Integer
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployeeID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployeeID() As Integer
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailAlternateEmployeeID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailAlternateEmployeeID() As Integer
        <Required>
        <MaxLength(50)>
        <Column("AlternateEmployeeDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateEmployeeDescription() As String
        <Required>
        <Column("AlternateEmployeeTitleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateEmployeeTitleID() As Integer
        <Required>
        <MaxLength(50)>
        <Column("AlternateEmployeeTitle", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateEmployeeTitle() As String
        <Required>
        <MaxLength(4)>
        <Column("AlternateEmployeeOfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateEmployeeOfficeCode() As String
        <MaxLength(30)>
        <Column("AlternateEmployeeOfficeDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateEmployeeOfficeDescription() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("Hours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hours() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("BillRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillRate() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("CostRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostRate() As Decimal


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeForecastID

        End Function

#End Region

    End Class

End Namespace
