Namespace Database.Procedures.Product

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

        Public Function LoadCore(ByVal Products As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)) As IEnumerable(Of AdvantageFramework.Database.Core.Product)

            Try

                LoadCore = Products _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.ClientCode,
                                                              Entity.DivisionCode,
                                                              Entity.OfficeCode,
                                                              Entity.Name,
                                                              Entity.IsActive}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Product With {.Code = Entity.Code,
                                                                                                       .ClientCode = Entity.ClientCode,
                                                                                                       .DivisionCode = Entity.DivisionCode,
                                                                                                       .OfficeCode = Entity.OfficeCode,
                                                                                                       .Name = Entity.Name,
                                                                                                       .IsActive = Entity.IsActive}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Product)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCoreByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                           ByVal UserCode As String, Optional ByVal ActiveOnly As Boolean = False) As IEnumerable(Of AdvantageFramework.Database.Core.Product)

            Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim CoreProducts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

            Try

                UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList

                If ActiveOnly Then

                    CoreProducts = LoadCore(LoadAllActive(DbContext))

                Else

                    CoreProducts = LoadCore(Load(DbContext))

                End If

                If UserClientDivisionProductAccess.Count > 0 Then

                    LoadCoreByUserCode = (From Product In CoreProducts
                                          Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Product.ClientCode AndAlso UserCDP.DivisionCode = Product.DivisionCode AndAlso UserCDP.ProductCode = Product.Code) = True
                                          Select Product).ToList

                Else

                    LoadCoreByUserCode = CoreProducts

                End If

            Catch ex As Exception
                LoadCoreByUserCode = Nothing
            End Try

        End Function

