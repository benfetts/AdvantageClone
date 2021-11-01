Namespace Database.Procedures.OtherCashReceiptDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OtherCashReceiptDetail)

            Load = From OtherCashReceiptDetail In DbContext.GetQuery(Of Database.Entities.OtherCashReceiptDetail)
                   Select OtherCashReceiptDetail

        End Function
        Public Function LoadByOtherCashReceiptIDAndOtherCashReceiptSequenceNumber(ByVal DbContext As Database.DbContext, ByVal OtherCashReceiptID As Integer, ByVal OtherCashReceiptSequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OtherCashReceiptDetail)

            LoadByOtherCashReceiptIDAndOtherCashReceiptSequenceNumber = From OtherCashReceiptDetail In DbContext.GetQuery(Of Database.Entities.OtherCashReceiptDetail)
                                                                        Where OtherCashReceiptDetail.OtherCashReceiptID = OtherCashReceiptID AndAlso
                                                                              OtherCashReceiptDetail.OtherCashReceiptSequenceNumber = OtherCashReceiptSequenceNumber AndAlso
                                                                              OtherCashReceiptDetail.ModifyDelete = False
                                                                        Select OtherCashReceiptDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OtherCashReceiptDetail As AdvantageFramework.Database.Entities.OtherCashReceiptDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OtherCashReceiptDetails.Add(OtherCashReceiptDetail)

                ErrorText = OtherCashReceiptDetail.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        OtherCashReceiptDetail.ItemID = (From Entity In AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Load(DbContext) _
                                                         Where Entity.OtherCashReceiptID = OtherCashReceiptDetail.OtherCashReceiptID AndAlso _
                                                               Entity.OtherCashReceiptSequenceNumber = OtherCashReceiptDetail.OtherCashReceiptSequenceNumber _
                                                         Select Entity.ItemID).Max + 1

                    Catch ex As Exception
                        OtherCashReceiptDetail.ItemID = 1
                    End Try

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OtherCashReceiptDetail As AdvantageFramework.Database.Entities.OtherCashReceiptDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OtherCashReceiptDetail)

                ErrorText = OtherCashReceiptDetail.ValidateEntity(IsValid)

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
