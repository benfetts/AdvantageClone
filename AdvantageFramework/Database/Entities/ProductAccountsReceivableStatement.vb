Namespace Database.Entities

	<Table("PRODUCT_AR_STMT")>
	Public Class ProductAccountsReceivableStatement
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCode
			DivisionCode
			ProductCode
			DistributeViaEmail
			DistributeViaPrint
			UseAddress
			IncludeOnAccount
			ReportFormat
			LastEmailed
			LastPrinted
			ClientContactID
			ClientContactCode
			ClientContact

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DIV_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PRD_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<Required>
		<Column("DIST_VIA_EMAIL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Email", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property DistributeViaEmail() As Short
		<Required>
		<Column("DIST_VIA_PRINT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Print", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property DistributeViaPrint() As Short
		<Column("USE_ADDRESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseAddress() As Nullable(Of Short)
		<Required>
		<Column("INCL_ON_ACCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IncludeOnAccount() As Short
		<Column("REPORT_FORMAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ReportFormat() As Nullable(Of Short)
		<Column("LAST_EMAILED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property LastEmailed() As Nullable(Of Date)
		<Column("LAST_PRINTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property LastPrinted() As Nullable(Of Date)
		<Key>
		<Required>
        <Column("CDP_CONTACT_ID", Order:=3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Contact", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientContactID)>
		Public Property ClientContactID() As Integer
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<MaxLength(6)>
		<Column("CONT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ClientContactCode() As String

        <ForeignKey("ClientContactID")>
        Public Overridable Property ClientContact As Database.Entities.ClientContact

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ProductAccountsReceivableStatements
                            Where Entity.ClientContactID = DirectCast(PropertyValue, Integer) AndAlso
                                     Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper AndAlso
                                     Entity.DivisionCode.ToUpper = Me.DivisionCode.ToUpper AndAlso
                                     Entity.ProductCode.ToUpper = Me.ProductCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Duplicate entry."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
