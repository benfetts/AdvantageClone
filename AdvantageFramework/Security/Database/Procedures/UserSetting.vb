Namespace Security.Database.Procedures.UserSetting

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

        Public Function LoadByUserIDs(ByVal DbContext As Database.DbContext, ByVal UserIDs() As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserSetting)

            LoadByUserIDs = From UserSetting In DbContext.UserSettings.AsQueryable
                            Where UserIDs.Contains(UserSetting.UserID)
                            Select UserSetting

        End Function
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserSetting)

            LoadByUserID = From UserSetting In DbContext.GetQuery(Of Database.Entities.UserSetting)
                           Where UserSetting.UserID = UserID
                           Select UserSetting

        End Function
        Public Function LoadBySettingCode(ByVal DbContext As Database.DbContext, ByVal SettingCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserSetting)

            LoadBySettingCode = From UserSetting In DbContext.GetQuery(Of Database.Entities.UserSetting)
                                Where UserSetting.SettingCode = SettingCode
                                Select UserSetting

        End Function
        Public Function LoadByUserIDAndSettingCode(ByVal DbContext As Database.DbContext, ByVal UserID As Integer, ByVal SettingCode As String) As Security.Database.Entities.UserSetting

            Try

                LoadByUserIDAndSettingCode = (From UserSetting In DbContext.GetQuery(Of Database.Entities.UserSetting)
                                              Where UserSetting.UserID = UserID AndAlso
                                                    UserSetting.SettingCode = SettingCode
                                              Select UserSetting).SingleOrDefault

            Catch ex As Exception
                LoadByUserIDAndSettingCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserSetting)

            Load = From UserSetting In DbContext.GetQuery(Of Database.Entities.UserSetting)
                   Select UserSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer, _
                               ByVal SettingCode As String, ByVal StringValue As String, _
                               ByVal NumericValue As System.Nullable(Of Decimal), ByVal DateValue As System.Nullable(Of Date), _
                               ByRef UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                UserSetting.DbContext = DbContext
                UserSetting.UserID = UserID
                UserSetting.SettingCode = SettingCode
                UserSetting.StringValue = StringValue
                UserSetting.NumericValue = NumericValue
                UserSetting.DateValue = DateValue

                Inserted = Insert(DbContext, UserSetting)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserSettings.Add(UserSetting)

                ErrorText = UserSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserSetting)

                ErrorText = UserSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserSetting)

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
        Public Function DeleteByUserID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_SETTING WHERE SEC_USER_ID = " & UserID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
