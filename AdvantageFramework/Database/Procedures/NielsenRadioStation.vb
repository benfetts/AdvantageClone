Namespace Database.Procedures.NielsenRadioStation

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenRadioStation)

            Load = From NielsenRadioStation In DbContext.GetQuery(Of Database.Entities.NielsenRadioStation)
                   Select NielsenRadioStation

        End Function
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, NielsenRadioStation As AdvantageFramework.Database.Entities.NielsenRadioStation,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(NielsenRadioStation)

                ErrorText = NielsenRadioStation.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
