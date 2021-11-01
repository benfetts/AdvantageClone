Namespace Security.Database.Procedures.GroupSetting

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

        Public Function LoadBySettingCode(ByVal DbContext As Database.DbContext, ByVal SettingCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupSetting)

            LoadBySettingCode = From GroupSetting In DbContext.GetQuery(Of Database.Entities.GroupSetting)
                                Where GroupSetting.SettingCode = SettingCode
                                Select GroupSetting

        End Function
        Public Function LoadByGroupIDAndSettingCode(ByVal DbContext As Database.DbContext, ByVal GroupID As Integer, ByVal SettingCode As String) As Security.Database.Entities.GroupSetting

            Try

                LoadByGroupIDAndSettingCode = (From GroupSetting In DbContext.GetQuery(Of Database.Entities.GroupSetting)
                                               Where GroupSetting.GroupID = GroupID AndAlso
                                                     GroupSetting.SettingCode = SettingCode
                                               Select GroupSetting).SingleOrDefault

            Catch ex As Exception
                LoadByGroupIDAndSettingCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupSetting)

            Load = From GroupSetting In DbContext.GetQuery(Of Database.Entities.GroupSetting)
                   Select GroupSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer, _
                               ByVal SettingCode As String, ByVal StringValue As String, _
                               ByVal NumericValue As System.Nullable(Of Decimal), ByVal DateValue As System.Nullable(Of Date), _
                               ByRef GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                GroupSetting = New AdvantageFramework.Security.Database.Entities.GroupSetting

                GroupSetting.DbContext = DbContext
                GroupSetting.GroupID = GroupID
                GroupSetting.SettingCode = SettingCode
                GroupSetting.StringValue = StringValue
                GroupSetting.NumericValue = NumericValue
                GroupSetting.DateValue = DateValue

                Inserted = Insert(DbContext, GroupSetting)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GroupSettings.Add(GroupSetting)

                ErrorText = GroupSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GroupSetting)

                ErrorText = GroupSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GroupSetting)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_SETTING WHERE SEC_GROUP_ID = " & GroupID)

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

                If AdvantageFramework.Security.Database.Procedures.GroupSetting.DeleteByGroupID(DbContext, GroupID) Then

                    DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_GROUP_SETTING([SEC_GROUP_ID], [SETTING_CODE], [STRING_VALUE], [NUMERIC_VALUE], [DATE_VALUE]) " & _
                                                      "SELECT " & GroupID & ", [SETTING_CODE], [STRING_VALUE], [NUMERIC_VALUE], [DATE_VALUE] FROM dbo.SEC_GROUP_SETTING WHERE SEC_GROUP_ID = " & CopyFromGroupID)

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
