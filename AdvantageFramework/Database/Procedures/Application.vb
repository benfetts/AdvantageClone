Namespace Database.Procedures.Application

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

        Public Function LoadByModuleCode(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal ModuleCode As String) As System.Data.Objects.ObjectQuery(Of AdvantageFramework.Database.Entities.Application)

            LoadByModuleCode = From Application In ObjectContext.Applications _
                               Where Application.ModuleCode = ModuleCode _
                               Select Application

        End Function
        Public Function LoadByApplicationCode(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal ApplicationCode As String) As AdvantageFramework.Database.Entities.Application

            Try

                LoadByApplicationCode = (From Application In ObjectContext.Applications _
                                         Where Application.Code = ApplicationCode _
                                         Select Application).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext) As System.Data.Objects.ObjectQuery(Of AdvantageFramework.Database.Entities.Application)

            Load = From Application In ObjectContext.Applications _
                   Select Application

        End Function
        Public Function Insert(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal Application As AdvantageFramework.Database.Entities.Application) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ObjectContext.Applications.AddObject(Application)

                ErrorText = Application.ValidateEntity(IsValid)

                If IsValid Then

                    ObjectContext.SaveChanges()

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
        Public Function Update(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal Application As AdvantageFramework.Database.Entities.Application) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ObjectContext.UpdateObject(Application)

                ErrorText = Application.ValidateEntity(IsValid)

                If IsValid Then

                    ObjectContext.SaveChanges()

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
        Public Function Delete(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal Application As AdvantageFramework.Database.Entities.Application) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    ObjectContext.DeleteEntityObject(Application)

                    ObjectContext.SaveChanges()

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
