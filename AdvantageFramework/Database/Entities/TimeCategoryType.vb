Namespace Database.Entities

	<Table("TIME_CATEGORY_TYPE")>
	Public Class TimeCategoryType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Description
			DefaultUse
			ID
			IndirectCategories

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<MaxLength(15)>
		<Column("TYPE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(15)>
		<Column("TYPE_USE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="Used For", IsReadOnlyColumn:=True)>
		Public Property DefaultUse() As String
		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Short

        Public Overridable Property IndirectCategories As ICollection(Of Database.Entities.IndirectCategory)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Description.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.TimeCategoryType.Properties.Description.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a time category type description."

                    End If

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).TimeCategoryTypes
                                Where Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique time category type description."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).TimeCategoryTypes _
                                   Where Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                         Entity.ID <> Me.ID _
                                   Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique time category type description."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function


#End Region

	End Class

End Namespace
