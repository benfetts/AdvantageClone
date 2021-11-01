Namespace Database.Procedures.DataGridViewColumn

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

        Public Function LoadByDataGridViewIDAndDataGridViewColumnName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewID As Long, ByVal DataGridViewColumnName As String) As AdvantageFramework.Database.Entities.DataGridViewColumn

            Try

                LoadByDataGridViewIDAndDataGridViewColumnName = (From DataGridViewColumn In DbContext.GetQuery(Of Database.Entities.DataGridViewColumn)
                                                                 Where DataGridViewColumn.DataGridViewID = DataGridViewID AndAlso
                                                                        DataGridViewColumn.Name = DataGridViewColumnName
                                                                 Select DataGridViewColumn).SingleOrDefault

            Catch ex As Exception
                LoadByDataGridViewIDAndDataGridViewColumnName = Nothing
            End Try

        End Function
        Public Function LoadByDataGridViewID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DataGridViewColumn)

            LoadByDataGridViewID = From DataGridViewColumn In DbContext.GetQuery(Of Database.Entities.DataGridViewColumn)
                                   Where DataGridViewColumn.DataGridViewID = DataGridViewID
                                   Select DataGridViewColumn

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DataGridViewColumn)

            Load = From DataGridViewColumn In DbContext.GetQuery(Of Database.Entities.DataGridViewColumn)
                   Select DataGridViewColumn

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumn As AdvantageFramework.Database.Entities.DataGridViewColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DataGridViewColumns.Add(DataGridViewColumn)

                ErrorText = DataGridViewColumn.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumn As AdvantageFramework.Database.Entities.DataGridViewColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(DataGridViewColumn)

                ErrorText = DataGridViewColumn.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumn As AdvantageFramework.Database.Entities.DataGridViewColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then
                    
                    DbContext.DeleteEntityObject(DataGridViewColumn)

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
        Public Function DeleteByDataGridViewColumnIDs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumnIDs() As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If AdvantageFramework.Database.Procedures.DataGridViewColumnUserSetting.DeleteByDataGridViewColumnIDs(DbContext, DataGridViewColumnIDs) Then

                    DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.GRID_COLUMN WHERE GRID_COLUMN_ID IN (" & Join(DataGridViewColumnIDs, ", ") & ")")

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByDataGridViewColumnIDs = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
