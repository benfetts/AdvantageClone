Namespace Database.Procedures.OrderStatus

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.OrderStatus)

            Load = DbContext.Set(Of Entities.OrderStatus)()

        End Function

#End Region

    End Module

End Namespace
