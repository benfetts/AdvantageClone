Namespace Database.Procedures.OutOfHomeOrderDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OutOfHomeOrderDetail)

            Load = From OutOfHomeOrderDetail In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderDetail)
                   Select OutOfHomeOrderDetail

        End Function
        Public Function LoadNonCancelledNonCommissionByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OutOfHomeOrderDetail)

            LoadNonCancelledNonCommissionByOrderNumber = From OutOfHomeOrderDetail In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderDetail)
                                                         Where OutOfHomeOrderDetail.OutofHomeOrderNumber = OrderNumber AndAlso
                                                               OutOfHomeOrderDetail.IsActiveRevision = 1 AndAlso
                                                               OutOfHomeOrderDetail.BillTypeFlag <> 1 AndAlso
                                                               (OutOfHomeOrderDetail.IsLineCancelled Is Nothing OrElse
                                                                OutOfHomeOrderDetail.IsLineCancelled = 0)
                                                         Select OutOfHomeOrderDetail

        End Function
        Public Function LoadActiveByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Entities.OutOfHomeOrderDetail

            Try

                LoadActiveByOrderNumberLineNumber = (From OutOfHomeOrderDetail In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderDetail)
                                                     Where OutOfHomeOrderDetail.OutofHomeOrderNumber = OrderNumber AndAlso
                                                           OutOfHomeOrderDetail.LineNumber = LineNumber AndAlso
                                                           OutOfHomeOrderDetail.IsActiveRevision = 1
                                                     Select OutOfHomeOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadActiveByOrderNumberLineNumber = Nothing
            End Try

        End Function
        Public Function LoadByAllPrimaryKeys(ByVal DbContext As Database.DbContext,
                                             ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.OutOfHomeOrderDetail

            Try

                LoadByAllPrimaryKeys = (From OutOfHomeOrderDetail In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderDetail)
                                        Where OutOfHomeOrderDetail.OutofHomeOrderNumber = OrderNumber AndAlso
                                              OutOfHomeOrderDetail.LineNumber = LineNumber AndAlso
                                              OutOfHomeOrderDetail.RevisionNumber = RevisionNumber AndAlso
                                              OutOfHomeOrderDetail.SequenceNumber = SequenceNumber
                                        Select OutOfHomeOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByAllPrimaryKeys = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OutOfHomeOrderDetail)

                ErrorText = OutOfHomeOrderDetail.ValidateEntity(IsValid)

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
