Namespace Database.Procedures.EmployeeStandardHoursDetail

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

        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeStandardHoursDetail)

            LoadByUserCode = From EmployeeStandardHoursDetail In DbContext.GetQuery(Of Database.Entities.EmployeeStandardHoursDetail)
                             Where EmployeeStandardHoursDetail.UserCode = UserCode
                             Select EmployeeStandardHoursDetail

        End Function
        Public Function LoadByUserCodeAndEmployeeCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeStandardHoursDetail)

            LoadByUserCodeAndEmployeeCode = From EmployeeStandardHoursDetail In DbContext.GetQuery(Of Database.Entities.EmployeeStandardHoursDetail)
                                            Where EmployeeStandardHoursDetail.UserCode = UserCode AndAlso
                                                  EmployeeStandardHoursDetail.EmployeeCode = EmployeeCode
                                            Select EmployeeStandardHoursDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeStandardHoursDetail)

            Load = From EmployeeStandardHoursDetail In DbContext.GetQuery(Of Database.Entities.EmployeeStandardHoursDetail)
                   Select EmployeeStandardHoursDetail

        End Function

#End Region

    End Module

End Namespace
