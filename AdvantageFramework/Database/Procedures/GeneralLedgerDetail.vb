Namespace Database.Procedures.GeneralLedgerDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerDetail)

            Load = From GeneralLedgerDetail In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDetail)
                   Select GeneralLedgerDetail

        End Function
        Public Function LoadByTransaction(ByVal DbContext As Database.DbContext, ByVal GLTransaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerDetail)

            LoadByTransaction = From GeneralLedgerDetail In DbContext.GetQuery(Of Database.Entities.GeneralLedgerDetail)
                                Where GeneralLedgerDetail.GLTransaction = GLTransaction
                                Select GeneralLedgerDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerDetails.Add(GeneralLedgerDetail)

                ErrorText = GeneralLedgerDetail.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        GeneralLedgerDetail.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Load(DbContext) _
                                                              Where Entity.GLTransaction = GeneralLedgerDetail.GLTransaction
                                                              Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        GeneralLedgerDetail.SequenceNumber = 1
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

#End Region

    End Module

End Namespace
