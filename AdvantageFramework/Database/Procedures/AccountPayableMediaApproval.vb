Namespace Database.Procedures.AccountPayableMediaApproval

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMediaApproval)

            Load = From AccountPayableMediaApproval In DbContext.GetQuery(Of Database.Entities.AccountPayableMediaApproval)
                   Select AccountPayableMediaApproval

        End Function
        Public Function LoadByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMediaApproval)

            LoadByAccountPayableID = From AccountPayableMediaApproval In DbContext.GetQuery(Of Database.Entities.AccountPayableMediaApproval)
                                     Where AccountPayableMediaApproval.AccountPayableID = AccountPayableID
                                     Select AccountPayableMediaApproval

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableMediaApprovals.Add(AccountPayableMediaApproval)

                ErrorText = AccountPayableMediaApproval.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableMediaApproval.Revision = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.Load(DbContext) _
                                                                Where Entity.AccountPayableID = AccountPayableMediaApproval.AccountPayableID AndAlso _
                                                                      Entity.OrderNumber = AccountPayableMediaApproval.OrderNumber AndAlso _
                                                                      Entity.LineNumber = AccountPayableMediaApproval.LineNumber AndAlso _
                                                                      Entity.Source = AccountPayableMediaApproval.Source
                                                                Select Entity.Revision).Max + 1

                    Catch ex As Exception
                        AccountPayableMediaApproval.Revision = 1
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

#End Region

    End Module

End Namespace
