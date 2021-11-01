Namespace Database.Procedures.NewspaperDetailView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.NewspaperDetail)

            Load = From NewspaperDetail In DbContext.GetQuery(Of Database.Views.NewspaperDetail)
                   Select NewspaperDetail

        End Function
        Public Function LoadNonCancelledNonCommissionByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.NewspaperDetail)

            Dim CommissionOnlyLineNumbers As IEnumerable(Of Short) = Nothing

            CommissionOnlyLineNumbers = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadCommissionOnlyByOrderNumber(DbContext, OrderNumber)

            LoadNonCancelledNonCommissionByOrderNumber = From NewspaperDetail In DbContext.GetQuery(Of Database.Views.NewspaperDetail)
                                                         Where NewspaperDetail.OrderNumber = OrderNumber AndAlso
                                                               NewspaperDetail.IsActiveRevision = 1 AndAlso
                                                               (NewspaperDetail.IsLineCancelled Is Nothing OrElse
                                                                NewspaperDetail.IsLineCancelled = 0) AndAlso
                                                               Not CommissionOnlyLineNumbers.Contains(NewspaperDetail.LineNumber)
                                                         Select NewspaperDetail

        End Function
        Public Function LoadActiveByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Views.NewspaperDetail

            Try

                LoadActiveByOrderNumberLineNumber = (From NewspaperDetail In DbContext.GetQuery(Of Database.Views.NewspaperDetail)
                                                     Where NewspaperDetail.OrderNumber = OrderNumber AndAlso
                                                           NewspaperDetail.LineNumber = LineNumber
                                                     Select NewspaperDetail).OrderByDescending(Function(E) E.RevisionNumber).ThenByDescending(Function(E) E.SequenceNumber).FirstOrDefault

            Catch ex As Exception
                LoadActiveByOrderNumberLineNumber = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
