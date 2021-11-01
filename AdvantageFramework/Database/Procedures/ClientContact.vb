Namespace Database.Procedures.ClientContact

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

        Public Function LoadContactsNotAssignedToDivisionOrProduct(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContact)

            LoadContactsNotAssignedToDivisionOrProduct = From ClientContact In DbContext.ClientContact
                                                         Where DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.ClientContactDetail).Where(Function(CCDetail) CCDetail.ContactID = ClientContact.ContactID).Any = False AndAlso
                                                               ClientContact.ClientCode = ClientCode
                                                         Select ClientContact

        End Function
        Public Function LoadByContactID(ByVal DbContext As Database.DbContext, ByVal ContactID As Int32) As AdvantageFramework.Database.Entities.ClientContact

            Try

                LoadByContactID = (From ClientContact In DbContext.ClientContact
                                   Where ClientContact.ContactID = ContactID
                                   Select ClientContact).SingleOrDefault

            Catch ex As Exception
                LoadByContactID = Nothing
            End Try

        End Function
        Public Function LoadByClientAndContactCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal ContactCode As String) As AdvantageFramework.Database.Entities.ClientContact

            Try

                LoadByClientAndContactCode = (From ClientContact In DbContext.ClientContact
                                              Where ClientContact.ClientCode = ClientCode AndAlso
                                                    ClientContact.ContactCode = ContactCode
                                              Select ClientContact).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndContactCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContact)

            LoadAllActiveByClientCode = From ClientContact In LoadAllActive(DbContext)
                                        Where ClientContact.ClientCode = ClientCode
                                        Select ClientContact

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContact)

            LoadByClientCode = From ClientContact In DbContext.ClientContact
                               Where ClientContact.ClientCode = ClientCode
                               Select ClientContact

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContact)

            LoadAllActive = From ClientContact In DbContext.ClientContact
                            Where ClientContact.IsInactive Is Nothing OrElse
                                  ClientContact.IsInactive = 0
                            Select ClientContact

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContact)

            Load = From ClientContact In DbContext.ClientContact
                   Select ClientContact

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientContact.Add(ClientContact)

                ErrorText = ClientContact.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientContact)

                ErrorText = ClientContact.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact) As Boolean

            Delete = Delete(DbContext, ClientContact.ContactID)

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContactID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If DbContext.Database.Connection.State <> ConnectionState.Open Then

                    DbContext.Database.Connection.Open()

                End If

                DbTransaction = DbContext.Database.BeginTransaction

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CDP_CONTACT_DTL WHERE CDP_CONTACT_ID = {0}", ContactID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CP_SEC_CLIENT WHERE CDP_CONTACT_ID = {0}", ContactID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CDP_CONTACT_HDR WHERE CDP_CONTACT_ID = {0}", ContactID))

                    Deleted = True

                Catch ex As Exception
                    Deleted = False
                End Try

                If Deleted Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                    AdvantageFramework.Navigation.ShowMessageBox("This Contact is currently in use and cannot be deleted.")

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
