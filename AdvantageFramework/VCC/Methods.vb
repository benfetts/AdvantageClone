Namespace VCC

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Function DisplayLocalDate(TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset, DatabaseDate As Nullable(Of Date)) As Nullable(Of Date)

			Dim LocalDate As Nullable(Of Date) = Nothing
			Dim Offset As Decimal = Nothing

			If DatabaseDate.HasValue AndAlso TimezoneOffset.AgencyOffset <> 99 AndAlso
					TimezoneOffset.DatabaseOffset <> 99 AndAlso TimezoneOffset.AgencyOffset <> TimezoneOffset.DatabaseOffset Then

				Offset = (TimezoneOffset.DatabaseOffset - TimezoneOffset.AgencyOffset) * -1

				LocalDate = DateAdd(DateInterval.Minute, (CType(Offset, Integer) * 60) + ((Offset - CType(Offset, Integer)) * 60), DatabaseDate.Value)

			Else

				LocalDate = DatabaseDate

			End If

			DisplayLocalDate = LocalDate

		End Function

#End Region

	End Module

End Namespace