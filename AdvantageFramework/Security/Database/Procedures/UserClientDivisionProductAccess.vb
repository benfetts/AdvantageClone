Namespace Security.Database.Procedures.UserClientDivisionProductAccess

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

        Public Function LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ProductCode As String, ByVal DivisionCode As String, ByVal ClientCode As String) As Security.Database.Entities.UserClientDivisionProductAccess

            Try

                LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode = (From UserClientDivisionProductAccess In DbContext.GetQuery(Of Database.Entities.UserClientDivisionProductAccess)
                                                                            Where UserClientDivisionProductAccess.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                                                                  UserClientDivisionProductAccess.ProductCode = ProductCode AndAlso
                                                                                  UserClientDivisionProductAccess.DivisionCode = DivisionCode AndAlso
                                                                                  UserClientDivisionProductAccess.ClientCode = ClientCode
                                                                            Select UserClientDivisionProductAccess).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserClientDivisionProductAccess)

            LoadByUserCode = From UserClientDivisionProductAccess In DbContext.GetQuery(Of Database.Entities.UserClientDivisionProductAccess)
                             Where UserClientDivisionProductAccess.UserCode.ToUpper = UserCode.ToUpper
                             Select UserClientDivisionProductAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserClientDivisionProductAccess)

            Load = From UserClientDivisionProductAccess In DbContext.GetQuery(Of Database.Entities.UserClientDivisionProductAccess)
                   Select UserClientDivisionProductAccess

        End Function

        Public Function ValidateJobCDP(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ProductCode As String, ByVal DivisionCode As String, ByVal ClientCode As String) As Boolean

            Dim UserCDPList As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UserCDP As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            Dim Valid As Boolean = False

            UserCDPList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(DbContext, UserCode).ToList

            If UserCDPList IsNot Nothing AndAlso UserCDPList.Count > 0 Then

                UserCDP = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode(DbContext, UserCode, ProductCode, DivisionCode, ClientCode)

                If UserCDP IsNot Nothing Then

                    Valid = True

                Else

                    Valid = False

                End If

            Else

                Valid = True

            End If

            ValidateJobCDP = Valid

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String,
                               ByVal ProductCode As String, ByVal DivisionCode As String, ByVal ClientCode As String,
                               ByVal AllowTimeEntryOnly As Short,
                               ByRef UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserClientDivisionProductAccess = New AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess

                UserClientDivisionProductAccess.DbContext = DbContext
                UserClientDivisionProductAccess.UserCode = UserCode
                UserClientDivisionProductAccess.ProductCode = ProductCode
                UserClientDivisionProductAccess.DivisionCode = DivisionCode
                UserClientDivisionProductAccess.ClientCode = ClientCode
                UserClientDivisionProductAccess.AllowTimeEntryOnly = AllowTimeEntryOnly

                Inserted = Insert(DbContext, UserClientDivisionProductAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserClientDivisionProductAccesses.Add(UserClientDivisionProductAccess)

                ErrorText = UserClientDivisionProductAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserClientDivisionProductAccess)

                ErrorText = UserClientDivisionProductAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserClientDivisionProductAccess)

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
