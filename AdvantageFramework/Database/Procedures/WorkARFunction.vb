Namespace Database.Procedures.WorkARFunction

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

        Public Function LoadByBillingUserCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BillingUserCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.WorkARFunction)

            LoadByBillingUserCode = From WorkARFunction In DataContext.WorkARFunctions
                                    Where WorkARFunction.BillingUserCode = BillingUserCode
                                    Select WorkARFunction

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.WorkARFunction)

            Load = From WorkARFunction In DataContext.WorkARFunctions
                   Select WorkARFunction

        End Function

#End Region

    End Module

End Namespace