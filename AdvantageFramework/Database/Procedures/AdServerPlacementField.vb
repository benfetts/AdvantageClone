Namespace Database.Procedures.AdServerPlacementField

    <HideModuleName()>
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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdServerPlacementField)

            Load = From AdServerPlacementField In DbContext.GetQuery(Of Database.Entities.AdServerPlacementField)
                   Select AdServerPlacementField

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AdServerPlacementFields.Add(AdServerPlacementField)

                ErrorText = AdServerPlacementField.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AdServerPlacementField)

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
