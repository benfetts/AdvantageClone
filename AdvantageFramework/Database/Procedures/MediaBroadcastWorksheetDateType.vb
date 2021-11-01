Namespace Database.Procedures.MediaBroadcastWorksheetDateType

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

		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetDateType)

			Load = From MediaBroadcastWorksheetDateType In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetDateType)
				   Select MediaBroadcastWorksheetDateType

		End Function

#End Region

	End Module

End Namespace
