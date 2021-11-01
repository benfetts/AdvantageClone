Namespace Database.Procedures.ETFOfficeDetailJobComponentView

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

        Public Function LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailJobComponent)

            LoadByEmployeeTimeForecastIDAndEmployeeTimeForecastOfficeDetailID = From ETFOfficeDetailJobComponent In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailJobComponent)
                                                                                Where ETFOfficeDetailJobComponent.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                      ETFOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                                                Select ETFOfficeDetailJobComponent

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ETFOfficeDetailJobComponent)

            Load = From ETFOfficeDetailJobComponent In DbContext.GetQuery(Of Database.Views.ETFOfficeDetailJobComponent)
                   Select ETFOfficeDetailJobComponent

        End Function

#End Region

    End Module

End Namespace
