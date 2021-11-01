Namespace Database.Entities

	<Table("IMP_DIVISION_STAGING")>
	Public Class ImportDivisionStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BatchName
			IsNew
			IsOnHold
			ClientCode
			Code
			Name
			AttentionLine
			BillingAddress
			BillingAddress2
			BillingCity
			BillingCounty
			BillingState
			BillingCountry
			BillingZip
			Address
			Address2
			City
			County
			State
			Country
			Zip
			IsActive

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName() As String
		<Required>
		<Column("IS_NEW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property IsNew() As Boolean
		<Required>
		<Column("ON_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOnHold() As Boolean
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("DIV_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("DIV_ATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AttentionLine() As String
		<MaxLength(40)>
		<Column("DIV_BADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Billing Address 1")>
		Public Property BillingAddress() As String
		<MaxLength(40)>
		<Column("DIV_BADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Billing Address 2")>
		Public Property BillingAddress2() As String
		<MaxLength(30)>
		<Column("DIV_BCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCity() As String
		<MaxLength(20)>
		<Column("DIV_BCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCounty() As String
		<MaxLength(10)>
		<Column("DIV_BSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingState() As String
		<MaxLength(20)>
		<Column("DIV_BCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCountry() As String
		<MaxLength(10)>
		<Column("DIV_BZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingZip() As String
		<MaxLength(40)>
		<Column("DIV_SADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Address 1")>
		Public Property Address() As String
		<MaxLength(40)>
		<Column("DIV_SADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Address 2")>
		Public Property Address2() As String
		<MaxLength(30)>
		<Column("DIV_SCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement City")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("DIV_SCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement County")>
		Public Property County() As String
		<MaxLength(10)>
		<Column("DIV_SSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement State")>
		Public Property State() As String
		<MaxLength(20)>
		<Column("DIV_SCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Country")>
		Public Property Country() As String
		<MaxLength(10)>
		<Column("DIV_SZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Zip")>
		Public Property Zip() As String
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsActive() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties.Code.ToString

                    If Me.IsNew Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Divisions _
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                      Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper
                                Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Division code already exists in the system for this client."

                        Else

                            Try

                                If _DataContext IsNot Nothing Then

                                    _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                                End If

                            Catch ex As Exception
                                _DataContext = Nothing
                            End Try

                            ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.Code, Value, IsValid)

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(_DbContext, Me.ClientCode, PropertyValue) Is Nothing Then

                            IsValid = False
                            ErrorText = "Division code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties.Name.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a division's name."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
