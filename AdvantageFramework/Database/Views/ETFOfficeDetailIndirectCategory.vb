Namespace Database.Views

    <Table("V_ETF_OFFDTLCAT")>
    Public Class ETFOfficeDetailIndirectCategory
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeForecastID
            EmployeeTimeForecastOfficeDetailID
            EmployeeTimeForecastOfficeDetailIndirectCategoryID
            IndirectCategoryCode
            IndirectCategory

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
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("EmployeeTimeForecastOfficeDetailIndirectCategoryID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeForecastOfficeDetailIndirectCategoryID() As Integer
        <Required>
        <MaxLength(10)>
        <Column("IndirectCategoryCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndirectCategoryCode() As String
        <MaxLength(40)>
        <Column("IndirectCategory", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndirectCategory() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeForecastID

        End Function

#End Region

    End Class

End Namespace
