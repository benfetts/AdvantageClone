Namespace Database.Entities

	<Table("POSTPERIOD")>
	Public Class PostPeriod
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			ARStatus
			Month
			Year
			GLStatus
			APStatus
			StartDate
			EndDate
			Description
			UserCode
			EnteredDate
			ModifiedDate
			ID
			EmployeeTimeStatus
			EmployeeTimeForecasts
			CheckRegisters
			VoidCheckRegisters
			AccountPayables
			GeneralLedgers
			AccountPayableRecurs
			AccountPayableRecur2
			AccountReceivables
			ClientCashReceipts
			OtherCashReceipts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("PPPERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Posting Period", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(1)>
		<Column("PPARCURMTH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/R Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property ARStatus() As String
		<Column("PPGLMONTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Fiscal Month")>
		Public Property Month() As Nullable(Of Short)
		<MaxLength(5)>
		<Column("PPGLYEAR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Fiscal Year")>
		Public Property Year() As String
		<MaxLength(1)>
		<Column("PPGLCURMTH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property GLStatus() As String
		<MaxLength(1)>
		<Column("PPAPCURMTH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/P Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property APStatus() As String
		<Column("PPSRTDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Starting Date")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("PPENDDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ending Date")>
		Public Property EndDate() As Nullable(Of Date)
		<Required>
		<MaxLength(10)>
		<Column("PPDESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(100)>
		<Column("PPUSER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="User")>
		Public Property UserCode() As String
		<Column("PPENTDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Date Entered")>
		Public Property EnteredDate() As Nullable(Of Date)
		<Column("PPMODDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Date Modified")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(1)>
		<Column("PPTECURMTH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Emp Time Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property EmployeeTimeStatus() As String

        Public Overridable Property EmployeeTimeForecasts As ICollection(Of Database.Entities.EmployeeTimeForecast)
        Public Overridable Property AccountPayables As ICollection(Of Database.Entities.AccountPayable)
        Public Overridable Property GeneralLedgers As ICollection(Of Database.Entities.GeneralLedger)
        Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        Public Overridable Property ClientCashReceipts As ICollection(Of Database.Entities.ClientCashReceipt)
        Public Overridable Property OtherCashReceipts As ICollection(Of Database.Entities.OtherCashReceipt)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim DatesRequired As Boolean = False

            If _Code IsNot Nothing Then

                DatesRequired = Not _Code.Contains("YE")

            End If

            SetRequired(AdvantageFramework.Database.Entities.PostPeriod.Properties.StartDate.ToString, DatesRequired)
            SetRequired(AdvantageFramework.Database.Entities.PostPeriod.Properties.EndDate.ToString, DatesRequired)

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim Month As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.PostPeriod.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).PostPeriods
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique post period code."

                        ElseIf DirectCast(PropertyValue, String).Length <> 6 Then

                            IsValid = False
                            ErrorText = "The posting period must be 6 characters in the format ""YYYYMM""."

                        Else

                            Month = DirectCast(PropertyValue, String).Substring(4, 2)

                            If IsNumeric(Month) Then

                                If CInt(Month) < 1 OrElse CInt(Month) > 12 Then

                                    IsValid = False

                                End If

                            Else

                                If Month <> "YE" Then

                                    IsValid = False

                                End If

                            End If

                            If IsValid = False Then

                                ErrorText = "The posting period format is YYYYMM, where YYYY = year and MM = month."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.PostPeriod.Properties.GLStatus.ToString, _
                     AdvantageFramework.Database.Entities.PostPeriod.Properties.ARStatus.ToString, _
                     AdvantageFramework.Database.Entities.PostPeriod.Properties.APStatus.ToString, _
                     AdvantageFramework.Database.Entities.PostPeriod.Properties.EmployeeTimeStatus.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If DirectCast(PropertyValue, String) = "" Then

                            Value = Nothing

                        Else

                            If (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.PostPeriodStatus)) _
                                Where Entity.Code = DirectCast(PropertyValue, String) _
                                Select Entity).Any = False Then

                                IsValid = False

                                ErrorText = "Please enter a valid " & AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName) & "."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
