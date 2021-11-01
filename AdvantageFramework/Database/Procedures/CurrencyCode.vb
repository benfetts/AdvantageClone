Namespace Database.Procedures.CurrencyCode

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

        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As Database.Entities.CurrencyCode

            Try

                LoadByCode = (From CurrencyCode In DbContext.GetQuery(Of Database.Entities.CurrencyCode)
                              Where CurrencyCode.Code = Code
                              Select CurrencyCode).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveMultiCurrency(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CurrencyCode)

            Dim CurrencyList As IEnumerable(Of String) = Nothing

            CurrencyList = (From Currency In AdvantageFramework.Database.Procedures.Currency.LoadAllActive(DbContext)
                            Select Currency.CurrencyCode).ToArray

            LoadAllActiveMultiCurrency = From CurrencyCode In DbContext.GetQuery(Of Database.Entities.CurrencyCode)
                                         Where (CurrencyCode.IsInactive Is Nothing OrElse
                                               CurrencyCode.IsInactive = 0) AndAlso
                                               CurrencyList.Contains(CurrencyCode.Code)
                                         Select CurrencyCode

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CurrencyCode)


            LoadAllActive = From CurrencyCode In DbContext.GetQuery(Of Database.Entities.CurrencyCode)
                            Where CurrencyCode.IsInactive Is Nothing OrElse
                                  CurrencyCode.IsInactive = 0
                            Select CurrencyCode

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CurrencyCode)

            Load = From CurrencyCode In DbContext.GetQuery(Of Database.Entities.CurrencyCode)
                   Select CurrencyCode

        End Function

#End Region

    End Module

End Namespace

