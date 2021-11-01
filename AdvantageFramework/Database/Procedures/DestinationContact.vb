Namespace Database.Procedures.DestinationContact

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

        Public Function LoadByDestinationAndContactCode(ByVal DbContext As Database.DbContext, ByVal DestinationCode As String, ByVal ContactCode As String) As Database.Entities.DestinationContact

            Try

                LoadByDestinationAndContactCode = (From DestinationContact In DbContext.GetQuery(Of Database.Entities.DestinationContact)
                                                   Where DestinationContact.DestinationCode = DestinationCode AndAlso
                                                         DestinationContact.Code = ContactCode
                                                   Select DestinationContact).SingleOrDefault

            Catch ex As Exception
                LoadByDestinationAndContactCode = Nothing
            End Try

        End Function
        Public Function LoadByDestinationCode(ByVal DbContext As Database.DbContext, ByVal DestinationCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DestinationContact)

            LoadByDestinationCode = From DestinationContact In DbContext.GetQuery(Of Database.Entities.DestinationContact)
                                    Where DestinationContact.DestinationCode = DestinationCode
                                    Select DestinationContact

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DestinationContact)

            LoadAllActive = From DestinationContact In DbContext.GetQuery(Of Database.Entities.DestinationContact)
                            Where DestinationContact.IsInactive Is Nothing OrElse
                                  DestinationContact.IsInactive = 0
                            Select DestinationContact

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DestinationContact)

            Load = From DestinationContact In DbContext.GetQuery(Of Database.Entities.DestinationContact)
                   Select DestinationContact

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DestinationContact As AdvantageFramework.Database.Entities.DestinationContact) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DestinationContacts.Add(DestinationContact)

                ErrorText = DestinationContact.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DestinationContact As AdvantageFramework.Database.Entities.DestinationContact) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(DestinationContact)

                ErrorText = DestinationContact.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DestinationContact As AdvantageFramework.Database.Entities.DestinationContact) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT ( *) FROM dbo.JOB_DESTINATION WHERE [DESTINATION_CODE] ='{0}' AND [DEST_CONT_CODE] ='{1}' ", _
                                                                             DestinationContact.DestinationCode, DestinationContact.Code)).FirstOrDefault > 0 Then

                    IsValid = False
                    ErrorText = "Code is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(DestinationContact)

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
