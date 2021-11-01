Namespace Database.Procedures.BillingRateDetailView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BillingRateDetailView)

            Load = From BillingRateDetailView In DbContext.GetQuery(Of Database.Views.BillingRateDetailView)
                   Select BillingRateDetailView

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BillingRateDetailView)

            LoadAllActive = From BillingRateDetailView In DbContext.GetQuery(Of Database.Views.BillingRateDetailView)
                            Where BillingRateDetailView.IsInactive = CShort(0)
                            Select BillingRateDetailView

        End Function

#End Region

    End Module

End Namespace
