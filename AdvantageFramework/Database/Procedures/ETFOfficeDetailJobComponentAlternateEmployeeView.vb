Namespace Database.Procedures.ETFOfficeDetailJobComponentAlternateEmployeeView

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

        Public Function LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)

            LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID = From ETFOfficeDetailJobComponentAlternateEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)
                                                                                Where ETFOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                      ETFOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                                                Select ETFOfficeDetailJobComponentAlternateEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)

            Load = From ETFOfficeDetailJobComponentAlternateEmployee In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)
                   Select ETFOfficeDetailJobComponentAlternateEmployee

        End Function

#End Region

    End Module

End Namespace
