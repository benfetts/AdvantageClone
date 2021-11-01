Namespace Database.Views

    <Table("V_ETF_OFFDTLJC_EMP")>
    Public Class ETFOfficeDetailJobComponentEmployee
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeForecastID
            EmployeeTimeForecastOfficeDetailID
            EmployeeTimeForecastOfficeDetailJobComponentID
            EmployeeTimeForecastOfficeDetailJobComponentEmployeeID
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
        <Column("EmployeeTimeForecastOfficeDetailJobComponentID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailJobComponentID() As Integer
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailJobComponentEmployeeID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailJobComponentEmployeeID() As Integer
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
