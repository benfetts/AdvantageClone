Namespace Database.Procedures.Status

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

        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Status)

            LoadAllActive = From Status In DbContext.GetQuery(Of Database.Entities.Status)
                            Where Status.IsInactive Is Nothing OrElse
                                  Status.IsInactive = 0
                            Select Status

        End Function
        Public Function LoadByStatusCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StatusCode As String) As AdvantageFramework.Database.Entities.Status

            Try

                LoadByStatusCode = (From Status In DbContext.GetQuery(Of Database.Entities.Status)
                                    Where Status.Code = StatusCode
                                    Select Status).SingleOrDefault

            Catch ex As Exception
                LoadByStatusCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Status)

            Load = From Status In DbContext.GetQuery(Of Database.Entities.Status)
                   Select Status

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Status As AdvantageFramework.Database.Entities.Status) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing

            Try

                DbContext.Status.Add(Status)

                ErrorText = Status.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                    Try

                        If Status.IsInactive.GetValueOrDefault(0) <> 1 Then

                            SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                            SettingValue.DataContext = DataContext

                            SettingValue.SettingCode = AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString
                            SettingValue.DisplayText = Status.Description
                            SettingValue.Value = Status.Code

                            AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                        End If
                        
                    Catch ex As Exception

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Status As AdvantageFramework.Database.Entities.Status) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Try

                DbContext.UpdateObject(Status)

                ErrorText = Status.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                    Try

                        If Status.IsInactive.GetValueOrDefault(0) = 1 Then

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString)

                            If Setting IsNot Nothing Then

                                If Setting.Value <> Status.Code Then
                                    
                                    AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString, Status.Code)

                                End If

                            End If

                        Else

                            If AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString).Any(Function(Entity) Entity.Value.ToString = Status.Code) = False Then

                                SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                                SettingValue.DataContext = DataContext

                                SettingValue.SettingCode = AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString
                                SettingValue.DisplayText = Status.Description
                                SettingValue.Value = Status.Code

                                AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                            Else

                                SettingValue = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCodeAndValue(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString, Status.Code)

                                If SettingValue IsNot Nothing Then
                                    SettingValue.DisplayText = Status.Description
                                    AdvantageFramework.Database.Procedures.SettingValue.Update(DataContext, SettingValue)
                                End If


                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Status As AdvantageFramework.Database.Entities.Status) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT (*) FROM JOB_TRAFFIC WHERE TRF_CODE = '{0}'", Status.Code.Replace("'", "''"))).FirstOrDefault > 0 Then

                    ErrorText = "The status is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(Status)

                    DbContext.SaveChanges()

                    Deleted = True

                    Try

                        AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString, Status.Code)

                    Catch ex As Exception

                    End Try

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

