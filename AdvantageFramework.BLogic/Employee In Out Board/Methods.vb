Namespace EmployeeInOutBoard

    <HideModuleName()>
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
        Public Function UpdateEmployeeInOutBoard(DbContext As AdvantageFramework.Database.DbContext) As Boolean
            Try

                UpdateEmployeeInOutBoard = DbContext.Database.ExecuteSqlCommand("usp_wv_dto_inout_signout_all")

            Catch ex As Exception
                UpdateEmployeeInOutBoard = False
            End Try

        End Function

#End Region

    End Module

End Namespace
