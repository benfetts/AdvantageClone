Namespace Database.Procedures.ClientCashReceiptOnAccount

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

        Public Function LoadActiveByClientCashReceiptID(ByVal DbContext As Database.DbContext, ByVal ClientCashReceiptID As Integer) As Database.Entities.ClientCashReceiptOnAccount

            Try
                LoadActiveByClientCashReceiptID = (From ClientCashReceiptOnAccount In DbContext.GetQuery(Of Database.Entities.ClientCashReceiptOnAccount)
                                                   Where ClientCashReceiptOnAccount.ClientCashReceiptID = ClientCashReceiptID AndAlso
                                                         ClientCashReceiptOnAccount.Distributed Is Nothing
                                                   Select ClientCashReceiptOnAccount).SingleOrDefault

            Catch ex As Exception
                LoadActiveByClientCashReceiptID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCashReceiptOnAccount)

            Load = From ClientCashReceiptOnAccount In DbContext.GetQuery(Of Database.Entities.ClientCashReceiptOnAccount)
                   Select ClientCashReceiptOnAccount

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientCashReceiptOnAccounts.Add(ClientCashReceiptOnAccount)

                ErrorText = ClientCashReceiptOnAccount.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        ClientCashReceiptOnAccount.ItemID = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Load(DbContext) _
                                                             Where Entity.ClientCashReceiptID = ClientCashReceiptOnAccount.ClientCashReceiptID AndAlso _
                                                                   Entity.ClientCashReceiptSequenceNumber = ClientCashReceiptOnAccount.ClientCashReceiptSequenceNumber
                                                             Select Entity.ItemID).Max + 1

                    Catch ex As Exception
                        ClientCashReceiptOnAccount.ItemID = 1
                    End Try

                End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientCashReceiptOnAccount)

                ErrorText = ClientCashReceiptOnAccount.ValidateEntity(IsValid)

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
