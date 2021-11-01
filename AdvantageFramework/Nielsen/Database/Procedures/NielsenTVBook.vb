Namespace Nielsen.Database.Procedures.NielsenTVBook

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext) As Integer

            Try

                GetMaxID = (From NielsenTVBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVBook)
                            Select NielsenTVBook.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
		Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenTVBook

			Try

				LoadByID = (From NielsenTVBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVBook)
							Where NielsenTVBook.ID = ID
							Select NielsenTVBook).SingleOrDefault

			Catch ex As Exception
				LoadByID = Nothing
			End Try

		End Function
		Public Function LoadByBookIDs(DbContext As Database.DbContext, BookIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVBook)

			LoadByBookIDs = From NielsenTVBook In DbContext.GetQuery(Of Database.Entities.NielsenTVBook)
							Where BookIDs.Contains(NielsenTVBook.ID)
							Select NielsenTVBook

		End Function
        Public Function LoadValidatedByNielsenMarketNumberAndBookIDs(DbContext As Database.DbContext, NielsenMarketNumber As Integer, BookIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVBook)

            LoadValidatedByNielsenMarketNumberAndBookIDs = From NielsenTVBook In DbContext.GetQuery(Of Database.Entities.NielsenTVBook)
                                                           Where NielsenTVBook.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                                 BookIDs.Contains(NielsenTVBook.ID) AndAlso
                                                                 NielsenTVBook.Validated = True
                                                           Select NielsenTVBook

        End Function
        Public Function LoadValidatedByNielsenMarketNumber(DbContext As Database.DbContext, NielsenMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVBook)

            LoadValidatedByNielsenMarketNumber = From NielsenTVBook In DbContext.GetQuery(Of Database.Entities.NielsenTVBook)
                                                 Where NielsenTVBook.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                       NielsenTVBook.Validated = True
                                                 Select NielsenTVBook

        End Function
        Public Function GetValidatedCount(DbContext As Nielsen.Database.DbContext) As Integer

            GetValidatedCount = (From NielsenTVBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVBook)
                                 Where NielsenTVBook.Validated = True
                                 Select NielsenTVBook).Count

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVBook)

            Load = From NielsenTVBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVBook)
                   Select NielsenTVBook

        End Function
        Public Function LoadValidated(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVBook)

            LoadValidated = From NielsenTVBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVBook)
                            Where NielsenTVBook.Validated = True
                            Select NielsenTVBook

        End Function
        Public Function LoadValidatedNonImpact(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVBook)

            Dim ImpactCollectionMethods As IEnumerable(Of String) = {"5", "7", "8", "9", "10", "11", "12", "13"}

            LoadValidatedNonImpact = From NielsenTVBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVBook)
                                     Where NielsenTVBook.Validated = True AndAlso
                                           ImpactCollectionMethods.Contains(NielsenTVBook.CollectionMethod) = False
                                     Select NielsenTVBook

        End Function

#End Region

    End Module

End Namespace
