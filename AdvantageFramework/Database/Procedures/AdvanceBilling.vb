Namespace Database.Procedures.AdvanceBilling

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AdvanceBilling)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.AdvanceBilling)()

        End Function
        Public Function LoadByIDAndSequenceNumberAndFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer, ByVal SequenceNumber As Short, ByVal FunctionCode As String) As AdvantageFramework.Database.Entities.AdvanceBilling

            Try

                LoadByIDAndSequenceNumberAndFunctionCode = (From Entity In DbContext.Set(Of AdvantageFramework.Database.Entities.AdvanceBilling)()
                                                            Where Entity.ID = ID AndAlso
                                                                  Entity.SequenceNumber = SequenceNumber AndAlso
                                                                  Entity.FunctionCode = FunctionCode
                                                            Select Entity).SingleOrDefault

            Catch ex As Exception
                LoadByIDAndSequenceNumberAndFunctionCode = Nothing
            End Try

        End Function
        Public Function LoadAllUnbilledByJobNumberAndJobComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AdvanceBilling)

            Try

                LoadAllUnbilledByJobNumberAndJobComponentNumber = From Entity In DbContext.Set(Of AdvantageFramework.Database.Entities.AdvanceBilling)()
                                                                  Where Entity.JobNumber = JobNumber AndAlso
                                                                        Entity.JobComponentNumber = JobComponentNumber AndAlso
                                                                        Entity.ARInvoiceNumber Is Nothing
                                                                  Select Entity

            Catch ex As Exception
                LoadAllUnbilledByJobNumberAndJobComponentNumber = Nothing
            End Try

        End Function
        Public Function LoadUnbilledByJobNumberAndJobComponentNumberAndFlagIsOneOrTwo(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AdvanceBilling)

            Try

                LoadUnbilledByJobNumberAndJobComponentNumberAndFlagIsOneOrTwo = From Entity In DbContext.Set(Of AdvantageFramework.Database.Entities.AdvanceBilling)()
                                                                                Where Entity.JobNumber = JobNumber AndAlso
                                                                                      Entity.JobComponentNumber = JobComponentNumber AndAlso
                                                                                      Entity.ARInvoiceNumber Is Nothing AndAlso
                                                                                      (Entity.AdvanceBillFlag = 1 OrElse Entity.AdvanceBillFlag = 2)
                                                                                Select Entity

            Catch ex As Exception
                LoadUnbilledByJobNumberAndJobComponentNumberAndFlagIsOneOrTwo = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AdvanceBillings.Add(AdvanceBilling)

                ErrorText = AdvanceBilling.ValidateEntity(IsValid)

                If IsValid Then

                    If AdvanceBilling.ID = 0 Then

                        AdvanceBilling.ID = AdvantageFramework.Database.Procedures.AssignNumber.GetNextNumber(DbContext, "AB_ID")

                    End If

                    Try

                        AdvanceBilling.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                                                         Where Entity.ID = AdvanceBilling.ID
                                                         Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        AdvanceBilling.SequenceNumber = 1
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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(AdvanceBilling).State = Entity.EntityState.Modified

                ErrorText = AdvanceBilling.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(AdvanceBilling).State = Entity.EntityState.Deleted

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
