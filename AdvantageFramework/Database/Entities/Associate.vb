Namespace Database.Entities

	<Table("ASSOCIATE")>
	Public Class Associate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientCode
			VendorCode
			EmployeeCode
			Percent
			DivisionCode
			ProductCode
			MediaType
			ReportLevel
			Client
			Vendor

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("ASSOCIATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("ASSOCIATE_CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("ASSOCIATE_VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Vendor", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorCode)>
		Public Property VendorCode() As String
		<MaxLength(6)>
		<Column("ASSOCIATE_EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Employee", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode)>
		Public Property EmployeeCode() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
		<Column("ASSOCIATE_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Percent() As Decimal
		<MaxLength(6)>
		<Column("ASSOCIATE_DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("ASSOCIATE_PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<MaxLength(1)>
		<Column("ASSOCIATE_MED_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
		Public Property MediaType() As String
		<Column("ASSOCIATE_RPT_LVL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ReportLevel() As Nullable(Of Short)

        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = Nothing

            ErrorText = MyBase.ValidateEntity(IsValid)

            If (Me.VendorCode Is Nothing OrElse Me.VendorCode = "") AndAlso (Me.EmployeeCode Is Nothing OrElse Me.EmployeeCode = "") Then

                IsValid = False
                ErrorText = "Please supply a Vendor or Employee."

            End If

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim PercentSum As Decimal = 0

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Associate.Properties.ClientCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        For Each EntityClass In DirectCast(DbContext, AdvantageFramework.Database.DbContext).Associates

                            If EntityClass.ClientCode = Me.ClientCode Then

                                If EntityClass.DivisionCode = Me.DivisionCode Then

                                    If EntityClass.ProductCode = Me.ProductCode Then

                                        If EntityClass.VendorCode = Me.VendorCode Then

                                            If EntityClass.EmployeeCode = Me.EmployeeCode Then

                                                If EntityClass.MediaType = Me.MediaType Then

                                                    IsValid = False

                                                    ErrorText = "Please enter a unique associate."

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        Next

                    End If

                Case AdvantageFramework.Database.Entities.Associate.Properties.Percent.ToString

                    If Me.IsEntityBeingAdded() Then

                        For Each EntityClass In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Associates

                            If EntityClass.ClientCode = Me.ClientCode AndAlso ((Me.MediaType Is Nothing AndAlso EntityClass.MediaType Is Nothing) OrElse EntityClass.MediaType = Me.MediaType) Then

                                If (EntityClass.DivisionCode Is Nothing AndAlso Me.DivisionCode Is Nothing) OrElse EntityClass.DivisionCode = Me.DivisionCode Then

                                    If (EntityClass.ProductCode Is Nothing AndAlso Me.ProductCode Is Nothing) OrElse EntityClass.ProductCode = Me.ProductCode Then

                                        PercentSum = PercentSum + EntityClass.Percent

                                    End If

                                End If

                            End If

                        Next

                        PercentSum = PercentSum + PropertyValue

                        If PercentSum > 100 Then

                            IsValid = False

                            ErrorText = "Total percent cannot exceed 100."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.Associate.Properties.VendorCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        If PropertyValue IsNot Nothing AndAlso PropertyValue <> "" Then

                            For Each EntityClass In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Associates

                                If EntityClass.ClientCode = Me.ClientCode Then

                                    If (EntityClass.DivisionCode Is Nothing AndAlso Me.DivisionCode Is Nothing) OrElse EntityClass.DivisionCode = Me.DivisionCode Then

                                        If (EntityClass.ProductCode Is Nothing AndAlso Me.ProductCode Is Nothing) OrElse EntityClass.ProductCode = Me.ProductCode Then

                                            If EntityClass.VendorCode = PropertyValue Then

                                                IsValid = False

                                                ErrorText = "Duplicate associates are not allowed."

                                                Exit For

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.Associate.Properties.EmployeeCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        If PropertyValue IsNot Nothing AndAlso PropertyValue <> "" Then

                            For Each EntityClass In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Associates

                                If EntityClass.ClientCode = Me.ClientCode Then

                                    If (EntityClass.DivisionCode Is Nothing AndAlso Me.DivisionCode Is Nothing) OrElse EntityClass.DivisionCode = Me.DivisionCode Then

                                        If (EntityClass.ProductCode Is Nothing AndAlso Me.ProductCode Is Nothing) OrElse EntityClass.ProductCode = Me.ProductCode Then

                                            If EntityClass.EmployeeCode = PropertyValue Then

                                                IsValid = False

                                                ErrorText = "Duplicate associates are not allowed."

                                                Exit For

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean, IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As BaseClasses.Methods.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Associate.Properties.VendorCode.ToString

                    If (Value Is Nothing OrElse Value = "") AndAlso (Me.EmployeeCode Is Nothing OrElse Me.EmployeeCode = "") Then

                        IsValid = False
                        ErrorText &= "Please supply a Vendor or Employee. "

                    Else

                        IsValid = True
                        ErrorText = ""

                    End If

                Case AdvantageFramework.Database.Entities.Associate.Properties.EmployeeCode.ToString

                    If (Value Is Nothing OrElse Value = "") AndAlso (Me.VendorCode Is Nothing OrElse Me.VendorCode = "") Then

                        IsValid = False
                        ErrorText &= "Please supply a Vendor or Employee. "

                    Else

                        IsValid = True
                        ErrorText = ""

                    End If

            End Select

        End Sub

#End Region

	End Class

End Namespace
