Namespace Database.Procedures.DataGridViewColumnUserSetting

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

        Public Function LoadByDataGridViewIDAndDataGridViewColumnIDAndUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewID As Long, ByVal DataGridViewColumnID As Long, ByVal UserCode As String) As AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting

            Try

                LoadByDataGridViewIDAndDataGridViewColumnIDAndUserCode = (From DataGridViewColumnUserSetting In DbContext.GetQuery(Of Database.Entities.DataGridViewColumnUserSetting)
                                                                          Where DataGridViewColumnUserSetting.DataGridViewID = DataGridViewID AndAlso
                                                                                 DataGridViewColumnUserSetting.DataGridViewColumnID = DataGridViewColumnID AndAlso
                                                                                 DataGridViewColumnUserSetting.UserCode = UserCode
                                                                          Select DataGridViewColumnUserSetting).SingleOrDefault

            Catch ex As Exception
                LoadByDataGridViewIDAndDataGridViewColumnIDAndUserCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting)

            Load = From DataGridViewColumnUserSetting In DbContext.GetQuery(Of Database.Entities.DataGridViewColumnUserSetting)
                   Select DataGridViewColumnUserSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumnUserSetting As AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DataGridViewColumnUserSettings.Add(DataGridViewColumnUserSetting)

                ErrorText = DataGridViewColumnUserSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumnUserSetting As AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(DataGridViewColumnUserSetting)

                ErrorText = DataGridViewColumnUserSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataGridViewColumnUserSetting As AdvantageFramework.Database.Entities.DataGridViewColumnUserSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then
                    
                    DbContext.DeleteEntityObject(DataGridViewColumnUserSetting)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.GRID_COLUMN_SETTING WHERE GRID_COLUMN_ID IN (" & Join(DataGridViewColumnIDs, ", ") & ")")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByDataGridViewColumnIDs = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
