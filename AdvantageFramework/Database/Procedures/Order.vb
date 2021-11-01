Namespace Database.Procedures.Order

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

		Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Order)

			Load = From Order In DbContext.GetQuery(Of Database.Views.Order)
				   Select Order

		End Function

#End Region

	End Module

End Namespace
