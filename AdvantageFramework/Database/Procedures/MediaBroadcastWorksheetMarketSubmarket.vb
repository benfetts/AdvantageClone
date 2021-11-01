Namespace Database.Procedures.MediaBroadcastWorksheetMarketSubmarket

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

        Public Function LoadByMediaBroadcastWorksheetMarketIDMarketCode(ByVal DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer, MarketCode As String) As Database.Entities.MediaBroadcastWorksheetMarketSubmarket

            LoadByMediaBroadcastWorksheetMarketIDMarketCode = (From MediaBroadcastWorksheetMarketSubmarket In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketSubmarket)
                                                               Where MediaBroadcastWorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID AndAlso
                                                                     MediaBroadcastWorksheetMarketSubmarket.MarketCode = MarketCode
                                                               Select MediaBroadcastWorksheetMarketSubmarket).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketSubmarket)

            Load = From MediaBroadcastWorksheetMarketSubmarket In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketSubmarket)
                   Select MediaBroadcastWorksheetMarketSubmarket

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetMarketSubmarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketSubmarket) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaBroadcastWorksheetMarketSubmarkets.Add(MediaBroadcastWorksheetMarketSubmarket)

                ErrorText = MediaBroadcastWorksheetMarketSubmarket.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        MediaBroadcastWorksheetMarketSubmarket.Order = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketSubmarket.Load(DbContext)
                                                                        Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID
                                                                        Select Entity.Order).Max + 1

                    Catch ex As Exception
                        MediaBroadcastWorksheetMarketSubmarket.Order = 0
                    End Try

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
