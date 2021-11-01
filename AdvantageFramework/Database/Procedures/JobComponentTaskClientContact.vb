Namespace Database.Procedures.JobComponentTaskClientContact

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTaskClientContact)

            Load = From JobComponentTaskClientContact In DbContext.GetQuery(Of Database.Entities.JobComponentTaskClientContact)
                   Select JobComponentTaskClientContact

        End Function
        Public Function LoadByJobCompAndSequence(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponentTaskClientContact)

            LoadByJobCompAndSequence = From JobComponentTaskClientContact In DbContext.GetQuery(Of Database.Entities.JobComponentTaskClientContact)
                                       Where JobComponentTaskClientContact.JobNumber = JobNumber AndAlso
                                             JobComponentTaskClientContact.JobComponentNumber = JobComponentNumber AndAlso
                                             JobComponentTaskClientContact.SequenceNumber = SequenceNumber
                                       Select JobComponentTaskClientContact

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.JobComponentTaskClientContact

            Try

                LoadByID = (From JobComponentTaskClientContact In DbContext.GetQuery(Of Database.Entities.JobComponentTaskClientContact)
                            Where JobComponentTaskClientContact.ID = ID
                            Select JobComponentTaskClientContact).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskClientContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobComponentTaskClientContacts.Add(JobComponentTaskClientContact)

                ErrorText = JobComponentTaskClientContact.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskClientContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobComponentTaskClientContact)

                ErrorText = JobComponentTaskClientContact.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentTaskClientContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobComponentTaskClientContact)

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
