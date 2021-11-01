Namespace Database.Procedures.GeneralLedgerDepartmentTeamCrossReference

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

        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As Database.Entities.GeneralLedgerDepartmentTeamCrossReference

            Try

                LoadByCode = (From GeneralLedgerDepartmentTeamCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
                              Where GeneralLedgerDepartmentTeamCrossReference.Code = Code
                              Select GeneralLedgerDepartmentTeamCrossReference).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function LoadByDepartmentTeamCode(ByVal DbContext As Database.DbContext, ByVal DepartmentTeamCode As String) As Database.Entities.GeneralLedgerDepartmentTeamCrossReference

            Try

                LoadByDepartmentTeamCode = (From GeneralLedgerDepartmentTeamCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
                                            Where GeneralLedgerDepartmentTeamCrossReference.DepartmentTeamCode = DepartmentTeamCode
                                            Select GeneralLedgerDepartmentTeamCrossReference).SingleOrDefault

            Catch ex As Exception
                LoadByDepartmentTeamCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)

            Load = From GeneralLedgerDepartmentTeamCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
                   Select GeneralLedgerDepartmentTeamCrossReference

        End Function
        Public Function LoadOrderByDepartment(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)

            LoadOrderByDepartment = From GeneralLedgerDepartmentTeamCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
                                    Order By GeneralLedgerDepartmentTeamCrossReference.DepartmentTeamCode
                                    Select GeneralLedgerDepartmentTeamCrossReference

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerDepartmentTeamCrossReferences.Add(GeneralLedgerDepartmentTeamCrossReference)

                ErrorText = GeneralLedgerDepartmentTeamCrossReference.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralLedgerDepartmentTeamCrossReference)

                ErrorText = GeneralLedgerDepartmentTeamCrossReference.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GeneralLedgerDepartmentTeamCrossReference)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

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
