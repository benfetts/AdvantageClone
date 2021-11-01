Namespace Database.Entities

	<Table("IMP_CLR_CHK_STAGING")>
	Public Class ImportClearedChecksStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BatchName
			FileName
			BankCode
			CheckNumber
			CheckAmount
			VendorName
			CheckClearedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROW_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName() As String
		<MaxLength(50)>
		<Column("BANK_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Bank", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.BankCode)>
		Public Property BankCode() As String
		<MaxLength(25)>
		<Column("CHECK_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CheckNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <Column("CHECK_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckAmount() As Nullable(Of Decimal)
		<MaxLength(100)>
		<Column("VENDOR_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorName() As String
		<MaxLength(100)>
		<Column("FILE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileName() As String
		<Column("CHECK_CLEARED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckClearedDate() As Nullable(Of Date)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects 
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If (From CheckRegister In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).CheckRegisters.ToList _
                        Where CheckRegister.BankCode = Me.BankCode AndAlso _
                              CheckRegister.CheckNumber = CInt(Me.CheckNumber) AndAlso _
                              CheckRegister.CheckAmount = Me.CheckAmount _
                        Select CheckRegister).Any = False Then

                    IsValid = False
                    ErrorText = "Check does not exist."

                End If

            End If

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            If IsValid Then

                Select Case PropertyName

                    Case AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties.CheckNumber.ToString

                        If String.IsNullOrEmpty(Value) OrElse IsNumeric(Value) = False Then

                            IsValid = False
                            ErrorText = "Please enter a valid a numeric check value."

                        End If

                End Select

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
