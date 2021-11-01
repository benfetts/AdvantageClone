Namespace Database.Procedures.VendorContact

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

        Public Function LoadByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorContact)

            Try

                LoadByVendorCode = From VendorContact In DbContext.GetQuery(Of Database.Entities.VendorContact)
                                   Where VendorContact.VendorCode = VendorCode
                                   Select VendorContact

            Catch ex As Exception
                LoadByVendorCode = Nothing
            End Try

        End Function
        Public Function LoadByVendorAndVendorContactCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String, ByVal VendorContactCode As String) As Database.Entities.VendorContact

            Try

                LoadByVendorAndVendorContactCode = (From VendorContact In DbContext.GetQuery(Of Database.Entities.VendorContact)
                                                    Where VendorContact.Code = VendorContactCode AndAlso
                                                          VendorContact.VendorCode = VendorCode
                                                    Select VendorContact).SingleOrDefault

            Catch ex As Exception
                LoadByVendorAndVendorContactCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorContact)

            LoadAllActive = From VendorContact In DbContext.VendorContacts
                            Where VendorContact.IsInactive Is Nothing OrElse
                                  VendorContact.IsInactive = 0
                            Select VendorContact

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorContact)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorContact)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.VendorContacts, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal VendorContacts As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContact), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorContact)

            LoadWithOfficeLimits = From VendorContact In VendorContacts.Include("Vendor")
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(VendorContact.Vendor.OfficeCode)
                                   Select VendorContact

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorContact)

            Load = From VendorContact In DbContext.GetQuery(Of Database.Entities.VendorContact)
                   Select VendorContact

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContact As AdvantageFramework.Database.Entities.VendorContact) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.VendorContacts.Add(VendorContact)

                ErrorText = VendorContact.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContact As AdvantageFramework.Database.Entities.VendorContact) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(VendorContact)

                ErrorText = VendorContact.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContact As AdvantageFramework.Database.Entities.VendorContact) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.VEN_CONT WHERE VC_CODE = '{0}' AND VN_CODE = '{1}'", VendorContact.Code, VendorContact.VendorCode))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then

                        Deleted = True

                    End If

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