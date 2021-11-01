Namespace Database.Procedures.EmployeeTimeTotalsByOfficeClientView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.EmployeeTimeTotalsByOfficeClient)

            Load = From EmployeeTimeTotalsByOfficeClient In DbContext.GetQuery(Of Database.Views.EmployeeTimeTotalsByOfficeClient)
                   Select EmployeeTimeTotalsByOfficeClient

        End Function

#End Region

    End Module

End Namespace
