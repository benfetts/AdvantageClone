Namespace Database.Entities

	<Table("SERVICE_FEE_TYPE")>
	Public Class ServiceFeeType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Code
			Description
			IsInactive
			JobComponents
			ContractFees

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SERVICE_FEE_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(30)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("IS_INACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Boolean

        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)
        Public Overridable Property ContractFees As ICollection(Of Database.Entities.ContractFee)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ServiceFeeType.Properties.Code.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a service fee type code."

                    End If

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ServiceFeeTypes
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique service fee type code."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ServiceFeeTypes _
                                   Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                         Entity.ID <> Me.ID _
                                   Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique service fee type code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ServiceFeeType.Properties.Description.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a service fee type description."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
