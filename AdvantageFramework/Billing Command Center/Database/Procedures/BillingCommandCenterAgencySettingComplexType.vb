Namespace BillingCommandCenter.Database.Procedures.BillingCommandCenterAgencySettingComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.BillingCommandCenterAgencySetting)

            'objects
            Dim ReturnValueObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            ReturnValueObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ret_val", 0)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.BillingCommandCenterAgencySetting)("BCCObjectContextConnection.LoadBillingCommandCenterAgencySettings", ReturnValueObjectParameter)

        End Function

#End Region

    End Module

End Namespace
