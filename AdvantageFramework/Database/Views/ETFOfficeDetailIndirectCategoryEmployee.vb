Namespace Database.Views

    <Table("V_ETF_OFFDTLCAT_EMP")>
    Public Class ETFOfficeDetailIndirectCategoryEmployee
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeForecastID
            EmployeeTimeForecastOfficeDetailID
            EmployeeTimeForecastOfficeDetailIndirectCategoryID
            EmployeeTimeForecastOfficeDetailIndirectCategoryEmployeeID
            EmployeeTimeForecastOfficeDetailEmployeeID
            EmployeeCode
            EmployeeName
            EmployeeOfficeCode
            EmployeeOfficeDescription
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
        <Column("EmployeeTimeForecastOfficeDetailIndirectCategoryEmployeeID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployeeID() As Integer
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailEmployeeID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailEmployeeID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("EmployeeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
        <MaxLength(64)>
        <Column("EmployeeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeName() As String
        <MaxLength(4)>
        <Column("EmployeeOfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeOfficeCode() As String
        <MaxLength(30)>
        <Column("EmployeeOfficeDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeOfficeDescription() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("Hours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hours() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 3)>
        <Column("BillRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillRate() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 3)>
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
