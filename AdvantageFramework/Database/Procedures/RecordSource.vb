Namespace Database.Procedures.RecordSource

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

        Public Function LoadByRecordSourceID(ByVal DbContext As Database.DbContext, ByVal RecordSourceID As Integer) As Database.Entities.RecordSource

            Try

                LoadByRecordSourceID = (From RecordSource In DbContext.GetQuery(Of Database.Entities.RecordSource)
                                        Where RecordSource.ID = RecordSourceID
                                        Select RecordSource).SingleOrDefault

            Catch ex As Exception
                LoadByRecordSourceID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RecordSource)

            Load = From RecordSource In DbContext.GetQuery(Of Database.Entities.RecordSource)
                   Select RecordSource

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RecordSource As AdvantageFramework.Database.Entities.RecordSource) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.RecordSources.Add(RecordSource)

                ErrorText = RecordSource.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RecordSource As AdvantageFramework.Database.Entities.RecordSource) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(RecordSource)

                ErrorText = RecordSource.ValidateEntity(IsValid)

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
