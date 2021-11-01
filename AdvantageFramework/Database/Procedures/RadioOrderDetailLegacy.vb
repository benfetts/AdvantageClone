Namespace Database.Procedures.RadioOrderDetailLegacy

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrderDetailLegacy)

            Load = From RadioOrderDetailLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderDetailLegacy)
                   Select RadioOrderDetailLegacy

        End Function
        Public Function LoadLatestRevisionByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Entities.RadioOrderDetailLegacy

            Try

                LoadLatestRevisionByOrderNumberLineNumber = (From RadioOrderDetailLegacy In DbContext.GetQuery(Of Database.Entities.RadioOrderDetailLegacy)
                                                             Where RadioOrderDetailLegacy.RadioOrderNumberLegacy = OrderNumber AndAlso
                                                                   RadioOrderDetailLegacy.LineNumber = LineNumber
                                                             Order By RadioOrderDetailLegacy.RevisionNumberLegacy Descending
                                                             Select RadioOrderDetailLegacy).FirstOrDefault

            Catch ex As Exception
                LoadLatestRevisionByOrderNumberLineNumber = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
