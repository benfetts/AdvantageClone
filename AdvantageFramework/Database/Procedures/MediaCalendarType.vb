Namespace Database.Procedures.MediaCalendarType

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

		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaCalendarType)

			Load = From MediaCalendarType In DbContext.GetQuery(Of Database.Entities.MediaCalendarType)
				   Select MediaCalendarType

		End Function

#End Region

	End Module

End Namespace
