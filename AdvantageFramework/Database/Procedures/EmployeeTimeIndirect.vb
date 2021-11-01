Namespace Database.Procedures.EmployeeTimeIndirect

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

        Public Function LoadByEmployeeTimeIDAndEmployeeTimeIndirectID(ByVal DbContext As Database.DbContext,
                                                                      ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Short) As Database.Entities.EmployeeTimeIndirect

            LoadByEmployeeTimeIDAndEmployeeTimeIndirectID = (From EmployeeTimeIndirect In DbContext.GetQuery(Of Database.Entities.EmployeeTimeIndirect).Include("EmployeeTime")
                                                             Where EmployeeTimeIndirect.ID = EmployeeTimeID And EmployeeTimeIndirect.EmployeeTimeDetailID = EmployeeTimeDetailID
                                                             Select EmployeeTimeIndirect).SingleOrDefault

        End Function

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeIndirectID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeIndirect)

            LoadByID = From EmployeeTimeIndirect In DbContext.GetQuery(Of Database.Entities.EmployeeTimeIndirect)
                       Where EmployeeTimeIndirect.ID = EmployeeTimeIndirectID
                       Select EmployeeTimeIndirect

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeIndirect)

            Load = From EmployeeTimeIndirect In DbContext.GetQuery(Of Database.Entities.EmployeeTimeIndirect)
                   Select EmployeeTimeIndirect

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeIDs As System.Collections.Generic.List(Of Integer), _
                               ByVal UpdateStandardAmount As Boolean, ByVal StandardCostRate As Decimal, ByVal UpdateAlternateAmount As Boolean, ByVal AlternateCostRate As Decimal, _
                               ByVal UpdateDepartmentTeam As Boolean, ByVal DepartmentTeamCode As String) As Boolean

            'objects
            Dim Updated As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim UpdateStatements As System.Collections.Generic.List(Of String) = Nothing
            Dim UpdateStatement As String = Nothing

            Try

                UpdateStatements = New System.Collections.Generic.List(Of String)

                If UpdateStandardAmount Then

                    UpdateStatements.Add("[TOTAL_COST] = [EMP_HOURS] * {0}")
                    UpdateStatements.Add("[COST_RATE] = {0}")

                End If

                If UpdateAlternateAmount Then

                    UpdateStatements.Add("[ALT_COST_AMT] = [EMP_HOURS] * {1}")
                    UpdateStatements.Add("[ALT_COST_RATE] = {1}")

                End If

                If UpdateDepartmentTeam Then

                    If DepartmentTeamCode IsNot Nothing Then

                        DepartmentTeamCode = DepartmentTeamCode.Trim

                    End If

                    If String.IsNullOrEmpty(DepartmentTeamCode) Then

                        DepartmentTeamCode = "NULL"

                        UpdateStatements.Add("[DP_TM_CODE] = {2}")

                    Else

                        UpdateStatements.Add("[DP_TM_CODE] = '{2}'")

                    End If

                End If

                UpdateStatement = Join(UpdateStatements.ToArray, ", ")

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMP_TIME_NP SET " & UpdateStatement & " WHERE [ET_ID] IN ({3})", _
                                                                StandardCostRate.ToString(System.Globalization.CultureInfo.InvariantCulture), AlternateCostRate.ToString(System.Globalization.CultureInfo.InvariantCulture), DepartmentTeamCode, _
                                                                Join(EmployeeTimeIDs.Select(Function(ID) CStr(ID)).ToArray, ", ")))

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim EmployeeTimeIndirect As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing

            Try

                EmployeeTimeIndirect = (From Entity In Load(DbContext) _
                                        Where Entity.ID = EmployeeTimeID AndAlso _
                                              Entity.EmployeeTimeDetailID = EmployeeTimeDetailID _
                                        Select Entity).SingleOrDefault

                AdvantageFramework.Database.Procedures.EmployeeTimeComment.Delete(DbContext, EmployeeTimeID, EmployeeTimeDetailID, "N")

                DbContext.DeleteEntityObject(EmployeeTimeIndirect)

                DbContext.SaveChanges()

                Deleted = True

                If (From Entity In Load(DbContext) _
                    Where Entity.ID = EmployeeTimeID _
                    Select Entity).Any = False Then

                    If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeID(DbContext, EmployeeTimeID) _
                        Select Entity).Any = False Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[EMP_TIME] WHERE [ET_ID] = {0}", EmployeeTimeID))

                        Catch ex As Exception

                        End Try

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
