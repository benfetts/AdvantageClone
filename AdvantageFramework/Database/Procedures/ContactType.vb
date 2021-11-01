Namespace Database.Procedures.ContactType

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

        Public Function LoadByContactTypeID(ByVal DbContext As Database.DbContext, ByVal ContactTypeID As Integer) As Database.Entities.ContactType

            Try

                LoadByContactTypeID = (From ContactType In DbContext.GetQuery(Of Database.Entities.ContactType)
                                       Where ContactType.ID = ContactTypeID
                                       Select ContactType).SingleOrDefault

            Catch ex As Exception
                LoadByContactTypeID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContactType)

            Load = From ContactType In DbContext.GetQuery(Of Database.Entities.ContactType)
                   Select ContactType

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContactType As AdvantageFramework.Database.Entities.ContactType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ContactTypes.Add(ContactType)

                ErrorText = ContactType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContactType As AdvantageFramework.Database.Entities.ContactType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ContactType)

                ErrorText = ContactType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContactType As AdvantageFramework.Database.Entities.ContactType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    If IsContactTypeInUse(DbContext, ContactType.ID) = False Then

                        DbContext.DeleteEntityObject(ContactType)

                        DbContext.SaveChanges()

                        Deleted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("This contact type is in use and cannot be deleted.")

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
        Public Function IsContactTypeInUse(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContactTypeID As Integer) As Boolean

            'objects
            Dim InUse As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.ClientContact.Any(Function(Entity) Entity.ContactTypeID = ContactTypeID) = False Then

                    If DbContext.VendorContacts.Any(Function(Entity) Entity.ContactTypeID = ContactTypeID) = False Then

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.VEN_REP WHERE CONTACT_TYPE_ID = {0}", ContactTypeID)).FirstOrDefault = 0 Then

                            InUse = False

                        End If

                    End If

                End If

            Catch ex As Exception
                InUse = False
            Finally
                IsContactTypeInUse = InUse
            End Try

        End Function

#End Region

    End Module

End Namespace
