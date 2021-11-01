Namespace Database.Procedures.EstimatePrintingSetting

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

        Public Function LoadByEstimatePrintingSettingClientCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCode As String) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            Try

                LoadByEstimatePrintingSettingClientCode = (From EstimatePrintingSetting In DataContext.EstimatePrintingSetting
                                                           Where EstimatePrintingSetting.ClientCode = ClientCode AndAlso
                                                                  EstimatePrintingSetting.DivisionCode = Nothing AndAlso
                                                                  EstimatePrintingSetting.ProductCode = Nothing
                                                           Select EstimatePrintingSetting).SingleOrDefault

            Catch ex As Exception
                LoadByEstimatePrintingSettingClientCode = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DataContext, ByVal ClientCode As String) As Database.Entities.EstimatePrintingSetting

            Try

                LoadByClientCode = (From EstimatePrintingSetting In DbContext.EstimatePrintingSetting
                                    Where EstimatePrintingSetting.ClientOrDefault = 2 AndAlso
                                          EstimatePrintingSetting.ClientCode = ClientCode
                                    Select EstimatePrintingSetting).SingleOrDefault

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadByEstimatePrintingSettingClientDivisionProduct(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            Try

                LoadByEstimatePrintingSettingClientDivisionProduct = (From EstimatePrintingSetting In DataContext.EstimatePrintingSetting _
                                    Where EstimatePrintingSetting.ClientCode = ClientCode AndAlso _
                                          EstimatePrintingSetting.DivisionCode = DivisionCode AndAlso _
                                          EstimatePrintingSetting.ProductCode = ProductCode _
                                    Select EstimatePrintingSetting).SingleOrDefault

            Catch ex As Exception
                LoadByEstimatePrintingSettingClientDivisionProduct = Nothing
            End Try

        End Function
        Public Function LoadAgencyDefault(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            Try

                LoadAgencyDefault = (From EstimatePrintingSetting In DataContext.EstimatePrintingSetting _
                                     Where EstimatePrintingSetting.ClientOrDefault = 1 _
                                     Select EstimatePrintingSetting).SingleOrDefault

            Catch ex As Exception
                LoadAgencyDefault = Nothing
            End Try

        End Function
        Public Function LoadOneTimeSettings(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            Try

                LoadOneTimeSettings = (From EstimatePrintingSetting In DataContext.EstimatePrintingSetting
                                       Where EstimatePrintingSetting.ClientOrDefault = 0
                                       Select EstimatePrintingSetting).SingleOrDefault

            Catch ex As Exception
                LoadOneTimeSettings = Nothing
            End Try

        End Function
        Public Function LoadByEstimatePrintingSettingUser(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal User As String) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            Try

                LoadByEstimatePrintingSettingUser = (From EstimatePrintingSetting In DataContext.EstimatePrintingSetting _
                                     Where EstimatePrintingSetting.UserID = User _
                                     Select EstimatePrintingSetting).SingleOrDefault

            Catch ex As Exception
                LoadByEstimatePrintingSettingUser = Nothing
            End Try

        End Function

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)

            Load = From EstimatePrintingSetting In DataContext.EstimatePrintingSetting
                   Select EstimatePrintingSetting

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.EstimatePrintingSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.EstimatePrintingSetting.InsertOnSubmit(Setting)

                'ErrorText = DynamicReportSettings.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.EstimatePrintingSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                'ErrorText = EstimatePrintingSetting.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingValue As AdvantageFramework.Database.Entities.EstimatePrintingSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.EstimatePrintingSetting.DeleteOnSubmit(SettingValue)

                    DataContext.SubmitChanges()

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
        Public Function ResetToDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimatePrintDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting) As Boolean

            'objects
            Dim Reseted As Boolean = False

            'Reseted = ResetToDefaults(DbContext, EstimatePrintDefault.ID)

            ResetToDefaults = Reseted

        End Function
        Public Function ResetToDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimatePrintDefaultID As Integer) As Boolean

            'objects
            Dim Reseted As Boolean = False

            Try

                Reseted = (DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[advsp_production_invoice_format_reset_defaults] {0}", EstimatePrintDefaultID)) > 0)

            Catch ex As Exception
                Reseted = False
            End Try

            ResetToDefaults = Reseted

        End Function
#End Region

    End Module

End Namespace
