Namespace Database.Procedures.AccountGroup

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

        Public Function LoadByAccountGroupCode(ByVal DbContext As Database.DbContext, ByVal AccountGroupCode As String) As Database.Entities.AccountGroup

            Try

                LoadByAccountGroupCode = (From AccountGroup In DbContext.GetQuery(Of Database.Entities.AccountGroup)
                                          Where AccountGroup.Code = AccountGroupCode
                                          Select AccountGroup).SingleOrDefault

            Catch ex As Exception
                LoadByAccountGroupCode = Nothing
            End Try

        End Function
        Public Function LoadByAccountGroupType(ByVal DbContext As Database.DbContext, ByVal AccountGroupType As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountGroup)

            LoadByAccountGroupType = From AccountGroup In DbContext.GetQuery(Of Database.Entities.AccountGroup)
                                     Where AccountGroup.Type = AccountGroupType
                                     Select AccountGroup

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountGroup)

            Load = From AccountGroup In DbContext.GetQuery(Of Database.Entities.AccountGroup)
                   Select AccountGroup

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountGroup As AdvantageFramework.Database.Entities.AccountGroup) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountGroups.Add(AccountGroup)

                ErrorText = AccountGroup.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountGroup As AdvantageFramework.Database.Entities.AccountGroup) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountGroup)

                ErrorText = AccountGroup.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountGroup As AdvantageFramework.Database.Entities.AccountGroup) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                IsValid = Not (From Item In AdvantageFramework.Database.Procedures.GLReportTemplateRow.Load(DbContext)
                               Where Item.AccountGroupCode = AccountGroup.Code
                               Select Item).Any

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ACCOUNT_GROUP_DTL WHERE GROUP_CODE = '{0}'", AccountGroup.Code))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ACCOUNT_GROUP WHERE GROUP_CODE = '{0}'", AccountGroup.Code))

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                Else

                    'AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

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
