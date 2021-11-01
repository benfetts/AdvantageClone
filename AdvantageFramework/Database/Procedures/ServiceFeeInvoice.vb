Namespace Database.Procedures.ServiceFeeInvoice

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ServiceFeeInvoice)

            Load = From ServiceFeeInvoice In DataContext.ServiceFeeInvoices
                   Select ServiceFeeInvoice

        End Function
        Public Function LoadByJobComponent(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As IQueryable(Of AdvantageFramework.Database.Entities.ServiceFeeInvoice)

            LoadByJobComponent = From ServiceFeeInvoice In DataContext.ServiceFeeInvoices
                                 Where ServiceFeeInvoice.JobNumber = JobNumber AndAlso
                                       ServiceFeeInvoice.JobComponentNumber = JobComponentNumber
                                 Select ServiceFeeInvoice

        End Function
        Public Function LoadByComponentAndIncomeOnly(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal IncomeOnlyID As Integer) As AdvantageFramework.Database.Entities.ServiceFeeInvoice

            LoadByComponentAndIncomeOnly = (From ServiceFeeInvoice In DataContext.ServiceFeeInvoices _
                                            Where ServiceFeeInvoice.JobNumber = JobNumber AndAlso _
                                                  ServiceFeeInvoice.JobComponentNumber = JobComponentNumber AndAlso _
                                                  ServiceFeeInvoice.IncomeOnlyID = IncomeOnlyID _
                                            Select ServiceFeeInvoice).SingleOrDefault

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal ServiceFeeInvoice As AdvantageFramework.Database.Entities.ServiceFeeInvoice) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ServiceFeeInvoice.DataContext = DataContext

                ServiceFeeInvoice.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ServiceFeeInvoices.InsertOnSubmit(ServiceFeeInvoice)

                ErrorText = ServiceFeeInvoice.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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