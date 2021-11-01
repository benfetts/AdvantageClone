Namespace Database.Procedures.CustomReport

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            Load = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                   Select CustomReport

        End Function
        Public Function LoadByLegacyModuleCode(ByVal DbContext As Database.DbContext, ByVal LegacyModuleCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            Try

                LoadByLegacyModuleCode = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                                         Where CustomReport.LegacyModuleCode = LegacyModuleCode
                                         Select CustomReport

            Catch ex As Exception
                LoadByLegacyModuleCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveTVReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveTVReports = From CustomReport In LoadTVReports(DbContext)
                                     Where CustomReport.IsInactive = 1
                                     Select CustomReport

        End Function
        Public Function LoadAllActiveRadioReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveRadioReports = From CustomReport In LoadRadioReports(DbContext)
                                        Where CustomReport.IsInactive = 1
                                        Select CustomReport

        End Function
        Public Function LoadAllActiveNewspaperReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveNewspaperReports = From CustomReport In LoadNewspaperReports(DbContext)
                                            Where CustomReport.IsInactive = 1
                                            Select CustomReport

        End Function
        Public Function LoadAllActiveOutOfHomeReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveOutOfHomeReports = From CustomReport In LoadOutOfHomeReports(DbContext)
                                            Where CustomReport.IsInactive = 1
                                            Select CustomReport

        End Function
        Public Function LoadAllActiveMagazineReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveMagazineReports = From CustomReport In LoadMagazineReports(DbContext)
                                           Where CustomReport.IsInactive = 1
                                           Select CustomReport

        End Function
        Public Function LoadAllActiveProductionReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveProductionReports = From CustomReport In LoadProductionReports(DbContext)
                                             Where CustomReport.IsInactive = 1
                                             Select CustomReport

        End Function
        Public Function LoadAllActiveInternetReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadAllActiveInternetReports = From CustomReport In LoadInternetReports(DbContext)
                                           Where CustomReport.IsInactive = 1
                                           Select CustomReport

        End Function
        Public Function LoadTVReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadTVReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                            Where CustomReport.LegacyModuleCode = "TI" OrElse
                                  CustomReport.LegacyModuleCode = "CI"
                            Select CustomReport

        End Function
        Public Function LoadRadioReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadRadioReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                               Where CustomReport.LegacyModuleCode = "RI" OrElse
                                     CustomReport.LegacyModuleCode = "CI"
                               Select CustomReport

        End Function
        Public Function LoadNewspaperReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadNewspaperReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                                   Where CustomReport.LegacyModuleCode = "NI" OrElse
                                         CustomReport.LegacyModuleCode = "CI"
                                   Select CustomReport

        End Function
        Public Function LoadOutOfHomeReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadOutOfHomeReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                                   Where CustomReport.LegacyModuleCode = "OI" OrElse
                                         CustomReport.LegacyModuleCode = "CI"
                                   Select CustomReport

        End Function
        Public Function LoadMagazineReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadMagazineReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                                  Where CustomReport.LegacyModuleCode = "MI" OrElse
                                        CustomReport.LegacyModuleCode = "CI"
                                  Select CustomReport

        End Function
        Public Function LoadProductionReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadProductionReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                                    Where CustomReport.LegacyModuleCode = "PI" OrElse
                                          CustomReport.LegacyModuleCode = "CI"
                                    Select CustomReport

        End Function
        Public Function LoadInternetReports(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomReport)

            LoadInternetReports = From CustomReport In DbContext.GetQuery(Of Database.Entities.CustomReport)
                                  Where CustomReport.LegacyModuleCode = "II" OrElse
                                        CustomReport.LegacyModuleCode = "CI"
                                  Select CustomReport

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal Name As String, ByVal Description As String, ByVal LegacyModuleCode As String, _
                               ByVal IsCustom As Short, ByVal ReportCode As Integer, ByVal IsInactive As Short, _
                               ByRef CustomReport As AdvantageFramework.Database.Entities.CustomReport) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                CustomReport = New AdvantageFramework.Database.Entities.CustomReport

                CustomReport.DbContext = DbContext
                CustomReport.Name = Name
                CustomReport.Description = Description
                CustomReport.LegacyModuleCode = LegacyModuleCode
                CustomReport.IsCustom = IsCustom
                CustomReport.ReportCode = ReportCode
                CustomReport.IsInactive = IsInactive

                Inserted = Insert(DbContext, CustomReport)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CustomReport As AdvantageFramework.Database.Entities.CustomReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.CustomReports.Add(CustomReport)

                ErrorText = CustomReport.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CustomReport As AdvantageFramework.Database.Entities.CustomReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CustomReport)

                ErrorText = CustomReport.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CustomReport As AdvantageFramework.Database.Entities.CustomReport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(CustomReport)

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
        Public Function DeleteByCustomReportNames(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CustomReportNames() As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.ACCESS_FORMAT WHERE REPORT_NAME IN ('" & Join(CustomReportNames, "', '") & "')")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByCustomReportNames = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
