Namespace Security.Database.Procedures.WorkspaceObject

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

        Public Function LoadByWorkspaceObjectID(ByVal DbContext As Database.DbContext, ByVal WorkspaceObjectID As Integer) As Security.Database.Entities.WorkspaceObject

            Try

                LoadByWorkspaceObjectID = (From WorkspaceObject In DbContext.GetQuery(Of Database.Entities.WorkspaceObject)
                                           Where WorkspaceObject.ID = WorkspaceObjectID
                                           Select WorkspaceObject).SingleOrDefault

            Catch ex As Exception
                LoadByWorkspaceObjectID = Nothing
            End Try

        End Function
        Public Function LoadByWorkspaceIDAndZoneID(ByVal DbContext As Database.DbContext, ByVal WorkspaceID As Integer, ByVal ZoneID As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceObject)

            LoadByWorkspaceIDAndZoneID = From WorkspaceObject In DbContext.GetQuery(Of Database.Entities.WorkspaceObject)
                                         Where WorkspaceObject.UserWorkspaceID = WorkspaceID AndAlso
                                               WorkspaceObject.ZoneID = ZoneID
                                         Select WorkspaceObject

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceObject)

            Load = From WorkspaceObject In DbContext.GetQuery(Of Database.Entities.WorkspaceObject)
                   Select WorkspaceObject

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal WorkspaceID As Integer, _
                               ByVal DesktopObjectID As Integer, ByVal ZoneID As String, ByVal Height As Nullable(Of Integer), _
                               ByVal Width As Nullable(Of Integer), ByVal TopCoordinate As Nullable(Of Integer), ByVal LeftCoordinate As Nullable(Of Integer), _
                               ByVal SortOrder As Nullable(Of Integer), _
                               ByRef WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                WorkspaceObject = New AdvantageFramework.Security.Database.Entities.WorkspaceObject

                WorkspaceObject.DbContext = DbContext
                WorkspaceObject.UserWorkspaceID = WorkspaceID
                WorkspaceObject.DesktopObjectID = DesktopObjectID
                WorkspaceObject.ZoneID = ZoneID
                WorkspaceObject.Height = Height
                WorkspaceObject.Width = Width
                WorkspaceObject.TopCoordinate = TopCoordinate
                WorkspaceObject.LeftCoordinate = LeftCoordinate
                WorkspaceObject.SortOrder = SortOrder

                Inserted = Insert(DbContext, WorkspaceObject)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.WorkspaceObjects.Add(WorkspaceObject)

                ErrorText = WorkspaceObject.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(WorkspaceObject)

                ErrorText = WorkspaceObject.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(WorkspaceObject)

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
        Public Function DeleteUserWorkspaceObjects(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspaceID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.WV_WORKSPACE_OBJECT WHERE WORKSPACE_ID = " & UserWorkspaceID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteUserWorkspaceObjects = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
