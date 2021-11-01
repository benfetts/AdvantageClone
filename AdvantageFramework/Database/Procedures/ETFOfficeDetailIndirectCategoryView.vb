Namespace Database.Procedures.ETFOfficeDetailIndirectCategoryView

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

        Public Function LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailIndirectCategory)

            LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID = From ETFOfficeDetailIndirectCategory In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailIndirectCategory)
                                                                                Where ETFOfficeDetailIndirectCategory.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                      ETFOfficeDetailIndirectCategory.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                                                Select ETFOfficeDetailIndirectCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailIndirectCategory)

            Load = From ETFOfficeDetailIndirectCategory In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailIndirectCategory)
                   Select ETFOfficeDetailIndirectCategory

        End Function

#End Region

    End Module

End Namespace
