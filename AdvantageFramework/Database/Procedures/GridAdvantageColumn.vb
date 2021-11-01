Namespace Database.Procedures.GridAdvantageColumn

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

        Public Function LoadByGridID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal GridID As Long) As IQueryable(Of Database.Entities.GridAdvantageColumn)

            Try

                LoadByGridID = From GridAdvantageColumn In DataContext.GridAdvantageColumns
                               Where GridAdvantageColumn.GridID = GridID
                               Select GridAdvantageColumn

            Catch ex As Exception
                LoadByGridID = Nothing
            End Try

        End Function
        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Long) As Database.Entities.GridAdvantageColumn

            Try

                LoadByID = (From GridAdvantageColumn In DataContext.GridAdvantageColumns
                            Where GridAdvantageColumn.ID = ID
                            Select GridAdvantageColumn).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.GridAdvantageColumn)

            Load = From GridAdvantageColumn In DataContext.GridAdvantageColumns
                   Select GridAdvantageColumn

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal GridAdvantageColumn As AdvantageFramework.Database.Entities.GridAdvantageColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                GridAdvantageColumn.DataContext = DataContext

                GridAdvantageColumn.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.GridAdvantageColumns.InsertOnSubmit(GridAdvantageColumn)

                ErrorText = GridAdvantageColumn.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal GridAdvantageColumn As AdvantageFramework.Database.Entities.GridAdvantageColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                GridAdvantageColumn.DataContext = DataContext

                GridAdvantageColumn.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = GridAdvantageColumn.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal GridAdvantageColumn As AdvantageFramework.Database.Entities.GridAdvantageColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.GridAdvantageColumns.DeleteOnSubmit(GridAdvantageColumn)

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
        Public Function DeleteByGridID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal GridID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.GRID_ADVANTAGE_COLUMN WHERE GRID_ID = {0}", GridID))

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGridID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
