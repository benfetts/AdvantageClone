Namespace Database.Procedures.Currency

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

        Public Function LoadByCurrencyCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CurrencyCode As String) As AdvantageFramework.Database.Entities.Currency

            Try

                LoadByCurrencyCode = (From Currency In DbContext.GetQuery(Of Database.Entities.Currency)
                                      Where Currency.CurrencyCode = CurrencyCode
                                      Select Currency).SingleOrDefault

            Catch ex As Exception
                LoadByCurrencyCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Currency)

            LoadAllActive = From Currency In DbContext.GetQuery(Of Database.Entities.Currency)
                            Where Currency.IsInactive Is Nothing OrElse
                                  Currency.IsInactive = 0
                            Select Currency

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Currency)

            Load = From Currency In DbContext.GetQuery(Of Database.Entities.Currency)
                   Select Currency

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Currency As AdvantageFramework.Database.Entities.Currency) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Currencies.Add(Currency)

                ErrorText = Currency.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Currency As AdvantageFramework.Database.Entities.Currency) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Currency)

                ErrorText = Currency.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Currency As AdvantageFramework.Database.Entities.Currency) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) AndAlso AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext) = Currency.CurrencyCode Then

                    IsValid = False

                End If

                If IsValid Then

                    Try

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[CURRENCY_DETAIL] WHERE CURRENCY_CODE = '{0}'", Currency.CurrencyCode))

                        DbContext.DeleteEntityObject(Currency)

                        DbContext.SaveChanges()

                        DbTransaction.Commit()

                        Deleted = True

                    Catch ex As Exception
                        DbTransaction.Rollback()
                        ErrorText = ex.Message
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
