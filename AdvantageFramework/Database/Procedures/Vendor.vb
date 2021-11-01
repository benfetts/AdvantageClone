Namespace Database.Procedures.Vendor

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

#Region "  Core Entities "

        Public Function LoadCore(ByVal Vendors As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor)) As IEnumerable(Of AdvantageFramework.Database.Core.Vendor)

            Try

                LoadCore = Vendors _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.Name,
                                                              Entity.VendorCategory,
                                                              Entity.ActiveFlag}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Vendor With {.Code = Entity.Code,
                                                                                                      .Name = Entity.Name,
                                                                                                      .VendorCategory = Entity.VendorCategory,
                                                                                                      .ActiveFlag = Entity.ActiveFlag}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Vendor)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        'Public Function DoesVendorHaveAStationInUse(DbContext As Database.DbContext, VendorCode As String) As Boolean

        '    Dim VendorHasAStationInUse As Boolean = False

        '    VendorHasAStationInUse = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT 
        '                                                                                         COUNT(*)
        '                                                                                        FROM 
        '                                                                                         dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD
        '                                                                                        WHERE 
        '                                                                                         MBWMD.VN_CODE = '{0}'
        '                                                                                         AND MBWMD.STATION_ID IS NOT NULL", VendorCode)).FirstOrDefault > 0)

        '    DoesVendorHaveAStationInUse = VendorHasAStationInUse

        'End Function
        Public Function GetVendorMarketCode(DbContext As Database.DbContext, VendorCode As String) As String

            Dim MarketCode As String = String.Empty

            MarketCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT 
	                                                                                    MARKET_CODE
                                                                                    FROM 
	                                                                                    dbo.VENDOR
                                                                                    WHERE 
	                                                                                    VN_CODE = '{0}'", VendorCode)).FirstOrDefault

            GetVendorMarketCode = MarketCode

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.Vendors, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Vendors As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Vendor), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadWithOfficeLimits = From Vendor In Vendors
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(Vendor.OfficeCode)
                                   Select Vendor

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadActiveByCategoryWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session, ByVal VendorCategory As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadActiveByCategoryWithOfficeLimits = LoadWithOfficeLimits(LoadActiveByCategory(DbContext, VendorCategory), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveEmployeeVendorsWithOfficeLimits(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadAllActiveEmployeeVendorsWithOfficeLimits = LoadWithOfficeLimits(LoadAllActiveEmployeeVendors(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveEmployeeVendors(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            Try

                LoadAllActiveEmployeeVendors = From Vendor In DbContext.Vendors
                                               Where Vendor.ActiveFlag = 1 AndAlso
                                                     Vendor.EmployeeVendor = 1
                                               Select Vendor

            Catch ex As Exception
                LoadAllActiveEmployeeVendors = Nothing
            End Try

        End Function
        Public Function LoadEmployeeVendors(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            Try

                LoadEmployeeVendors = From Vendor In DbContext.GetQuery(Of Database.Entities.Vendor)
                                      Where Vendor.EmployeeVendor = 1
                                      Select Vendor

            Catch ex As Exception
                LoadEmployeeVendors = Nothing
            End Try

        End Function
        Public Function LoadByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As Database.Entities.Vendor

            Try

                LoadByVendorCode = (From Vendor In DbContext.GetQuery(Of Database.Entities.Vendor)
                                    Where Vendor.Code = VendorCode
                                    Select Vendor).SingleOrDefault

            Catch ex As Exception
                LoadByVendorCode = Nothing
            End Try

        End Function
        Public Function LoadByVendorTermCode(ByVal DbContext As Database.DbContext, ByVal VendorTermCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            Try

                LoadByVendorTermCode = (From Vendor In DbContext.GetQuery(Of Database.Entities.Vendor)
                                        Where Vendor.VendorTermCode = VendorTermCode
                                        Select Vendor)

            Catch ex As Exception
                LoadByVendorTermCode = Nothing
            End Try

        End Function

        Public Function LoadByVendorByFunctionCode(ByVal DbContext As Database.DbContext, ByVal VendorFunctionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            Try

                LoadByVendorByFunctionCode = (From Vendor In DbContext.Vendors
                                              Where Vendor.FunctionCode = VendorFunctionCode AndAlso
                                                    Vendor.ActiveFlag = 1
                                              Select Vendor)

            Catch ex As Exception
                LoadByVendorByFunctionCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadAllActive = From Vendor In DbContext.GetQuery(Of Database.Entities.Vendor)
                            Where Vendor.ActiveFlag = 1
                            Select Vendor

        End Function
        Public Function LoadActiveByCategory(ByVal DbContext As Database.DbContext, ByVal VendorCategory As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            LoadActiveByCategory = From Vendor In LoadAllActive(DbContext)
                                   Where Vendor.VendorCategory = VendorCategory
                                   Select Vendor

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Vendor)

            Load = From Vendor In DbContext.Vendors
                   Select Vendor

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Vendors.Add(Vendor)

                ErrorText = Vendor.ValidateEntity(IsValid)

                If IsValid Then

                    If Vendor.VendorCategory IsNot Nothing AndAlso (Vendor.VendorCategory = "T" OrElse Vendor.VendorCategory = "R") Then

                        Vendor.IsNielsenSubsciber = True

                    End If

                    If Vendor.VendorCategory IsNot Nothing AndAlso Vendor.VendorCategory = "T" Then

                        Vendor.IsComscoreSubsciber = True

                    End If

                    DbContext.SaveChanges()

                    AdvantageFramework.Database.Procedures.VendorHistory.CreateFromVendorAdd(DbContext, Vendor)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim OldVendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                OldVendor = LoadByVendorCode(DbContext, Vendor.Code)

                DbContext.UpdateObject(Vendor)

                ErrorText = Vendor.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    AdvantageFramework.Database.Procedures.VendorHistory.CreateFromVendorUpdate(DbContext, OldVendor, Vendor)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim VendorComment As AdvantageFramework.Database.Entities.VendorComment = Nothing

            Try

                If IsValid Then

					Try

						IsValid = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.CHECK_REGISTER WHERE PAY_TO_CODE = '{0}'", Vendor.Code)).FirstOrDefault = 0)

					Catch ex As Exception
						IsValid = False
					End Try

					If IsValid Then

						Try

							DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.VENDOR WHERE VN_CODE = '{0}'", Vendor.Code))

						Catch ex As Exception
							IsValid = False
						End Try

					End If

					If IsValid Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.EEOC_STATUS WHERE VENDOR = '{0}'", Vendor.Code))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.VEN_REP WHERE VN_CODE = '{0}'", Vendor.Code))

                        For Each EntityClass In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, Vendor.Code).ToList

                            AdvantageFramework.Database.Procedures.VendorContact.Delete(DbContext, EntityClass)

                        Next

                        For Each EntityClass In AdvantageFramework.Database.Procedures.VendorSortKey.LoadByVendorCode(DbContext, Vendor.Code).ToList

                            AdvantageFramework.Database.Procedures.VendorSortKey.Delete(DbContext, EntityClass)

                        Next

                        VendorComment = AdvantageFramework.Database.Procedures.VendorComment.LoadByVendorCode(DbContext, Vendor.Code)

                        If VendorComment IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.VendorComment.Delete(DbContext, VendorComment)

                        End If

                        AdvantageFramework.Database.Procedures.VendorHistory.CreateFromVendorDelete(DbContext, Vendor)

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
