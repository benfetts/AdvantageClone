Namespace Security.Database.Procedures.GroupModuleAccess

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

        Public Function LoadByModuleIDAndGroupID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer, ByVal GroupID As Integer) As Security.Database.Entities.GroupModuleAccess

            Try

                LoadByModuleIDAndGroupID = (From GroupModuleAccess In DbContext.GetQuery(Of Database.Entities.GroupModuleAccess)
                                            Where GroupModuleAccess.GroupID = GroupID AndAlso
                                                 GroupModuleAccess.ModuleID = ModuleID
                                            Select GroupModuleAccess).SingleOrDefault

            Catch ex As Exception
                LoadByModuleIDAndGroupID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupModuleAccess)

            Load = From GroupModuleAccess In DbContext.GetQuery(Of Database.Entities.GroupModuleAccess)
                   Select GroupModuleAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer, ByVal ModuleID As Integer, _
                               ByVal IsBlocked As Boolean, ByVal CanAdd As Boolean, ByVal CanPrint As Boolean, _
                               ByVal CanUpdate As Boolean, ByVal Custom1 As Boolean, ByVal Custom2 As Boolean, _
                               ByRef GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                GroupModuleAccess = New AdvantageFramework.Security.Database.Entities.GroupModuleAccess

                GroupModuleAccess.DbContext = DbContext
                GroupModuleAccess.GroupID = GroupID
                GroupModuleAccess.ModuleID = ModuleID
                GroupModuleAccess.IsBlocked = IsBlocked
                GroupModuleAccess.CanAdd = CanAdd
                GroupModuleAccess.CanPrint = CanPrint
                GroupModuleAccess.CanUpdate = CanUpdate
                GroupModuleAccess.Custom1 = Custom1
                GroupModuleAccess.Custom2 = Custom2

                Inserted = Insert(DbContext, GroupModuleAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GroupModuleAccesses.Add(GroupModuleAccess)

                ErrorText = GroupModuleAccess.ValidateEntity(IsValid)

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
        Public Function InsertDefaultAccessByGroupID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_GROUP_MODACCESS([SEC_MODULE_ID], [SEC_GROUP_ID], [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2]) " & _
                                                  "SELECT [SEC_MODULE_ID], " & GroupID & ", 0, 1, 1, 1, 0, 0 FROM dbo.SEC_MODULE")

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertDefaultAccessByGroupID = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GroupModuleAccess)

                ErrorText = GroupModuleAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GroupModuleAccess)

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
        Public Function DeleteByGroupID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_MODACCESS WHERE SEC_GROUP_ID = " & GroupID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGroupID = Deleted
            End Try

        End Function
        Public Function CopyFromGroup(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer, ByVal CopyFromGroupID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False

            Try

                If AdvantageFramework.Security.Database.Procedures.GroupModuleAccess.DeleteByGroupID(DbContext, GroupID) Then

                    DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_GROUP_MODACCESS([SEC_MODULE_ID], [SEC_GROUP_ID], [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2]) " & _
                                                      "SELECT [SEC_MODULE_ID], " & GroupID & ", [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2] FROM dbo.SEC_GROUP_MODACCESS WHERE SEC_GROUP_ID = " & CopyFromGroupID)

                    Copied = True

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyFromGroup = Copied
            End Try

        End Function

#End Region

    End Module

End Namespace
