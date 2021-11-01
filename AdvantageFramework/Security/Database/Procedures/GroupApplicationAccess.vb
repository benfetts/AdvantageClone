Namespace Security.Database.Procedures.GroupApplicationAccess

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

        Public Function LoadByGroupID(ByVal DbContext As Database.DbContext, ByVal GroupID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupApplicationAccess)

            LoadByGroupID = From GroupApplicationAccess In DbContext.GetQuery(Of Database.Entities.GroupApplicationAccess)
                            Where GroupApplicationAccess.GroupID = GroupID
                            Select GroupApplicationAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupApplicationAccess)

            Load = From GroupApplicationAccess In DbContext.GetQuery(Of Database.Entities.GroupApplicationAccess)
                   Select GroupApplicationAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer, ByVal ApplicationID As Integer, _
                               ByVal IsBlocked As Boolean, ByVal CanAdd As Boolean, ByVal CanPrint As Boolean, _
                               ByVal CanUpdate As Boolean, ByVal Custom1 As Boolean, ByVal Custom2 As Boolean, _
                               ByRef GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                GroupApplicationAccess = New AdvantageFramework.Security.Database.Entities.GroupApplicationAccess

                GroupApplicationAccess.DbContext = DbContext
                GroupApplicationAccess.GroupID = GroupID
                GroupApplicationAccess.ApplicationID = ApplicationID
                GroupApplicationAccess.IsBlocked = IsBlocked
                GroupApplicationAccess.CanAdd = CanAdd
                GroupApplicationAccess.CanPrint = CanPrint
                GroupApplicationAccess.CanUpdate = CanUpdate
                GroupApplicationAccess.Custom1 = Custom1
                GroupApplicationAccess.Custom2 = Custom2

                Inserted = Insert(DbContext, GroupApplicationAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GroupApplicationAccesses.Add(GroupApplicationAccess)

                ErrorText = GroupApplicationAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GroupApplicationAccess)

                ErrorText = GroupApplicationAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GroupApplicationAccess)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_APPACCESS WHERE SEC_GROUP_ID = " & GroupID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGroupID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
