Namespace Database.Procedures.MediaBroadcastWorksheetMarketDetailSubmarketDemo

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

        Public Function LoadBySubmarketIDDetailIDMediaDemographicID(ByVal DbContext As Database.DbContext, MediaBroadcastWorksheetMarketSubmarketID As Integer, MediaBroadcastWorksheetMarketDetailID As Integer, MediaDemographicID As Integer) As Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo

            LoadBySubmarketIDDetailIDMediaDemographicID = (From MediaBroadcastWorksheetMarketDetailSubmarketDemo In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)
                                                           Where MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketSubmarketID = MediaBroadcastWorksheetMarketSubmarketID AndAlso
                                                                 MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID AndAlso
                                                                 MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaDemographicID = MediaDemographicID
                                                           Select MediaBroadcastWorksheetMarketDetailSubmarketDemo).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)

            Load = From MediaBroadcastWorksheetMarketDetailSubmarketDemo In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)
                   Select MediaBroadcastWorksheetMarketDetailSubmarketDemo

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetMarketDetailSubmarketDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaBroadcastWorksheetMarketDetailSubmarketDemos.Add(MediaBroadcastWorksheetMarketDetailSubmarketDemo)

                ErrorText = MediaBroadcastWorksheetMarketDetailSubmarketDemo.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetMarketDetailSubmarketDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaBroadcastWorksheetMarketDetailSubmarketDemo)

                ErrorText = MediaBroadcastWorksheetMarketDetailSubmarketDemo.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
