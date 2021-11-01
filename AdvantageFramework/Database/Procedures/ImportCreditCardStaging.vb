Namespace Database.Procedures.ImportCreditCardStaging

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

        Public Function LoadByBatchName(ByVal DbContext As Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportCreditCardStaging)

            LoadByBatchName = From ImportCreditCardStaging In DbContext.GetQuery(Of Database.Entities.ImportCreditCardStaging)
                              Where ImportCreditCardStaging.BatchName = BatchName
                              Select ImportCreditCardStaging

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportCreditCardStaging)

            Load = From ImportCreditCardStaging In DbContext.GetQuery(Of Database.Entities.ImportCreditCardStaging)
                   Select ImportCreditCardStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportCreditCardStagings.Add(ImportCreditCardStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportCreditCardStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportCreditCardStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging).Where(Function(ImpCCStaging) ImpCCStaging.BatchName = BatchName).ToList

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

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
