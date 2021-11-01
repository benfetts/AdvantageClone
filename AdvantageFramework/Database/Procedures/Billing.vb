Namespace Database.Procedures.Billing

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

        Public Function LoadByBillingUserCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BillingUserCode As String) As AdvantageFramework.Database.Entities.Billing

            Try

                LoadByBillingUserCode = (From Billing In DataContext.Billings
                                         Where Billing.BillingUserCode = BillingUserCode
                                         Select Billing).SingleOrDefault
            Catch ex As Exception
                LoadByBillingUserCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.Billing)

            Load = From Billing In DataContext.Billings
                   Select Billing

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Billing As AdvantageFramework.Database.Entities.Billing) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Billing.DataContext = DataContext

                Billing.DatabaseAction = Action.Updating

                ErrorText = Billing.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
