Namespace Database.Procedures.ETFOfficeDetailIndirectCategoryAlternateEmployeeView

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)

            LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID = From ETFOfficeDetailIndirectCategoryAlternateEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)
                                                                                Where ETFOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                      ETFOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                                                Select ETFOfficeDetailIndirectCategoryAlternateEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)

            Load = From ETFOfficeDetailIndirectCategoryAlternateEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)
                   Select ETFOfficeDetailIndirectCategoryAlternateEmployee

        End Function

#End Region

    End Module

End Namespace
