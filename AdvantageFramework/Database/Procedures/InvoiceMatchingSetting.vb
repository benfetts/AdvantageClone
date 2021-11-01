Namespace Database.Procedures.InvoiceMatchingSetting

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

        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.InvoiceMatchingSetting

            Try

                LoadByID = (From InvoiceMatchingSetting In DbContext.GetQuery(Of Database.Entities.InvoiceMatchingSetting)
                            Where InvoiceMatchingSetting.ID = ID
                            Select InvoiceMatchingSetting).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InvoiceMatchingSetting)

            Load = From InvoiceMatchingSetting In DbContext.GetQuery(Of Database.Entities.InvoiceMatchingSetting)
                   Select InvoiceMatchingSetting

        End Function
        'Public Function LoadWithOfficeLimits(ByVal DbContext As Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InvoiceMatchingSetting)

        '    LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        'End Function
        'Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InvoiceMatchingSetting)

        '    LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.InvoiceMatchingSettings, OfficeCodes, HasLimitedOfficeCodes)

        'End Function
        'Public Function LoadWithOfficeLimits(ByVal InvoiceMatchingSettings As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.InvoiceMatchingSetting), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InvoiceMatchingSetting)

        '    LoadWithOfficeLimits = From InvoiceMatchingSetting In InvoiceMatchingSettings
        '                           Where HasLimitedOfficeCodes = False OrElse
        '                                 OfficeCodes.Contains(InvoiceMatchingSetting.OfficeCode)
        '                           Select InvoiceMatchingSetting

        'End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.InvoiceMatchingSettings.Add(InvoiceMatchingSetting)

                ErrorText = InvoiceMatchingSetting.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(InvoiceMatchingSetting)

                ErrorText = InvoiceMatchingSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.TIME_SEPARATION_SETTING WHERE BRDCAST_DTL_VERIFICATION_SETTING_ID = {0}", InvoiceMatchingSetting.ID))

                    DbContext.DeleteEntityObject(InvoiceMatchingSetting)

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

#End Region

    End Module

End Namespace
