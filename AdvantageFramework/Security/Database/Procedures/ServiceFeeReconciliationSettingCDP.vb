Namespace Security.Database.Procedures.ServiceFeeReconciliationSettingCDP

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

        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer, ByVal ServiceFeeReconciliationSettingCDPType As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationSettingCDP)


            If ServiceFeeReconciliationSettingCDPType = Entities.ServiceFeeReconciliationSettingCDPTypes.Client Then

                LoadByUserID = From ServiceFeeReconciliationSettingCDP In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingCDP)
                               Where ServiceFeeReconciliationSettingCDP.UserID = UserID AndAlso
                                     ServiceFeeReconciliationSettingCDP.ClientCode IsNot Nothing AndAlso
                                     ServiceFeeReconciliationSettingCDP.DivisionCode Is Nothing AndAlso
                                     ServiceFeeReconciliationSettingCDP.ProductCode Is Nothing
                               Select ServiceFeeReconciliationSettingCDP

            ElseIf ServiceFeeReconciliationSettingCDPType = Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivision Then

                LoadByUserID = From ServiceFeeReconciliationSettingCDP In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingCDP)
                               Where ServiceFeeReconciliationSettingCDP.UserID = UserID AndAlso
                                     ServiceFeeReconciliationSettingCDP.ClientCode IsNot Nothing AndAlso
                                     ServiceFeeReconciliationSettingCDP.DivisionCode IsNot Nothing AndAlso
                                     ServiceFeeReconciliationSettingCDP.ProductCode Is Nothing
                               Select ServiceFeeReconciliationSettingCDP

            ElseIf ServiceFeeReconciliationSettingCDPType = Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivisionProduct Then

                LoadByUserID = From ServiceFeeReconciliationSettingCDP In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingCDP)
                               Where ServiceFeeReconciliationSettingCDP.UserID = UserID AndAlso
                                     ServiceFeeReconciliationSettingCDP.ClientCode IsNot Nothing AndAlso
                                     ServiceFeeReconciliationSettingCDP.DivisionCode IsNot Nothing AndAlso
                                     ServiceFeeReconciliationSettingCDP.ProductCode IsNot Nothing
                               Select ServiceFeeReconciliationSettingCDP

            Else

                LoadByUserID = From ServiceFeeReconciliationSettingCDP In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingCDP)
                               Where ServiceFeeReconciliationSettingCDP.UserID = UserID
                               Select ServiceFeeReconciliationSettingCDP

            End If

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationSettingCDP)

            Load = From ServiceFeeReconciliationSettingCDP In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationSettingCDP)
                   Select ServiceFeeReconciliationSettingCDP

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer, ByVal ServiceFeeReconciliationSettingCDPType As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes, ByVal Codes() As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If ServiceFeeReconciliationSettingCDPType = Entities.ServiceFeeReconciliationSettingCDPTypes.Client Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SERVICE_FEE_DEF_CDP([SEC_USER_ID], [CL_CODE], [DIV_CODE], [PRD_CODE]) " & _
                                                                    "SELECT {0}, CL_CODE, NULL, NULL FROM dbo.CLIENT WHERE CL_CODE IN ('{1}')", UserID, Join(Codes, "', '")))

                ElseIf ServiceFeeReconciliationSettingCDPType = Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivision Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SERVICE_FEE_DEF_CDP([SEC_USER_ID], [CL_CODE], [DIV_CODE], [PRD_CODE]) " & _
                                                                    "SELECT {0}, CL_CODE, DIV_CODE, NULL  FROM dbo.DIVISION WHERE CL_CODE + '|' + DIV_CODE IN ('{1}')", UserID, Join(Codes, "', '")))

                ElseIf ServiceFeeReconciliationSettingCDPType = Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivisionProduct Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SERVICE_FEE_DEF_CDP([SEC_USER_ID], [CL_CODE], [DIV_CODE], [PRD_CODE]) " & _
                                                                    "SELECT {0}, CL_CODE, DIV_CODE, PRD_CODE  FROM dbo.PRODUCT WHERE CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE IN ('{1}')", UserID, Join(Codes, "', '")))

                End If

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSettingCDP As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDP) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeReconciliationSettingCDPs.Add(ServiceFeeReconciliationSettingCDP)

                ErrorText = ServiceFeeReconciliationSettingCDP.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSettingCDP As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDP) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeReconciliationSettingCDP)

                ErrorText = ServiceFeeReconciliationSettingCDP.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationSettingCDP As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDP) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeReconciliationSettingCDP)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SERVICE_FEE_DEF_CDP WHERE [SEC_USER_ID] = " & UserID)

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
