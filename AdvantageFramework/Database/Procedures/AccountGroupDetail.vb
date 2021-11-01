Namespace Database.Procedures.AccountGroupDetail

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

        Public Function LoadByAccountGroupCode(ByVal DbContext As Database.DbContext, ByVal AccountGroupCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountGroupDetail)

            LoadByAccountGroupCode = From AccountGroupDetail In DbContext.GetQuery(Of Database.Entities.AccountGroupDetail)
                                     Where AccountGroupDetail.AccountGroupCode = AccountGroupCode
                                     Select AccountGroupDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountGroupDetail)

            Load = From AccountGroupDetail In DbContext.GetQuery(Of Database.Entities.AccountGroupDetail)
                   Select AccountGroupDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    AccountGroupDetail.SequenceNumber = (From Entity In LoadByAccountGroupCode(DbContext, AccountGroupDetail.AccountGroupCode) _
                                                         Select Entity.SequenceNumber).Max + 1

                Catch ex As Exception
                    AccountGroupDetail.SequenceNumber = 1
                End Try

                DbContext.AccountGroupDetails.Add(AccountGroupDetail)

                ErrorText = AccountGroupDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountGroupDetail)

                ErrorText = AccountGroupDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountGroupDetail)

                    DbContext.SaveChanges()

                    Deleted = True

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ACCOUNT_GROUP_DTL] SET GROUP_SEQ = (GROUP_SEQ - 1) WHERE GROUP_CODE = '{0}' AND GROUP_SEQ > {1}", AccountGroupDetail.AccountGroupCode, AccountGroupDetail.SequenceNumber))

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("The account group detail is in use and cannot be deleted.")

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
