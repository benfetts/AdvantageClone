Namespace Database.Procedures.MediaMetric

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

        Public Function LoadForRadioAudienceComposition(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaMetric)

            LoadForRadioAudienceComposition = From MediaMetric In DbContext.GetQuery(Of Database.Entities.MediaMetric)
                                              Where MediaMetric.ID = Entities.Methods.MediaMetricID.AQH OrElse
                                                    MediaMetric.ID = Entities.Methods.MediaMetricID.Cume OrElse
                                                    MediaMetric.ID = Entities.Methods.MediaMetricID.ExclusiveCume
                                              Select MediaMetric

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaMetric)

            Load = From MediaMetric In DbContext.GetQuery(Of Database.Entities.MediaMetric)
                   Select MediaMetric

        End Function

#End Region

    End Module

End Namespace
