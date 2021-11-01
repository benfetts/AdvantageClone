Namespace Database.Procedures.ETFOfficeDetailJobComponentEmployeeView

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

        Public Function LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailJobComponentEmployee)

            LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID = From ETFOfficeDetailJobComponentEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailJobComponentEmployee)
                                                                                Where ETFOfficeDetailJobComponentEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                      ETFOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                                                Select ETFOfficeDetailJobComponentEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailJobComponentEmployee)

            Load = From ETFOfficeDetailJobComponentEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailJobComponentEmployee)
                   Select ETFOfficeDetailJobComponentEmployee

        End Function

#End Region

    End Module

End Namespace
