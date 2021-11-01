Namespace Database.Procedures.Employee

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

        Public Function Load(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext) As IQueryable(Of AdvantageFramework.GoogleServices.Database.Entities.Employee)

            Load = From Employee In DataContext.Employees _
                   Select Employee

        End Function
        Public Function LoadByEmployeeCode(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeCode As String) As AdvantageFramework.GoogleServices.Database.Entities.Employee

            Try

                LoadByEmployeeCode = (From Employee In DataContext.Employees _
                                      Where Employee.EmployeeCode = EmployeeCode _
                                      Select Employee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCode = Nothing
            End Try

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DataContext.SubmitChanges()

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
