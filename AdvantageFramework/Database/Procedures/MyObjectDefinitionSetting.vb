Namespace Database.Procedures.MyObjectDefinitionSetting

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.MyObjectDefinitionSetting

            Try

                LoadByID = (From MyObjectDefinitionSetting In DbContext.GetQuery(Of Database.Entities.MyObjectDefinitionSetting)
                            Where MyObjectDefinitionSetting.ID = ID
                            Select MyObjectDefinitionSetting).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MyObjectDefinitionSetting)

            Load = From MyObjectDefinitionSetting In DbContext.GetQuery(Of Database.Entities.MyObjectDefinitionSetting)
                   Select MyObjectDefinitionSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MyObjectDefinitionSetting As AdvantageFramework.Database.Entities.MyObjectDefinitionSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    MyObjectDefinitionSetting.ID = (From Entity In Load(DbContext) _
                                                    Select Entity.ID).Max + 1

                Catch ex As Exception
                    MyObjectDefinitionSetting.ID = 1
                End Try

                DbContext.MyObjectDefinitionSettings.Add(MyObjectDefinitionSetting)

                ErrorText = MyObjectDefinitionSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MyObjectDefinitionSetting As AdvantageFramework.Database.Entities.MyObjectDefinitionSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MyObjectDefinitionSetting)

                ErrorText = MyObjectDefinitionSetting.ValidateEntity(IsValid)

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
