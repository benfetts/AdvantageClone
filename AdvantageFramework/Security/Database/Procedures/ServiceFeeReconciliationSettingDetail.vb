Namespace Security.Database.Procedures.ServiceFeeReconciliationSettingDetail

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

        Public Function LoadByUserCodeAndType(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal Type As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationSettingDetail)

            LoadByUserCodeAndType = From ServiceFeeReconciliationSettingDetail In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingDetail)
                                    Where ServiceFeeReconciliationSettingDetail.UserCode = UserCode AndAlso
                                          ServiceFeeReconciliationSettingDetail.Type = Type
                                    Select ServiceFeeReconciliationSettingDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationSettingDetail)

            Load = From ServiceFeeReconciliationSettingDetail In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingDetail)
                   Select ServiceFeeReconciliationSettingDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal ServiceFeeReconciliationSettingDetailType As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes, ByVal Codes() As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If ServiceFeeReconciliationSettingDetailType = Entities.ServiceFeeReconciliationSettingDetailTypes.PROD_COMM_SC OrElse _
                        ServiceFeeReconciliationSettingDetailType = Entities.ServiceFeeReconciliationSettingDetailTypes.STD_FEE_SC Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SERVICE_FEE_DEF_DTL([USER_ID], [DTL_TYPE], [DTL_CODE]) " & _
                                                                    "SELECT '{0}', '{1}', SC.SC_CODE FROM dbo.SALES_CLASS AS SC WHERE SC.SC_CODE IN ('{2}')", UserCode, ServiceFeeReconciliationSettingDetailType.ToString, Join(Codes, "', '")))

                ElseIf ServiceFeeReconciliationSettingDetailType = Entities.ServiceFeeReconciliationSettingDetailTypes.PROD_COMM_FUNC OrElse _
                        ServiceFeeReconciliationSettingDetailType = Entities.ServiceFeeReconciliationSettingDetailTypes.STD_FEE_FUNC Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SERVICE_FEE_DEF_DTL([USER_ID], [DTL_TYPE], [DTL_CODE]) " & _
                                                                    "SELECT '{0}', '{1}', F.FNC_CODE FROM dbo.FUNCTIONS AS F WHERE F.FNC_CODE IN ('{2}')", UserCode, ServiceFeeReconciliationSettingDetailType.ToString, Join(Codes, "', '")))

                ElseIf ServiceFeeReconciliationSettingDetailType = Entities.ServiceFeeReconciliationSettingDetailTypes.SERVICE_FEE_TYPE Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SERVICE_FEE_DEF_DTL([USER_ID], [DTL_TYPE], [DTL_CODE]) " & _
                                                                    "SELECT '{0}', '{1}', SFT.CODE FROM dbo.SERVICE_FEE_TYPE AS SFT WHERE SFT.CODE IN ('{2}')", UserCode, ServiceFeeReconciliationSettingDetailType.ToString, Join(Codes, "', '")))

                End If

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSettingDetail As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeReconciliationSettingDetails.Add(ServiceFeeReconciliationSettingDetail)

                ErrorText = ServiceFeeReconciliationSettingDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSettingDetail As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeReconciliationSettingDetail)

                ErrorText = ServiceFeeReconciliationSettingDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSettingDetail As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeReconciliationSettingDetail)

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
        Public Function DeleteByUserCode(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SERVICE_FEE_DEF_DTL WHERE [USER_ID] = '" & UserCode & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
