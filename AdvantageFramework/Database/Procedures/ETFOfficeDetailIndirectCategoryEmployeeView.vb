Namespace Database.Procedures.ETFOfficeDetailIndirectCategoryEmployeeView

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

        Public Function LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)

            LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID = From ETFOfficeDetailIndirectCategoryEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)
                                                                                Where ETFOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                      ETFOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                                                Select ETFOfficeDetailIndirectCategoryEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)

            Load = From ETFOfficeDetailIndirectCategoryEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)
                   Select ETFOfficeDetailIndirectCategoryEmployee

        End Function

#End Region

    End Module

End Namespace
