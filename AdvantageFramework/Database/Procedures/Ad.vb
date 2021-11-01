Namespace Database.Procedures.Ad

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, DbContext.Ads, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Ads As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Ad), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            LoadWithOfficeLimits = From Ad In Ads.Include("Client").Include("Client.Products")
                                   Where (HasLimitedOfficeCodes = False OrElse
                                          Ad.ClientCode = Nothing OrElse
                                          Ad.Client.Products.Any(Function(prd) OfficeCodes.Contains(prd.OfficeCode)))
                                   Select Ad Distinct

        End Function
        Public Function LoadAllActiveByClientCodeAndNotExpired(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As System.Collections.Generic.List(Of Database.Entities.Ad)

            LoadAllActiveByClientCodeAndNotExpired = (From Ad In LoadAllActiveByClientCode(DbContext, ClientCode).ToList
                                                      Where Ad.ExpirationDate Is Nothing OrElse
                                                            CDate(Ad.ExpirationDate.Value.ToShortDateString) >= CDate(Now.ToShortDateString)
                                                      Select Ad).ToList

        End Function
        Public Function LoadAllActiveByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            LoadAllActiveByClientCode = From Ad In LoadAllActive(DbContext)
                                        Where Ad.ClientCode = ClientCode OrElse
                                              Ad.ClientCode Is Nothing
                                        Select Ad

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            LoadAllActive = From Ad In DbContext.GetQuery(Of Database.Entities.Ad)
                            Where Ad.IsInactive = 1
                            Select Ad

        End Function
        Public Function LoadByAdNumber(ByVal DbContext As Database.DbContext, ByVal AdNumber As String) As Database.Entities.Ad

            Try

                LoadByAdNumber = (From Ad In DbContext.GetQuery(Of Database.Entities.Ad)
                                  Where Ad.Number.ToUpper = AdNumber.ToUpper
                                  Select Ad).SingleOrDefault

            Catch ex As Exception
                LoadByAdNumber = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            LoadByClientCode = From Ad In DbContext.GetQuery(Of Database.Entities.Ad)
                               Where Ad.ClientCode = ClientCode OrElse
                                     Ad.ClientCode Is Nothing
                               Select Ad

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Ad)

            Load = From Ad In DbContext.GetQuery(Of Database.Entities.Ad)
                   Select Ad

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Ad As AdvantageFramework.Database.Entities.Ad) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Ads.Add(Ad)

                ErrorText = Ad.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Ad As AdvantageFramework.Database.Entities.Ad) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Ad)

                ErrorText = Ad.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Ad As AdvantageFramework.Database.Entities.Ad) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = (AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Where(Function(JobComp) JobComp.AdNumber = Ad.Number).Count = 0)

                If IsValid Then

                    DbContext.DeleteEntityObject(Ad)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("The ad is in use and cannot be deleted.")

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByAdNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdNumber As String) As Boolean

            'objects
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            Ad = DbContext.Ads.Find(AdNumber)

            If Ad IsNot Nothing Then

                DeleteByAdNumber = Delete(DbContext, Ad)

            Else

                DeleteByAdNumber = True

            End If

        End Function

#End Region

    End Module

End Namespace
