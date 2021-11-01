Namespace Database.Procedures.Market

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

        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal MarketCode As String) As Database.Entities.Market

            Try

                LoadByCode = (From Market In DbContext.GetQuery(Of Database.Entities.Market)
                              Where Market.Code = MarketCode
                              Select Market).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveComscore(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadAllActiveComscore = From Market In LoadAllActive(DbContext)
                                    Where Market.ComscoreNewMarketNumber IsNot Nothing
                                    Select Market

        End Function
        Public Function LoadAllActiveComscore(DbContext As Database.DbContext, ComscoreMarketNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadAllActiveComscore = From Market In LoadAllActive(DbContext)
                                    Where Market.ComscoreNewMarketNumber IsNot Nothing AndAlso
                                          ComscoreMarketNumbers.Contains(Market.ComscoreNewMarketNumber)
                                    Select Market

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadAllActive = From Market In DbContext.GetQuery(Of Database.Entities.Market)
                            Where Market.IsInactive = 0 OrElse
                                  Market.IsInactive Is Nothing
                            Select Market

        End Function
        Public Function LoadAllActiveSpotRadio(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadAllActiveSpotRadio = From Market In LoadAllActive(DbContext)
                                     Where Market.NielsenRadioCode IsNot Nothing AndAlso
                                           Market.NielsenRadioCode <> "" AndAlso
                                           Market.IsCable = False
                                     Select Market

        End Function
        Public Function LoadAllActiveSpotTV(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadAllActiveSpotTV = From Market In LoadAllActive(DbContext)
                                  Where Market.NielsenTVCode IsNot Nothing AndAlso
                                        Market.NielsenTVCode <> ""
                                  Select Market

        End Function
        Public Function LoadAllActiveEastlanRadio(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadAllActiveEastlanRadio = From Market In LoadAllActive(DbContext)
                                        Where Market.EastlanRadioCode IsNot Nothing AndAlso
                                              Market.IsCable = False
                                        Select Market

        End Function
        Public Function IsMarketCanadian(DbContext As Database.DbContext, MarketCode As String) As Boolean

            Dim MarketIsCanadian As Boolean = False

            MarketIsCanadian = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MARKET WHERE MARKET_CODE = '{0}' AND COUNTRY_ID = 2", MarketCode)).FirstOrDefault > 0)

            IsMarketCanadian = MarketIsCanadian

        End Function
        Public Function IsMarketSetAsAllCanada(DbContext As Database.DbContext, MarketCode As String) As Boolean

            Dim MarketIsSetAsAllCanada As Boolean = False

            MarketIsSetAsAllCanada = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MARKET WHERE MARKET_CODE = '{0}' AND COUNTRY_ID = 2 AND IS_ALL_CANADA = 1", MarketCode)).FirstOrDefault > 0)

            IsMarketSetAsAllCanada = MarketIsSetAsAllCanada

        End Function
        Public Function LoadByCountryID(DbContext As Database.DbContext, CountryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            LoadByCountryID = From Market In DbContext.GetQuery(Of Database.Entities.Market)
                              Where Market.CountryID = CountryID
                              Select Market

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Market)

            Load = From Market In DbContext.GetQuery(Of Database.Entities.Market)
                   Select Market

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Market As AdvantageFramework.Database.Entities.Market) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Markets.Add(Market)

                ErrorText = Market.ValidateEntity(IsValid)

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
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, Market As AdvantageFramework.Database.Entities.Market,
                                ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Markets.Add(Market)

                ErrorText = Market.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Market As AdvantageFramework.Database.Entities.Market) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'fix for legacy apps
                If Market.IsInactive.GetValueOrDefault(0) = 0 Then

                    Market.IsInactive = Nothing

                End If

                DbContext.UpdateObject(Market)

                ErrorText = Market.ValidateEntity(IsValid)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, Market As AdvantageFramework.Database.Entities.Market,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                'fix for legacy apps
                If Market.IsInactive.GetValueOrDefault(0) = 0 Then

                    Market.IsInactive = Nothing

                End If

                DbContext.UpdateObject(Market)

                ErrorText = Market.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Market As AdvantageFramework.Database.Entities.Market) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(Market)

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