#End Region

        Public Function LoadByUserForEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                  ByVal UserCode As String, ByVal EmployeeCode As String, ByVal ActiveOnly As Boolean) As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Product)

            Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim EmployeeUserCodes As String() = Nothing

            Try

                Try

                    EmployeeUserCodes = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
                                         Select [UC] = Entity.UserCode).ToArray

                Catch ex As Exception
                    EmployeeUserCodes = Nothing
                End Try

                If EmployeeUserCodes IsNot Nothing Then

                    If EmployeeUserCodes.Contains(UserCode) Then

                        EmployeeUserCodes = {UserCode}

                    End If

                    Try

                        UserClientDivisionProductAccess = (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext)
                                                           Where EmployeeUserCodes.Contains(Entity.UserCode)
                                                           Select Entity).ToList

                    Catch ex As Exception
                        UserClientDivisionProductAccess = Nothing
                    End Try

                End If

                If UserClientDivisionProductAccess IsNot Nothing AndAlso UserClientDivisionProductAccess.Count > 0 Then

                    If ActiveOnly Then

                        LoadByUserForEmployeeCode = (From Product In LoadCore(LoadAllActive(DbContext)).ToList
                                                     Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Product.ClientCode AndAlso UserCDP.DivisionCode = Product.DivisionCode AndAlso UserCDP.ProductCode = Product.Code) = True
                                                     Select Product).ToList

                    Else

                        LoadByUserForEmployeeCode = (From Product In LoadCore(DbContext).ToList
                                                     Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Product.ClientCode AndAlso UserCDP.DivisionCode = Product.DivisionCode AndAlso UserCDP.ProductCode = Product.Code) = True
                                                     Select Product).ToList

                    End If

                Else

                    If ActiveOnly Then

                        LoadByUserForEmployeeCode = (From Product In LoadCore(LoadAllActive(DbContext))
                                                     Select Product).ToList

                    Else

                        LoadByUserForEmployeeCode = (From Product In LoadCore(DbContext)
                                                     Select Product).ToList

                    End If

                End If

            Catch ex As Exception
                LoadByUserForEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                       ByVal UserCode As String, ByVal IncludeOfficeClientDivision As Boolean, Optional ByVal ActiveOnly As Boolean = False) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            Dim Products As String() = Nothing

            Try

                If AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList.Count > 0 Then

                    If IncludeOfficeClientDivision Then

                        LoadByUserCode = From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division")
                                         Let CDCode = Product.ClientCode & "|" & Product.DivisionCode, CDPCode = CDCode & "|" & Product.Code
                                         Where (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.UserClientDivisionProductAccess)
                                                Where Entity.UserCode.ToUpper = UserCode.ToUpper
                                                Select Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode).Contains(CDPCode)
                                         Select Product

                    Else

                        LoadByUserCode = From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product)
                                         Let CDCode = Product.ClientCode & "|" & Product.DivisionCode, CDPCode = CDCode & "|" & Product.Code
                                         Where (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.UserClientDivisionProductAccess)
                                                Where Entity.UserCode.ToUpper = UserCode.ToUpper
                                                Select Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode).Contains(CDPCode)
                                         Select Product

                    End If

                Else

                    If IncludeOfficeClientDivision Then

                        LoadByUserCode = From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division")
                                         Select Product

                    Else

                        LoadByUserCode = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                                         Select Product

                    End If

                End If

                If ActiveOnly Then

                    LoadByUserCode = LoadByUserCode.Where(Function(Product) Product.IsActive = 1)

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        'Public Function LoadByLoggedInUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
        '                                   ByVal Session As AdvantageFramework.Security.Session, ByVal ActiveOnly As Boolean) As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Product)

        '    Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
        '    'Dim EmployeeOffices As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
        '    Dim ProductIDs As System.Collections.Generic.List(Of String) = Nothing
        '    Dim OfficeProductIDs As System.Collections.Generic.List(Of String) = Nothing
        '    Dim UserProductIDs As System.Collections.Generic.List(Of String) = Nothing
        '    Dim OfficeCodes As Collections.Generic.List(Of String) = Nothing

        '    Try

        '        UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, Session.UserCode).ToList

        '        OfficeCodes = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByOfficeCodesByEmployeeCode(DbContext, Session.User.EmployeeCode)

        '        If UserClientDivisionProductAccess.Any OrElse OfficeCodes.Any Then

        '            If UserClientDivisionProductAccess.Any Then

        '                UserProductIDs = (From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).ToList
        '                                  Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Product.ClientCode AndAlso UserCDP.DivisionCode = Product.DivisionCode AndAlso UserCDP.ProductCode = Product.Code) = True
        '                                  Select Product.ID).ToList

        '            End If

        '            If OfficeCodes.Any Then

        '                OfficeProductIDs = (From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).ToList
        '                                    Where OfficeCodes.Any(Function(OfficeCode) OfficeCode = Product.OfficeCode) = True
        '                                    Select Product.ID).ToList

        '            End If

        '            ProductIDs = New System.Collections.Generic.List(Of String)

        '            If UserProductIDs IsNot Nothing AndAlso UserProductIDs.Count > 0 Then

        '                ProductIDs.AddRange(UserProductIDs)

        '            End If

        '            If OfficeProductIDs IsNot Nothing AndAlso OfficeProductIDs.Count > 0 Then

        '                ProductIDs.AddRange(OfficeProductIDs)

        '            End If

        '            ProductIDs = ProductIDs.Distinct.ToList

        '            LoadByLoggedInUser = (From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).ToList
        '                                  Where ProductIDs.Contains(Product.ID) = True
        '                                  Select Product).ToList

        '        Else

        '            LoadByLoggedInUser = (From Product In DbContext.GetQuery(Of Database.Entities.Product)
        '                                  Select Product).ToList

        '        End If

        '        If ActiveOnly Then

        '            LoadByLoggedInUser = LoadByLoggedInUser.Where(Function(Product) Product.IsActive.GetValueOrDefault(0) = 1).ToList

        '        End If

        '    Catch ex As Exception
        '        LoadByLoggedInUser = Nothing
        '    End Try

        'End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Product)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Product)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.Products, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Products As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Product), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Collections.Generic.List(Of Database.Entities.Product)

            LoadWithOfficeLimits = (From Product In Products
                                    Where HasLimitedOfficeCodes = False OrElse
                                          OfficeCodes.Contains(Product.OfficeCode)
                                    Select Product).ToList

        End Function
        Public Function LoadWithOfficeLimits(ByVal Products As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Product)

            LoadWithOfficeLimits = From Product In Products
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(Product.OfficeCode)
                                   Select Product

        End Function
        Public Function LoadAllActiveWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadAllActiveByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadAllActiveByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext, IncludeOfficeClientDivision As Boolean, Optional ByVal ActiveOnly As Boolean = False) As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Product)

            LoadByUserCodeWithOfficeLimits = LoadByUserCodeWithOfficeLimits(DbContext, SecurityDbContext, Session.UserCode, IncludeOfficeClientDivision, ActiveOnly, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes).ToList

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                       UserCode As String, IncludeOfficeClientDivision As Boolean, ByVal ActiveOnly As Boolean,
                                                       AccessibleOfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadByUserCode(DbContext, SecurityDbContext, UserCode, IncludeOfficeClientDivision, ActiveOnly), AccessibleOfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadByUserCodeObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                       ByVal UserCode As String, ByVal IncludeOfficeClientDivision As Boolean, Optional ByVal ActiveOnly As Boolean = False) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            Try

                UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList

                If UserClientDivisionProductAccess.Count > 0 Then

                    If IncludeOfficeClientDivision Then

                        LoadByUserCodeObject = (From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division").ToList
                                                Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Product.ClientCode AndAlso UserCDP.DivisionCode = Product.DivisionCode AndAlso UserCDP.ProductCode = Product.Code) = True
                                                Select Product)

                    Else

                        LoadByUserCodeObject = (From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).ToList
                                                Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Product.ClientCode AndAlso UserCDP.DivisionCode = Product.DivisionCode AndAlso UserCDP.ProductCode = Product.Code) = True
                                                Select Product)

                    End If

                Else

                    If IncludeOfficeClientDivision Then

                        LoadByUserCodeObject = (From Product In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division")
                                                Select Product)

                    Else

                        LoadByUserCodeObject = (From Product In DbContext.GetQuery(Of Database.Entities.Product)
                                                Select Product)

                    End If

                End If

                If ActiveOnly Then

                    LoadByUserCodeObject = LoadByUserCodeObject.Where(Function(Product) Product.IsActive.GetValueOrDefault(0) = 1)

                End If

            Catch ex As Exception
                LoadByUserCodeObject = Nothing
            End Try

        End Function
        Public Function LoadByBatchName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadByBatchName = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                              Where Product.BatchName = BatchName
                              Select Product

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As AdvantageFramework.Database.Entities.Product

            Try

                LoadByClientAndDivisionAndProductCode = (From Product In DbContext.GetQuery(Of Database.Entities.Product)
                                                         Where Product.ClientCode = ClientCode AndAlso
                                                               Product.DivisionCode = DivisionCode AndAlso
                                                               Product.Code = ProductCode
                                                         Select Product).SingleOrDefault
            Catch ex As Exception
                LoadByClientAndDivisionAndProductCode = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadByClientAndDivisionCode = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                                          Where Product.ClientCode = ClientCode AndAlso
                                                Product.DivisionCode = DivisionCode
                                          Select Product

        End Function
        Public Function LoadByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadByClientCode = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                               Where Product.ClientCode = ClientCode
                               Select Product

        End Function
        Public Function LoadAllActiveByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadAllActiveByUserCode = LoadByUserCode(DbContext, SecurityDbContext, UserCode, False, True)

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            LoadAllActive = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                            Where Product.IsActive = 1
                            Select Product

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product)

            Load = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                   Select Product

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Product As AdvantageFramework.Database.Entities.Product) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Products.Add(Product)

                ErrorText = Product.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Product As AdvantageFramework.Database.Entities.Product) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Product)

                ErrorText = Product.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Product As AdvantageFramework.Database.Entities.Product) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.PRODUCT WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'", Product.ClientCode, Product.DivisionCode, Product.Code))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then
                        ' delete sort keys
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM PRD_SRT_KEY WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'",
                                                                        Product.ClientCode,
                                                                        Product.DivisionCode,
                                                                        Product.Code))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM SEC_CLIENT WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'",
                                                                        Product.ClientCode,
                                                                        Product.DivisionCode,
                                                                        Product.Code))

                        CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code)

                        If CompanyProfile IsNot Nothing Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM COMPANY_PROFILE_AFFILIATION WHERE COMPANY_PROFILE_ID = {0}", CompanyProfile.ID))
                            DbContext.DeleteEntityObject(CompanyProfile)
                            DbContext.SaveChanges()

                        End If

                        Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code)

                        If Activity IsNot Nothing Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ACTIVITY_COMPETITION WHERE ACTIVITY_ID = {0}", Activity.ID))
                            DbContext.DeleteEntityObject(Activity)
                            DbContext.SaveChanges()

                        End If

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
        Public Function Copy(ByVal ProductToCopy As AdvantageFramework.Database.Entities.Product) As AdvantageFramework.Database.Entities.Product

            Dim Product As AdvantageFramework.Database.Entities.Product

            Try

                Product = New AdvantageFramework.Database.Entities.Product

                Product.ClientCode = ProductToCopy.ClientCode
                Product.DivisionCode = ProductToCopy.DivisionCode
                Product.Code = ProductToCopy.Code
                Product.Name = ProductToCopy.Name
                Product.OfficeCode = ProductToCopy.OfficeCode
                Product.IsActive = ProductToCopy.IsActive
                Product.BillingAddress = ProductToCopy.BillingAddress
                Product.BillingAddress2 = ProductToCopy.BillingAddress2
                Product.BillingCity = ProductToCopy.BillingCity
                Product.BillingCounty = ProductToCopy.BillingCounty
                Product.BillingState = ProductToCopy.BillingState
                Product.BillingZip = ProductToCopy.BillingZip
                Product.BillingCountry = ProductToCopy.BillingCountry
                Product.BillingPhone = ProductToCopy.BillingPhone
                Product.BillingPhoneExtension = ProductToCopy.BillingPhoneExtension
                Product.BillingFax = ProductToCopy.BillingFax
                Product.BillingFaxExtension = ProductToCopy.BillingFaxExtension
                Product.StatementAddress = ProductToCopy.StatementAddress
                Product.StatementAddress2 = ProductToCopy.StatementAddress2
                Product.StatementCity = ProductToCopy.StatementCity
                Product.StatementCounty = ProductToCopy.StatementCounty
                Product.StatementState = ProductToCopy.StatementState
                Product.StatementZip = ProductToCopy.StatementZip
                Product.StatementCountry = ProductToCopy.StatementCountry
                Product.StatementPhone = ProductToCopy.StatementPhone
                Product.StatementPhoneExtension = ProductToCopy.StatementPhoneExtension
                Product.StatementFax = ProductToCopy.StatementFax
                Product.StatementFaxExtension = ProductToCopy.StatementFaxExtension
                Product.UserDefinedField1 = ProductToCopy.UserDefinedField1
                Product.UserDefinedField2 = ProductToCopy.UserDefinedField2
                Product.UserDefinedField3 = ProductToCopy.UserDefinedField3
                Product.UserDefinedField4 = ProductToCopy.UserDefinedField4
                Product.SortName = ProductToCopy.SortName
                Product.AttentionTo = ProductToCopy.AttentionTo
                Product.IsActive = ProductToCopy.IsActive
                Product.RadioMarkup = ProductToCopy.RadioMarkup
                Product.RadioRebate = ProductToCopy.RadioRebate
                Product.RadioBillNet = ProductToCopy.RadioBillNet
                Product.RadioCommissionOnly = ProductToCopy.RadioCommissionOnly
                Product.RadioPrePostBill = ProductToCopy.RadioPrePostBill
                Product.RadioDaysToBill = ProductToCopy.RadioDaysToBill
                Product.RadioBillSetting = ProductToCopy.RadioBillSetting
                Product.RadioVendorDiscounts = ProductToCopy.RadioVendorDiscounts
                Product.RadioBillingSetupComplete = ProductToCopy.RadioBillingSetupComplete
                Product.RadioApplyTaxUseFlags = ProductToCopy.RadioApplyTaxUseFlags
                Product.RadioApplyTaxLineNet = ProductToCopy.RadioApplyTaxLineNet
                Product.RadioApplyTaxNetCharge = ProductToCopy.RadioApplyTaxNetCharge
                Product.RadioApplyTaxAddlCharge = ProductToCopy.RadioApplyTaxAddlCharge
                Product.RadioApplyTaxCommission = ProductToCopy.RadioApplyTaxCommission
                Product.RadioApplyTaxRebate = ProductToCopy.RadioApplyTaxRebate
                Product.RadioApplyTaxNetDiscount = ProductToCopy.RadioApplyTaxNetDiscount
                Product.TelevisionMarkup = ProductToCopy.TelevisionMarkup
                Product.TelevisionRebate = ProductToCopy.TelevisionRebate
                Product.TelevisionBillNet = ProductToCopy.TelevisionBillNet
                Product.TelevisionCommissionOnly = ProductToCopy.TelevisionCommissionOnly
                Product.TelevisionPrePostBill = ProductToCopy.TelevisionPrePostBill
                Product.TelevisionDaysToBill = ProductToCopy.TelevisionDaysToBill
                Product.TelevisionBillSetting = ProductToCopy.TelevisionBillSetting
                Product.TelevisionVendorDiscounts = ProductToCopy.TelevisionVendorDiscounts
                Product.TelevisionBillingSetupComplete = ProductToCopy.TelevisionBillingSetupComplete
                Product.TelevisionApplyTaxUseFlags = ProductToCopy.TelevisionApplyTaxUseFlags
                Product.TelevisionApplyTaxLineNet = ProductToCopy.TelevisionApplyTaxLineNet
                Product.TelevisionApplyTaxNetCharge = ProductToCopy.TelevisionApplyTaxNetCharge
                Product.TelevisionApplyTaxAddlCharge = ProductToCopy.TelevisionApplyTaxAddlCharge
                Product.TelevisionApplyTaxCommission = ProductToCopy.TelevisionApplyTaxCommission
                Product.TelevisionApplyTaxRebate = ProductToCopy.TelevisionApplyTaxRebate
                Product.TelevisionApplyTaxNetDiscount = ProductToCopy.TelevisionApplyTaxNetDiscount
                Product.MagazineMarkup = ProductToCopy.MagazineMarkup
                Product.MagazineRebate = ProductToCopy.MagazineRebate
                Product.MagazineBillNet = ProductToCopy.MagazineBillNet
                Product.MagazineCommissionOnly = ProductToCopy.MagazineCommissionOnly
                Product.MagazinePrePostBill = ProductToCopy.MagazinePrePostBill
                Product.MagazineDaysToBill = ProductToCopy.MagazineDaysToBill
                Product.MagazineBillSetting = ProductToCopy.MagazineBillSetting
                Product.MagazineVendorDiscounts = ProductToCopy.MagazineVendorDiscounts
                Product.MagazineBillingSetupComplete = ProductToCopy.MagazineBillingSetupComplete
                Product.MagazineApplyTaxUseFlags = ProductToCopy.MagazineApplyTaxUseFlags
                Product.MagazineApplyTaxLineNet = ProductToCopy.MagazineApplyTaxLineNet
                Product.MagazineApplyTaxNetCharge = ProductToCopy.MagazineApplyTaxNetCharge
                Product.MagazineApplyTaxAddlCharge = ProductToCopy.MagazineApplyTaxAddlCharge
                Product.MagazineApplyTaxCommission = ProductToCopy.MagazineApplyTaxCommission
                Product.MagazineApplyTaxRebate = ProductToCopy.MagazineApplyTaxRebate
                Product.MagazineApplyTaxNetDiscount = ProductToCopy.MagazineApplyTaxNetDiscount
                Product.NewspaperMarkup = ProductToCopy.NewspaperMarkup
                Product.NewspaperRebate = ProductToCopy.NewspaperRebate
                Product.NewspaperBillNet = ProductToCopy.NewspaperBillNet
                Product.NewspaperCommissionOnly = ProductToCopy.NewspaperCommissionOnly
                Product.NewspaperPrePostBill = ProductToCopy.NewspaperPrePostBill
                Product.NewspaperDaysToBill = ProductToCopy.NewspaperDaysToBill
                Product.NewspaperBillSetting = ProductToCopy.NewspaperBillSetting
                Product.NewspaperVendorDiscounts = ProductToCopy.NewspaperVendorDiscounts
                Product.NewspaperBillingSetupComplete = ProductToCopy.NewspaperBillingSetupComplete
                Product.NewspaperApplyTaxUseFlags = ProductToCopy.NewspaperApplyTaxUseFlags
                Product.NewspaperApplyTaxLineNet = ProductToCopy.NewspaperApplyTaxLineNet
                Product.NewspaperApplyTaxNetCharge = ProductToCopy.NewspaperApplyTaxNetCharge
                Product.NewspaperApplyTaxAddlCharge = ProductToCopy.NewspaperApplyTaxAddlCharge
                Product.NewspaperApplyTaxCommission = ProductToCopy.NewspaperApplyTaxCommission
                Product.NewspaperApplyTaxRebate = ProductToCopy.NewspaperApplyTaxRebate
                Product.NewspaperApplyTaxNetDiscount = ProductToCopy.NewspaperApplyTaxNetDiscount
                Product.InternetMarkup = ProductToCopy.InternetMarkup
                Product.InternetRebate = ProductToCopy.InternetRebate
                Product.InternetBillNet = ProductToCopy.InternetBillNet
                Product.InternetCommissionOnly = ProductToCopy.InternetCommissionOnly
                Product.InternetPrePostBill = ProductToCopy.InternetPrePostBill
                Product.InternetDaysToBill = ProductToCopy.InternetDaysToBill
                Product.InternetBillSetting = ProductToCopy.InternetBillSetting
                Product.InternetVendorDiscounts = ProductToCopy.InternetVendorDiscounts
                Product.InternetBillingSetupComplete = ProductToCopy.InternetBillingSetupComplete
                Product.InternetApplyTaxUseFlags = ProductToCopy.InternetApplyTaxUseFlags
                Product.InternetApplyTaxLineNet = ProductToCopy.InternetApplyTaxLineNet
                Product.InternetApplyTaxNetCharge = ProductToCopy.InternetApplyTaxNetCharge
                Product.InternetApplyTaxAddlCharge = ProductToCopy.InternetApplyTaxAddlCharge
                Product.InternetApplyTaxCommission = ProductToCopy.InternetApplyTaxCommission
                Product.InternetApplyTaxRebate = ProductToCopy.InternetApplyTaxRebate
                Product.InternetApplyTaxNetDiscount = ProductToCopy.InternetApplyTaxNetDiscount
                Product.OutOfHomeMarkup = ProductToCopy.OutOfHomeMarkup
                Product.OutOfHomeRebate = ProductToCopy.OutOfHomeRebate
                Product.OutOfHomeBillNet = ProductToCopy.OutOfHomeBillNet
                Product.OutOfHomeCommissionOnly = ProductToCopy.OutOfHomeCommissionOnly
                Product.OutOfHomePrePostBill = ProductToCopy.OutOfHomePrePostBill
                Product.OutOfHomeDaysToBill = ProductToCopy.OutOfHomeDaysToBill
                Product.OutOfHomeBillSetting = ProductToCopy.OutOfHomeBillSetting
                Product.OutOfHomeVendorDiscounts = ProductToCopy.OutOfHomeVendorDiscounts
                Product.OutOfHomeBillingSetupComplete = ProductToCopy.OutOfHomeBillingSetupComplete
                Product.OutOfHomeApplyTaxUseFlags = ProductToCopy.OutOfHomeApplyTaxUseFlags
                Product.OutOfHomeApplyTaxLineNet = ProductToCopy.OutOfHomeApplyTaxLineNet
                Product.OutOfHomeApplyTaxNetCharge = ProductToCopy.OutOfHomeApplyTaxNetCharge
                Product.OutOfHomeApplyTaxAddlCharge = ProductToCopy.OutOfHomeApplyTaxAddlCharge
                Product.OutOfHomeApplyTaxCommission = ProductToCopy.OutOfHomeApplyTaxCommission
                Product.OutOfHomeApplyTaxRebate = ProductToCopy.OutOfHomeApplyTaxRebate
                Product.OutOfHomeApplyTaxNetDiscount = ProductToCopy.OutOfHomeApplyTaxNetDiscount
                Product.ProductionContingency = ProductToCopy.ProductionContingency
                Product.ProductionMarkup = ProductToCopy.ProductionMarkup
                Product.ProductionEmployeeTimeBillingRate = ProductToCopy.ProductionEmployeeTimeBillingRate
                Product.ProductionUseEstimateBillingRate = ProductToCopy.ProductionUseEstimateBillingRate
                Product.ProductionConsolidateFunctions = ProductToCopy.ProductionConsolidateFunctions
                Product.ProductionBillNet = ProductToCopy.ProductionBillNet
                Product.ProductionVendorDiscounts = ProductToCopy.ProductionVendorDiscounts
                Product.ProductionApprovedEstimatedRequired = ProductToCopy.ProductionApprovedEstimatedRequired
                Product.ProductionBillingSetupComplete = ProductToCopy.ProductionBillingSetupComplete
                Product.ProductionTaxCode = ProductToCopy.ProductionTaxCode
                Product.RadioTaxCode = ProductToCopy.RadioTaxCode
                Product.InternetTaxCode = ProductToCopy.InternetTaxCode
                Product.MagazineTaxCode = ProductToCopy.MagazineTaxCode
                Product.NewspaperTaxCode = ProductToCopy.NewspaperTaxCode
                Product.OutOfHomeTaxCode = ProductToCopy.OutOfHomeTaxCode
                Product.TelevisionTaxCode = ProductToCopy.TelevisionTaxCode
                Product.ProductionEmployeeTimeBillable = ProductToCopy.ProductionEmployeeTimeBillable
                Product.CurrencyCode = ProductToCopy.CurrencyCode

                Copy = Product

            Catch ex As Exception
                Copy = Nothing
            End Try

        End Function
        Public Function CreateFromClient(ByVal Client As AdvantageFramework.Database.Entities.Client) As AdvantageFramework.Database.Entities.Product

            Dim Product As AdvantageFramework.Database.Entities.Product

            Try

                Product = New AdvantageFramework.Database.Entities.Product

                Product.ClientCode = Client.Code
                Product.DivisionCode = Client.Code
                Product.Code = Client.Code
                Product.Name = Client.Name
                Product.BillingAddress = Client.BillingAddress
                Product.BillingAddress2 = Client.BillingAddress2
                Product.BillingCity = Client.BillingCity
                Product.BillingCounty = Client.BillingCounty
                Product.BillingState = Client.BillingState
                Product.BillingZip = Client.BillingZip
                Product.BillingCountry = Client.BillingCountry
                Product.StatementAddress = Client.StatementAddress
                Product.StatementAddress2 = Client.StatementAddress2
                Product.StatementCity = Client.StatementCity
                Product.StatementCounty = Client.StatementCounty
                Product.StatementState = Client.StatementState
                Product.StatementZip = Client.StatementZip
                Product.StatementCountry = Client.StatementCountry
                Product.SortName = Client.SortName
                Product.IsActive = Client.IsActive

                CreateFromClient = Product

            Catch ex As Exception
                CreateFromClient = Nothing
            End Try

        End Function
        Public Function CreateFromDivision(ByVal Division As AdvantageFramework.Database.Entities.Division) As AdvantageFramework.Database.Entities.Product

            Dim Product As AdvantageFramework.Database.Entities.Product

            Try

                Product = New AdvantageFramework.Database.Entities.Product

                Product.ClientCode = Division.ClientCode
                Product.DivisionCode = Division.Code
                Product.Code = Division.Code
                Product.Name = Division.Name
                Product.BillingAddress = Division.BillingAddress
                Product.BillingAddress2 = Division.BillingAddress2
                Product.BillingCity = Division.BillingCity
                Product.BillingCounty = Division.BillingCounty
                Product.BillingState = Division.BillingState
                Product.BillingZip = Division.BillingZip
                Product.BillingCountry = Division.BillingCountry
                Product.StatementAddress = Division.Address
                Product.StatementAddress2 = Division.Address2
                Product.StatementCity = Division.City
                Product.StatementCounty = Division.County
                Product.StatementState = Division.State
                Product.StatementZip = Division.Zip
                Product.StatementCountry = Division.Country
                Product.SortName = Division.SortName
                Product.IsActive = Division.IsActive

                CreateFromDivision = Product

            Catch ex As Exception
                CreateFromDivision = Nothing
            End Try

        End Function
        Public Function BuildClientDivisionProductDisplay(ByVal ClientName As String, ByVal DivisionName As String, ByVal ProductDescription As String) As String

            Dim ClientDivisionProductDisplay As String = String.Empty
            Dim ShowProduct As Boolean = False
            Dim ShowDivision As Boolean = False

            If String.IsNullOrWhiteSpace(ClientName) = False Then

                ClientDivisionProductDisplay = ClientName

                If String.IsNullOrWhiteSpace(ProductDescription) = False AndAlso ProductDescription <> DivisionName Then

                    ShowProduct = True

                End If
                If String.IsNullOrWhiteSpace(DivisionName) = False AndAlso DivisionName <> ClientName Then

                    ShowDivision = True

                End If
                If ShowProduct = True OrElse ShowDivision = True Then

                    ClientDivisionProductDisplay &= "/" & DivisionName

                End If
                If ShowProduct = True Then

                    ClientDivisionProductDisplay &= "/" & ProductDescription

                End If

            End If

            Return ClientDivisionProductDisplay

        End Function

#End Region

    End Module

End Namespace
