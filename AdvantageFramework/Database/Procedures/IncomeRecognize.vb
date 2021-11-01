Namespace Database.Procedures.IncomeRecognize

    <HideModuleName()>
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

        Public Function LoadActiveByJobJobComponentFunction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer,
                                                            ByVal JobComponentNumber As Short, ByVal FunctionCode As String) As AdvantageFramework.Database.Entities.IncomeRecognize

            Try

                If FunctionCode IsNot Nothing Then

                    LoadActiveByJobJobComponentFunction = (From IncomeRecognize In DbContext.GetQuery(Of Database.Entities.IncomeRecognize)
                                                           Where IncomeRecognize.JobNumber = JobNumber AndAlso
                                                                 IncomeRecognize.JobComponentNumber = JobComponentNumber AndAlso
                                                                 IncomeRecognize.FunctionCode = FunctionCode AndAlso
                                                                 IncomeRecognize.ARInvoiceNumber Is Nothing AndAlso
                                                                 IncomeRecognize.AdvanceBillFlag <> 7
                                                           Select IncomeRecognize).SingleOrDefault

                Else

                    LoadActiveByJobJobComponentFunction = (From IncomeRecognize In DbContext.GetQuery(Of Database.Entities.IncomeRecognize)
                                                           Where IncomeRecognize.JobNumber = JobNumber AndAlso
                                                                 IncomeRecognize.JobComponentNumber = JobComponentNumber AndAlso
                                                                 IncomeRecognize.FunctionCode Is Nothing AndAlso
                                                                 IncomeRecognize.ARInvoiceNumber Is Nothing AndAlso
                                                                 IncomeRecognize.AdvanceBillFlag <> 7
                                                           Select IncomeRecognize).SingleOrDefault

                End If

            Catch ex As Exception
                LoadActiveByJobJobComponentFunction = Nothing
            End Try

        End Function
        Public Function LoadAllUnbilledByJobNumberAndJobComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.IncomeRecognize)

            Try

                LoadAllUnbilledByJobNumberAndJobComponentNumber = From Entity In DbContext.Set(Of AdvantageFramework.Database.Entities.IncomeRecognize)()
                                                                  Where Entity.JobNumber = JobNumber AndAlso
                                                                        Entity.JobComponentNumber = JobComponentNumber AndAlso
                                                                        Entity.ARInvoiceNumber Is Nothing
                                                                  Select Entity

            Catch ex As Exception
                LoadAllUnbilledByJobNumberAndJobComponentNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.IncomeRecognize)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.IncomeRecognize)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncomeRecognize As AdvantageFramework.Database.Entities.IncomeRecognize) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.IncomeRecognizes.Add(IncomeRecognize)

                ErrorText = IncomeRecognize.ValidateEntity(IsValid)

                If IsValid Then

                    If IncomeRecognize.AdvanceBillingID = 0 Then

                        IncomeRecognize.AdvanceBillingID = AdvantageFramework.Database.Procedures.AssignNumber.GetNextNumber(DbContext, "AB_ID")

                    End If

                    Try

                        IncomeRecognize.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.IncomeRecognize.Load(DbContext)
                                                          Where Entity.AdvanceBillingID = IncomeRecognize.AdvanceBillingID
                                                          Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        IncomeRecognize.SequenceNumber = 1
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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncomeRecognize As AdvantageFramework.Database.Entities.IncomeRecognize) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(IncomeRecognize).State = Entity.EntityState.Modified

                ErrorText = IncomeRecognize.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncomeRecognize As AdvantageFramework.Database.Entities.IncomeRecognize) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(IncomeRecognize).State = Entity.EntityState.Deleted

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
