Namespace Security.Database.Procedures.ServiceFeeReconciliationSetting

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

        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As Security.Database.Entities.ServiceFeeReconciliationSetting

            Try

                LoadByUserCode = (From ServiceFeeReconciliationSetting In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSetting)
                                  Where ServiceFeeReconciliationSetting.UserCode = UserCode
                                  Select ServiceFeeReconciliationSetting).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationSetting)

            Load = From ServiceFeeReconciliationSetting In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSetting)
                   Select ServiceFeeReconciliationSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeReconciliationSettings.Add(ServiceFeeReconciliationSetting)

                ErrorText = ServiceFeeReconciliationSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeReconciliationSetting)

                ErrorText = ServiceFeeReconciliationSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeReconciliationSetting)

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
