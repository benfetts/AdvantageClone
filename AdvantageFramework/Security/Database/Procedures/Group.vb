Namespace Security.Database.Procedures.Group

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

        Public Function LoadByGroupIDs(ByVal DbContext As Database.DbContext, ByVal GroupIDs() As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Group)

            LoadByGroupIDs = From Group In DbContext.Groups.AsQueryable
                             Where GroupIDs.Contains(Group.ID)
                             Select Group

        End Function
        Public Function LoadByGroupID(ByVal DbContext As Database.DbContext, ByVal GroupID As Integer) As Security.Database.Entities.Group

            Try

                LoadByGroupID = (From Group In DbContext.GetQuery(Of Database.Entities.Group)
                                 Where Group.ID = GroupID
                                 Select Group).SingleOrDefault

            Catch ex As Exception
                LoadByGroupID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Group)

            Load = From Group In DbContext.GetQuery(Of Database.Entities.Group)
                   Select Group

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Name As String, ByVal Description As String, _
                               ByRef Group As AdvantageFramework.Security.Database.Entities.Group) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                Group = New AdvantageFramework.Security.Database.Entities.Group

                Group.DbContext = DbContext
                Group.Name = Name
                Group.Description = Description

                Inserted = Insert(DbContext, Group)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Group As AdvantageFramework.Security.Database.Entities.Group) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Application As AdvantageFramework.Security.Database.Entities.Application = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Entities.Module = Nothing
            Dim SecuritySettingAttribute As AdvantageFramework.Security.Attributes.SecuritySettingAttribute = Nothing

            Try

                DbContext.Groups.Add(Group)

                ErrorText = Group.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                    For Each Application In AdvantageFramework.Security.Database.Procedures.Application.Load(DbContext)

                        AdvantageFramework.Security.Database.Procedures.GroupApplicationAccess.Insert(DbContext, Group.ID, Application.ID, False, True, True, True, False, False, Nothing)

                    Next

                    AdvantageFramework.Security.Database.Procedures.GroupModuleAccess.InsertDefaultAccessByGroupID(DbContext, Group.ID)

                    For Each Setting In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Security.GroupSettings), False)

                        Try

                            SecuritySettingAttribute = System.Attribute.GetCustomAttribute(GetType(AdvantageFramework.Security.GroupSettings).GetField(Setting), GetType(AdvantageFramework.Security.Attributes.SecuritySettingAttribute))

                        Catch ex As Exception
                            SecuritySettingAttribute = Nothing
                        End Try

                        If SecuritySettingAttribute IsNot Nothing Then

                            If SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                                AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(DbContext, Group.ID, Setting, Nothing, SecuritySettingAttribute.DefaultValue, Nothing, Nothing)

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then


                                AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(DbContext, Group.ID, Setting, Nothing, Nothing, SecuritySettingAttribute.DefaultValue, Nothing)

                            Else

                                AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(DbContext, Group.ID, Setting, SecuritySettingAttribute.DefaultValue, Nothing, Nothing, Nothing)

                            End If
                            
                        Else

                            AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(DbContext, Group.ID, Setting, Nothing, Nothing, Nothing, Nothing)

                        End If

                    Next

                    AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.InsertDefaultAccessByGroupID(DbContext, Group.ID)

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Group As AdvantageFramework.Security.Database.Entities.Group) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Group)

                ErrorText = Group.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Group As AdvantageFramework.Security.Database.Entities.Group) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser = Nothing
            Dim GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess = Nothing
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing

            Try

                If IsValid Then

                    If AdvantageFramework.Security.Database.Procedures.GroupUser.DeleteByGroupID(DbContext, Group.ID) Then

                        If AdvantageFramework.Security.Database.Procedures.GroupApplicationAccess.DeleteByGroupID(DbContext, Group.ID) Then

                            If AdvantageFramework.Security.Database.Procedures.GroupModuleAccess.DeleteByGroupID(DbContext, Group.ID) Then

                                If AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.DeleteByGroupID(DbContext, Group.ID) Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.DeleteByGroupID(DbContext, Group.ID) Then

                                        DbContext.DeleteEntityObject(Group)

                                        DbContext.SaveChanges()

                                        Deleted = True

                                    End If

                                End If

                            End If

                        End If

                    End If

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
