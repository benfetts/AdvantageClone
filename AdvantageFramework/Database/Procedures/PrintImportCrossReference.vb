Namespace Database.Procedures.PrintImportCrossReference

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

        Public Function LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber(ByVal DataContext As Database.DataContext, ByVal ImportOrderNumber As Long, ByVal ImportLineNumber As Long, _
                                                                                              ByVal OrderNumber As Integer, ByVal LineNumber As Integer) As Database.Entities.PrintImportCrossReference

            Try

                LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber = (From PrintImportCrossReference In DataContext.PrintImportCrossReferences _
                                                                                         Where PrintImportCrossReference.ImportOrderNumber = ImportOrderNumber AndAlso _
                                                                                               PrintImportCrossReference.ImportLineNumber = ImportLineNumber AndAlso _
                                                                                               PrintImportCrossReference.OrderNumber = OrderNumber AndAlso _
                                                                                               PrintImportCrossReference.LineNumber = LineNumber
                                                                                         Select PrintImportCrossReference).FirstOrDefault

            Catch ex As Exception
                LoadByImportOrderNumberAndImportLineNumberAndOrderNumberAndLineNumber = Nothing
            End Try

        End Function
        Public Function LoadByImportOrderNumberAndMediaType(ByVal DataContext As Database.DataContext, ByVal ImportOrderNumber As Decimal, ByVal MediaType As String) As Database.Entities.PrintImportCrossReference

            Try

                LoadByImportOrderNumberAndMediaType = (From PrintImportCrossReference In DataContext.PrintImportCrossReferences _
                                                       Where PrintImportCrossReference.ImportOrderNumber = ImportOrderNumber AndAlso _
                                                             PrintImportCrossReference.MediaType = MediaType
                                                       Select PrintImportCrossReference).FirstOrDefault

            Catch ex As Exception
                LoadByImportOrderNumberAndMediaType = Nothing
            End Try

        End Function
        Public Function LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom(ByVal DataContext As Database.DataContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, _
                                                                                  ByVal MediaType As String, ByVal ImportedFrom As String) As Database.Entities.PrintImportCrossReference

            Try

                LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom = (From PrintImportCrossReference In DataContext.PrintImportCrossReferences _
                                                                             Where PrintImportCrossReference.OrderNumber = OrderNumber AndAlso _
                                                                                   PrintImportCrossReference.LineNumber = LineNumber AndAlso _
                                                                                   PrintImportCrossReference.MediaType = MediaType AndAlso _
                                                                                   PrintImportCrossReference.ImportedFrom = ImportedFrom
                                                                             Select PrintImportCrossReference).FirstOrDefault

            Catch ex As Exception
                LoadByOrderNumberAndLineNumberAndMediaTypeAndImportedFrom = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As Database.DataContext) As IQueryable(Of Database.Entities.PrintImportCrossReference)

            Load = From PrintImportCrossReference In DataContext.PrintImportCrossReferences
                   Select PrintImportCrossReference

        End Function

#End Region

    End Module

End Namespace
