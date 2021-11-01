Namespace Database.Procedures.AccountReceivableCollectionNote

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

        Public Function LoadByARInvoiceNumberAndSequenceAndType(ByVal DbContext As Database.DbContext, ByVal ARInvoiceNumber As Integer, ByVal ARInvoiceSequenceNumber As Short, ByVal ARType As String) As Database.Entities.AccountReceivableCollectionNote

            Try

                LoadByARInvoiceNumberAndSequenceAndType = (From AccountReceivableCollectionNote In DbContext.GetQuery(Of Database.Entities.AccountReceivableCollectionNote)
                                                           Where AccountReceivableCollectionNote.ARInvoiceNumber = ARInvoiceNumber AndAlso
                                                                 AccountReceivableCollectionNote.ARInvoiceSequenceNumber = ARInvoiceSequenceNumber AndAlso
                                                                 AccountReceivableCollectionNote.ARType = ARType
                                                           Select AccountReceivableCollectionNote).SingleOrDefault

            Catch ex As Exception
                LoadByARInvoiceNumberAndSequenceAndType = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableCollectionNote)

            Load = From AccountReceivableCollectionNote In DbContext.GetQuery(Of Database.Entities.AccountReceivableCollectionNote)
                   Select AccountReceivableCollectionNote

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableCollectionNote As AdvantageFramework.Database.Entities.AccountReceivableCollectionNote) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountReceivableCollectionNotes.Add(AccountReceivableCollectionNote)

                ErrorText = AccountReceivableCollectionNote.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableCollectionNote As AdvantageFramework.Database.Entities.AccountReceivableCollectionNote) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountReceivableCollectionNote)

                ErrorText = AccountReceivableCollectionNote.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivableCollectionNote As AdvantageFramework.Database.Entities.AccountReceivableCollectionNote) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountReceivableCollectionNote)

                    DbContext.SaveChanges()

                    Deleted = True

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
