Namespace Database.Procedures.[Module]

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

        Public Function LoadByModuleCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ModuleCode As String) As AdvantageFramework.Database.Entities.Module

            Try

                LoadByModuleCode = (From [Module] In DataContext.Modules _
                                    Where [Module].Code = ModuleCode _
                                    Select [Module]).SingleOrDefault

            Catch ex As Exception
                LoadByModuleCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.Module)

            Load = From [Module] In DataContext.Modules
                   Select [Module]

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal [Module] As AdvantageFramework.Database.Entities.Module) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                [Module].DataContext = DataContext

                [Module].DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.Modules.InsertOnSubmit([Module])

                ErrorText = [Module].ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal [Module] As AdvantageFramework.Database.Entities.Module) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                [Module].DataContext = DataContext

                [Module].DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = [Module].ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal [Module] As AdvantageFramework.Database.Entities.Module) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then
                    
                    DataContext.Modules.DeleteOnSubmit([Module])

                    DataContext.SubmitChanges()

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
