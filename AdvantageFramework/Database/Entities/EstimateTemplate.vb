Namespace Database.Entities

	<Table("PRESET_FUNC_HDR")>
	Public Class EstimateTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			IsInactive
			DefaultComment

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("PRESET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(30)>
		<Column("PRESET_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("DEF_COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultComment() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.EstimateTemplate.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        If AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(_DbContext, Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "Estimate Template Code already exist"

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
