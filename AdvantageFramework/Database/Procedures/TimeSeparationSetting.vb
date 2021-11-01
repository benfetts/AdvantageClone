Namespace Database.Procedures.TimeSeparationSetting

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

        Public Function LoadByInvoiceMatchingSettingID(ByVal DbContext As Database.DbContext, ByVal InvoiceMatchingSettingID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TimeSeparationSetting)

            LoadByInvoiceMatchingSettingID = From TimeSeparationSetting In DbContext.GetQuery(Of Database.Entities.TimeSeparationSetting)
                                             Where TimeSeparationSetting.InvoiceMatchingSettingID = InvoiceMatchingSettingID
                                             Select TimeSeparationSetting

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.TimeSeparationSetting

            Try

                LoadByID = (From TimeSeparationSetting In DbContext.GetQuery(Of Database.Entities.TimeSeparationSetting)
                            Where TimeSeparationSetting.ID = ID
                            Select TimeSeparationSetting).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TimeSeparationSetting)

            Load = From TimeSeparationSetting In DbContext.GetQuery(Of Database.Entities.TimeSeparationSetting)
                   Select TimeSeparationSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimeSeparationSetting As AdvantageFramework.Database.Entities.TimeSeparationSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.TimeSeparationSettings.Add(TimeSeparationSetting)

                ErrorText = TimeSeparationSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimeSeparationSetting As AdvantageFramework.Database.Entities.TimeSeparationSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(TimeSeparationSetting)

                ErrorText = TimeSeparationSetting.ValidateEntity(IsValid)

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
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimeSeparationSettingID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.TIME_SEPARATION_SETTING WHERE SETTING_ID = {0}", TimeSeparationSettingID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
