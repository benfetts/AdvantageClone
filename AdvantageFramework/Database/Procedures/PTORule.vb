Namespace Database.Procedures.PTORule

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PTORule)

            LoadAllActive = From PTORule In DbContext.GetQuery(Of Database.Entities.PTORule)
                            Where PTORule.IsInactive = False
                            Select PTORule

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PTORule)

            Load = From PTORule In DbContext.GetQuery(Of Database.Entities.PTORule)
                   Select PTORule

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal RuleID As Integer) As AdvantageFramework.Database.Entities.PTORule

            LoadByID = (From PTORule In DbContext.GetQuery(Of Database.Entities.PTORule)
                        Where PTORule.ID = RuleID
                        Select PTORule).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PTORule As AdvantageFramework.Database.Entities.PTORule) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PTORules.Add(PTORule)

                ErrorText = PTORule.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PTORule As AdvantageFramework.Database.Entities.PTORule) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try


                        Try
                            ' DELETE detail rows
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.TIME_RULE_DTL WHERE TIME_RULE_ID = '{0}'", PTORule.ID))

                        Catch ex As Exception
                            IsValid = False
                        End Try

                        If IsValid Then

                            DbContext.DeleteEntityObject(PTORule)

                            DbContext.SaveChanges()

                            Deleted = True

                        End If

                    Catch ex As Exception
                        Deleted = False
                    End Try
                    
                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PTORule As AdvantageFramework.Database.Entities.PTORule) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PTORule)

                ErrorText = PTORule.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
