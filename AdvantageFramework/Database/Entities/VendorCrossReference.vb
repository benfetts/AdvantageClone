Namespace Database.Entities

	<Table("VENDOR_XREF")>
	Public Class VendorCrossReference
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			VendorCode
			SourceVendorCode
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
		<Column("VENDOR_XREF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorCode)>
        Public Property VendorCode() As String
		<MaxLength(100)>
		<Column("SOURCE_VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SourceVendorCode() As String
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
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.VendorCrossReference.Properties.SourceVendorCode.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).VendorCrossReferences
                            Where Entity.SourceVendorCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.RecordSourceID = Me.RecordSourceID
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique source vendor code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
