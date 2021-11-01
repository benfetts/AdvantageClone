Namespace Database.Procedures.AccountPayableRecurLog

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRecurLog)

            Load = From AccountPayableRecurLog In DbContext.GetQuery(Of Database.Entities.AccountPayableRecurLog)
                   Select AccountPayableRecurLog

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AccountPayableRecurLog As AdvantageFramework.Database.Entities.AccountPayableRecurLog) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AccountPayableRecurLog.DataContext = DataContext

                AccountPayableRecurLog.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AccountPayableRecurLogs.InsertOnSubmit(AccountPayableRecurLog)

                ErrorText = AccountPayableRecurLog.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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

#End Region

    End Module

End Namespace
