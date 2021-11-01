Namespace Database.Procedures.OverheadAccount

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OverheadAccount)

            Load = From OverheadAccount In DbContext.GetQuery(Of Database.Entities.OverheadAccount)
                   Select OverheadAccount

        End Function
        Public Function LoadDistinctOverheadAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OverheadAccount)

            Try

                LoadDistinctOverheadAccounts = From OverheadAccount In DbContext.GetQuery(Of Database.Entities.OverheadAccount)
                                               Group OverheadAccount By Key = OverheadAccount.Code Into Group
                                               Select Group.FirstOrDefault

            Catch ex As Exception
                LoadDistinctOverheadAccounts = Nothing
            End Try

        End Function
        Public Function LoadAllByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OverheadAccount)

            LoadAllByCode = (From OverheadAccount In DbContext.GetQuery(Of Database.Entities.OverheadAccount)
                             Where OverheadAccount.Code = Code
                             Select OverheadAccount)

        End Function
        Public Function LoadSingleByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As AdvantageFramework.Database.Entities.OverheadAccount

            LoadSingleByCode = (From OverheadAccount In DbContext.GetQuery(Of Database.Entities.OverheadAccount)
                                Where OverheadAccount.Code = Code
                                Select OverheadAccount).FirstOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OverheadAccounts.Add(OverheadAccount)

                ErrorText = OverheadAccount.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OverheadAccount)

                ErrorText = OverheadAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.OFF_ASSIGN WHERE OH_SET_ID = '{0}'", OverheadAccount.Code)).FirstOrDefault > 0 Then

                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(OverheadAccount)

                    DbContext.SaveChanges()

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteAllByCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OverheadAccountCode As String) As Boolean

            Dim Deleted As Boolean = False

            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.OFF_ASSIGN WHERE OH_SET_ID = '{0}'", OverheadAccountCode)).FirstOrDefault = 0 Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE from dbo.OH_ACCOUNTS where OH_CODE = '{0}'", OverheadAccountCode))

                    Deleted = True

                Catch ex As Exception
                    Throw ex
                End Try

            End If

            DeleteAllByCode = Deleted

        End Function

#End Region

    End Module

End Namespace
