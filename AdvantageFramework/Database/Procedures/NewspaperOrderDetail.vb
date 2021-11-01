Namespace Database.Procedures.NewspaperOrderDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NewspaperOrderDetail)

            Load = From NewspaperOrderDetail In DbContext.GetQuery(Of Database.Entities.NewspaperOrderDetail)
                   Select NewspaperOrderDetail

        End Function
        Public Function LoadActiveRevisionByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Entities.NewspaperOrderDetail

            Try

                LoadActiveRevisionByOrderNumberAndLineNumber = (From NewspaperOrderDetail In DbContext.GetQuery(Of Database.Entities.NewspaperOrderDetail)
                                                                Where NewspaperOrderDetail.NewspaperOrderOrderNumber = OrderNumber AndAlso
                                                                      NewspaperOrderDetail.LineNumber = LineNumber AndAlso
                                                                      NewspaperOrderDetail.IsActiveRevision = 1
                                                                Select NewspaperOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadActiveRevisionByOrderNumberAndLineNumber = Nothing
            End Try

        End Function
        Public Function LoadCommissionOnlyByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As IEnumerable(Of Short)

            LoadCommissionOnlyByOrderNumber = From NewspaperOrderDetail In DbContext.GetQuery(Of Database.Entities.NewspaperOrderDetail)
                                              Where NewspaperOrderDetail.NewspaperOrderOrderNumber = OrderNumber AndAlso
                                                    NewspaperOrderDetail.IsActiveRevision = 1 AndAlso
                                                    NewspaperOrderDetail.BillTypeFlag = 1
                                              Select NewspaperOrderDetail.LineNumber

        End Function
        Public Function LoadByAllPrimaryKeys(ByVal DbContext As Database.DbContext,
                                             ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.NewspaperOrderDetail

            Try

                LoadByAllPrimaryKeys = (From NewspaperOrderDetail In DbContext.GetQuery(Of Database.Entities.NewspaperOrderDetail)
                                        Where NewspaperOrderDetail.NewspaperOrderOrderNumber = OrderNumber AndAlso
                                              NewspaperOrderDetail.LineNumber = LineNumber AndAlso
                                              NewspaperOrderDetail.RevisionNumber = RevisionNumber AndAlso
                                              NewspaperOrderDetail.SequenceNumber = SequenceNumber
                                        Select NewspaperOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByAllPrimaryKeys = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(NewspaperOrderDetail)

                ErrorText = NewspaperOrderDetail.ValidateEntity(IsValid)

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
