Namespace Database.Entities

	<Table("SC_FORMAT")>
	Public Class SalesClassFormat
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			SalesClassCode
			Code
			Description
			IsInactive
			SalesClass

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("SC_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String
		<Key>
		<Required>
		<MaxLength(8)>
        <Column("FORMAT_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("FORMAT_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("ACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property SalesClass As Database.Entities.SalesClass

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.SalesClassFormat.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() AndAlso (Me.SalesClassCode IsNot Nothing OrElse Me.SalesClassCode <> Nothing) Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).SalesClassFormats
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                     Entity.SalesClassCode.ToUpper = Me.SalesClassCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique code."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.SalesClassFormat.Properties.IsInactive.ToString

                    If IsNothing(Value) Then

                        Value = CShort(1)

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
