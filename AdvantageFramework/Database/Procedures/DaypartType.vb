Namespace Database.Procedures.DaypartType

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DaypartType)

            LoadAllActive = From DaypartType In DbContext.GetQuery(Of Database.Entities.DaypartType)
                            Where DaypartType.IsInactive = False
                            Select DaypartType

        End Function
        Public Function LoadByDaypartTypeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DaypartTypeID As Integer) As AdvantageFramework.Database.Entities.DaypartType

            Try

                LoadByDaypartTypeID = (From DaypartType In DbContext.GetQuery(Of Database.Entities.DaypartType)
                                       Where DaypartType.ID = DaypartTypeID
                                       Select DaypartType).SingleOrDefault

            Catch ex As Exception
                LoadByDaypartTypeID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DaypartType)

            Load = From DaypartType In DbContext.GetQuery(Of Database.Entities.DaypartType)
                   Select DaypartType

        End Function

#End Region

    End Module

End Namespace
