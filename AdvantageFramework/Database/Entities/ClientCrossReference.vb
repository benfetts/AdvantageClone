Namespace Database.Entities

	<Table("CLIENT_XREF")>
	Public Class ClientCrossReference
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientCode
			DivisionCode
			ProductCode
			SourceClientCode
			SourceDivisionCode
			SourceProductCode
			RecordSourceID
			RecordSource

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("CLIENT_XREF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<MaxLength(100)>
		<Column("SOURCE_CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SourceClientCode() As String
		<MaxLength(100)>
		<Column("SOURCE_DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SourceDivisionCode() As String
		<MaxLength(100)>
		<Column("SOURCE_PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SourceProductCode() As String
		<Required>
		<Column("RECORD_SOURCE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property RecordSourceID() As Integer

        Public Overridable Property RecordSource As Database.Entities.RecordSource

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Entities.ClientCrossReference.Properties.ClientCode.ToString

                        SetRequired(PropertyDescriptor, True)

                    Case AdvantageFramework.Database.Entities.ClientCrossReference.Properties.DivisionCode.ToString

                        If Me.RecordSourceID = 1 Then

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.Database.Entities.ClientCrossReference.Properties.ProductCode.ToString

                        If Me.RecordSourceID = 1 Then

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.Database.Entities.ClientCrossReference.Properties.SourceClientCode.ToString

                        If Me.RecordSourceID = 1 Then

                            SetRequired(PropertyDescriptor, True)

                        End If

                    Case AdvantageFramework.Database.Entities.ClientCrossReference.Properties.SourceProductCode.ToString

                        If Me.RecordSourceID = 1 Then

                            SetRequired(PropertyDescriptor, True)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ClientCrossReference.Properties.SourceClientCode.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ClientCrossReferences
                            Where Entity.RecordSourceID = Me.RecordSourceID AndAlso
                                  Entity.SourceClientCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.SourceProductCode.ToUpper = Me.SourceProductCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique source client code/source product code pair."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
