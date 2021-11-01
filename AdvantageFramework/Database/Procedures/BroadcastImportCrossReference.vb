Namespace Database.Procedures.BroadcastImportCrossReference

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

        Public Function LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal ImportOrderNumber As Long, ByVal ImportLineNumber As Long, _
                                                                                              ByVal OrderNumber As Integer, ByVal LineNumber As Integer) As Database.Entities.BroadcastImportCrossReference

            Try

                LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber = (From BroadcastImportCrossReference In DbContext.GetQuery(Of Database.Entities.BroadcastImportCrossReference)
                                                                                         Where BroadcastImportCrossReference.ImportOrderNumber = ImportOrderNumber AndAlso
                                                                                               BroadcastImportCrossReference.ImportLineNumber = ImportLineNumber AndAlso
                                                                                               BroadcastImportCrossReference.OrderNumber = OrderNumber AndAlso
                                                                                               BroadcastImportCrossReference.LineNumber = LineNumber
                                                                                         Select BroadcastImportCrossReference).FirstOrDefault

            Catch ex As Exception
                LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber = Nothing
            End Try

        End Function
        Public Function LoadByImportOrderNumberAndMediaType(ByVal DbContext As Database.DbContext, ByVal ImportOrderNumber As Decimal, ByVal MediaType As String) As Database.Entities.BroadcastImportCrossReference

            Try

                LoadByImportOrderNumberAndMediaType = (From BroadcastImportCrossReference In DbContext.GetQuery(Of Database.Entities.BroadcastImportCrossReference)
                                                       Where BroadcastImportCrossReference.ImportOrderNumber = ImportOrderNumber AndAlso
                                                             BroadcastImportCrossReference.MediaType = MediaType
                                                       Select BroadcastImportCrossReference).FirstOrDefault

            Catch ex As Exception
                LoadByImportOrderNumberAndMediaType = Nothing
            End Try

        End Function
        Public Function LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short,
                                                                                  ByVal MediaTypeList As System.Collections.Generic.List(Of String), ByVal ImportedFrom As String) As Database.Entities.BroadcastImportCrossReference

            Try

                LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom = (From BroadcastImportCrossReference In DbContext.GetQuery(Of Database.Entities.BroadcastImportCrossReference)
                                                                             Where BroadcastImportCrossReference.OrderNumber = OrderNumber AndAlso
                                                                                   BroadcastImportCrossReference.LineNumber = LineNumber AndAlso
                                                                                   MediaTypeList.Contains(BroadcastImportCrossReference.MediaType) AndAlso
                                                                                   BroadcastImportCrossReference.ImportedFrom = ImportedFrom
                                                                             Select BroadcastImportCrossReference).FirstOrDefault

            Catch ex As Exception
                LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BroadcastImportCrossReference)

            Load = From BroadcastImportCrossReference In DbContext.GetQuery(Of Database.Entities.BroadcastImportCrossReference)
                   Select BroadcastImportCrossReference

        End Function

#End Region

    End Module

End Namespace
