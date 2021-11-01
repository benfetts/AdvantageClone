Namespace Database.Procedures.MediaTrafficPrintSetting

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

        Public Function LoadByUserCodeAndMediaType(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, MediaType As String) As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting

            LoadByUserCodeAndMediaType = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaTrafficPrintSetting)
                                          Where Entity.UserCode = UserCode AndAlso
                                                Entity.MediaType = MediaType
                                          Select Entity).SingleOrDefault

        End Function
        Public Function Load(DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaTrafficPrintSetting)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaTrafficPrintSetting)()

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficPrintSettings.Add(MediaTrafficPrintSetting)

                ErrorMessage = MediaTrafficPrintSetting.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(MediaTrafficPrintSetting).State = Entity.EntityState.Modified

                ErrorMessage = MediaTrafficPrintSetting.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
