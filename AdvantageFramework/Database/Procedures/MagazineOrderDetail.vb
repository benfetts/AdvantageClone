Namespace Database.Procedures.MagazineOrderDetail

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

        Public Function LoadActiveByOrderNumberLineNumber(DbContext As Database.DbContext, OrderNumber As Integer, LineNumber As Short) As Database.Entities.MagazineOrderDetail

            If (From MagazineOrderDetail In DbContext.GetQuery(Of Database.Entities.MagazineOrderDetail)
                Where MagazineOrderDetail.MagazineOrderNumber = OrderNumber AndAlso
                      MagazineOrderDetail.LineNumber = LineNumber AndAlso
                      MagazineOrderDetail.IsActiveRevision = 1
                Select MagazineOrderDetail).Count = 1 Then

                LoadActiveByOrderNumberLineNumber = (From MagazineOrderDetail In DbContext.GetQuery(Of Database.Entities.MagazineOrderDetail)
                                                     Where MagazineOrderDetail.MagazineOrderNumber = OrderNumber AndAlso
                                                           MagazineOrderDetail.LineNumber = LineNumber AndAlso
                                                           MagazineOrderDetail.IsActiveRevision = 1
                                                     Select MagazineOrderDetail).Single

            Else

                LoadActiveByOrderNumberLineNumber = Nothing

            End If

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineOrderDetail)

            Load = From MagazineOrderDetail In DbContext.GetQuery(Of Database.Entities.MagazineOrderDetail)
                   Select MagazineOrderDetail

        End Function
        Public Function LoadCommissionOnlyByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As IEnumerable(Of Short)

            LoadCommissionOnlyByOrderNumber = From MagazineOrderDetail In DbContext.GetQuery(Of Database.Entities.MagazineOrderDetail)
                                              Where MagazineOrderDetail.MagazineOrderNumber = OrderNumber AndAlso
                                                    MagazineOrderDetail.IsActiveRevision = 1 AndAlso
                                                    MagazineOrderDetail.BillTypeFlag = 1
                                              Select MagazineOrderDetail.LineNumber

        End Function
        Public Function LoadByAllPrimaryKeys(ByVal DbContext As Database.DbContext,
                                             ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.MagazineOrderDetail

            Try

                LoadByAllPrimaryKeys = (From MagazineOrderDetail In DbContext.GetQuery(Of Database.Entities.MagazineOrderDetail)
                                        Where MagazineOrderDetail.MagazineOrderNumber = OrderNumber AndAlso
                                              MagazineOrderDetail.LineNumber = LineNumber AndAlso
                                              MagazineOrderDetail.RevisionNumber = RevisionNumber AndAlso
                                              MagazineOrderDetail.SequenceNumber = SequenceNumber
                                        Select MagazineOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByAllPrimaryKeys = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineOrderDetail As AdvantageFramework.Database.Entities.MagazineOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MagazineOrderDetail)

                ErrorText = MagazineOrderDetail.ValidateEntity(IsValid)

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
