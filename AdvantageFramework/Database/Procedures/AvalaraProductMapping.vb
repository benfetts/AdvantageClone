Namespace Database.Procedures.AvalaraProductMapping

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.AvalaraProductMapping)

            Load = From AvalaraProductMapping In DataContext.AvalaraProductMappings
                   Select AvalaraProductMapping

        End Function
        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.AvalaraProductMapping

            Try

                LoadByID = (From AvalaraProductMapping In DataContext.AvalaraProductMappings _
                            Where AvalaraProductMapping.ID = ID _
                            Select AvalaraProductMapping).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try
            
        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AvalaraProductMapping As AdvantageFramework.Database.Entities.AvalaraProductMapping) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AvalaraProductMapping.DataContext = DataContext

                AvalaraProductMapping.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AvalaraProductMappings.InsertOnSubmit(AvalaraProductMapping)

                ErrorText = AvalaraProductMapping.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AvalaraProductMapping As AdvantageFramework.Database.Entities.AvalaraProductMapping) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AvalaraProductMapping.DataContext = DataContext

                AvalaraProductMapping.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AvalaraProductMapping.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AvalaraProductMapping As AdvantageFramework.Database.Entities.AvalaraProductMapping) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.AvalaraProductMappings.DeleteOnSubmit(AvalaraProductMapping)

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