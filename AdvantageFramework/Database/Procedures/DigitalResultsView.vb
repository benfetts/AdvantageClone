Namespace Database.Procedures.DigitalResultsView

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

        Public Function LoadByDateRange(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DateFrom As Date, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DigitalResultsView)

            'objects
            Dim ModifiedEndDate As Date = Nothing

            ModifiedEndDate = EndDate.Date.AddDays(1).AddSeconds(-1)

            LoadByDateRange = From DigitalResult In DbContext.GetQuery(Of Database.Entities.DigitalResultsView)
                              Where DigitalResult.StartDate >= DateFrom AndAlso
                                    DigitalResult.StartDate <= ModifiedEndDate
                              Select DigitalResult

        End Function

#End Region

    End Module

End Namespace
