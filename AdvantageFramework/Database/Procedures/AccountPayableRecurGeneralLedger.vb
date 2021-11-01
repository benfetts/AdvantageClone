Namespace Database.Procedures.AccountPayableRecurGeneralLedger

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRecurGeneralLedger)

            Load = From AccountPayableRecurGeneralLedger In DbContext.GetQuery(Of Database.Entities.AccountPayableRecurGeneralLedger)
                   Select AccountPayableRecurGeneralLedger

        End Function
        Public Function LoadByRecurID(ByVal DbContext As Database.DbContext, ByVal AccountPayableRecurID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRecurGeneralLedger)

            LoadByRecurID = From AccountPayableRecurGeneralLedger In DbContext.GetQuery(Of Database.Entities.AccountPayableRecurGeneralLedger)
                            Where AccountPayableRecurGeneralLedger.AccountPayableRecurID = AccountPayableRecurID
                            Select AccountPayableRecurGeneralLedger

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableRecurGeneralLedgers.Add(AccountPayableRecurGeneralLedger)

                ErrorText = AccountPayableRecurGeneralLedger.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableRecurGeneralLedger.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Load(DbContext) _
                                                                       Where Entity.AccountPayableRecurID = AccountPayableRecurGeneralLedger.AccountPayableRecurID
                                                                       Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableRecurGeneralLedger.LineNumber = 1
                    End Try

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountPayableRecurGeneralLedger)

                ErrorText = AccountPayableRecurGeneralLedger.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountPayableRecurGeneralLedger)

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
