Namespace Database.Entities

	<Table("TRF_PRESET_HDR")>
	Public Class TaskTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			IsInactive
			TotalRushDays
			TotalStandardDays

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("TRF_PRESET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Code() As String
		<MaxLength(30)>
		<Column("TRF_PRESET_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("TOTAL_RUSH_DAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalRushDays() As Nullable(Of Short)
		<Column("TOTAL_STD_DAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalStandardDays() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.TaskTemplate.Properties.Code.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a task template code."

                    End If

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            PropertyValue = Value

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).TaskTemplates
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique task template code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
