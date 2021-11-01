Namespace Database.Procedures.ClientCrossReference

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

        Public Function LoadBySourceClientCodeAndSourceProductCodeAndRecordSourceID(ByVal DbContext As Database.DbContext, ByVal SourceClientCode As String, ByVal SourceProductCode As String, ByVal RecordSourceID As Integer) As Database.Entities.ClientCrossReference

            Try

                LoadBySourceClientCodeAndSourceProductCodeAndRecordSourceID = (From ClientCrossReference In DbContext.GetQuery(Of Database.Entities.ClientCrossReference)
                                                                               Where ClientCrossReference.SourceClientCode = SourceClientCode AndAlso
                                                                                     ClientCrossReference.SourceProductCode = SourceProductCode AndAlso
                                                                                     ClientCrossReference.RecordSourceID = RecordSourceID
                                                                               Select ClientCrossReference).SingleOrDefault

            Catch ex As Exception
                LoadBySourceClientCodeAndSourceProductCodeAndRecordSourceID = Nothing
            End Try

        End Function
        Public Function LoadByRecordSourceID(ByVal DbContext As Database.DbContext, ByVal RecordSourceID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCrossReference)

            LoadByRecordSourceID = From ClientCrossReference In DbContext.GetQuery(Of Database.Entities.ClientCrossReference)
                                   Where ClientCrossReference.RecordSourceID = RecordSourceID
                                   Select ClientCrossReference

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCrossReference)

            Load = From ClientCrossReference In DbContext.GetQuery(Of Database.Entities.ClientCrossReference)
                   Select ClientCrossReference

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientCrossReferences.Add(ClientCrossReference)

                ErrorText = ClientCrossReference.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientCrossReference)

                ErrorText = ClientCrossReference.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientCrossReference)

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
