Namespace Database.Procedures.MagazineDetailView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.MagazineDetail)

            Load = From MagazineDetail In DbContext.GetQuery(Of Database.Views.MagazineDetail)
                   Select MagazineDetail

        End Function
        Public Function LoadNonCancelledNonCommissionByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.MagazineDetail)

            Dim CommissionOnlyLineNumbers As IEnumerable(Of Short) = Nothing

            CommissionOnlyLineNumbers = AdvantageFramework.Database.Procedures.MagazineOrderDetail.LoadCommissionOnlyByOrderNumber(DbContext, OrderNumber)

            LoadNonCancelledNonCommissionByOrderNumber = From MagazineDetail In DbContext.GetQuery(Of Database.Views.MagazineDetail)
                                                         Where MagazineDetail.OrderNumber = OrderNumber AndAlso
                                                               MagazineDetail.IsActiveRevision = 1 AndAlso
                                                               (MagazineDetail.IsLineCancelled Is Nothing OrElse
                                                                MagazineDetail.IsLineCancelled = 0) AndAlso
                                                               Not CommissionOnlyLineNumbers.Contains(MagazineDetail.LineNumber)
                                                         Select MagazineDetail

        End Function
        Public Function LoadActiveByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Views.MagazineDetail

            Try

                LoadActiveByOrderNumberLineNumber = (From MagazineDetail In DbContext.GetQuery(Of Database.Views.MagazineDetail)
                                                     Where MagazineDetail.OrderNumber = OrderNumber AndAlso
                                                           MagazineDetail.LineNumber = LineNumber AndAlso
                                                           MagazineDetail.IsActiveRevision = 1
                                                     Select MagazineDetail).SingleOrDefault

            Catch ex As Exception
                LoadActiveByOrderNumberLineNumber = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
