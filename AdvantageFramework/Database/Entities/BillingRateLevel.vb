Namespace Database.Entities

	<Table("BILL_RATE_PREC")>
	Public Class BillingRateLevel
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			IsFunctionIncluded
			IsEmployeeIncluded
			IsClientIncluded
			IsDivisionIncluded
			IsProductIncluded
			IsSalesClassIncluded
			IsEffectiveDateIncluded
			IsBillingRateDetailIncluded
			IsNonBillableIncluded
			IsCommissionIncluded
			IsTaxIncluded
			IsTaxCommissionIncluded
			IsFeeTimeIncluded
			Number
			Description
			IsInactive
			IsRequired
			IsEmployeeTitleIncluded
			BillingRateDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("BILL_RATE_PREC_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ID() As Short
		<Column("FNC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function")>
		Public Property IsFunctionIncluded() As Nullable(Of Short)
		<Column("EMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee")>
		Public Property IsEmployeeIncluded() As Nullable(Of Short)
		<Column("CL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client")>
		Public Property IsClientIncluded() As Nullable(Of Short)
		<Column("DIV_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division")>
		Public Property IsDivisionIncluded() As Nullable(Of Short)
		<Column("PRD_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product")>
		Public Property IsProductIncluded() As Nullable(Of Short)
		<Column("SC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Sales Class")>
		Public Property IsSalesClassIncluded() As Nullable(Of Short)
		<Column("EFF_DT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Effective Date")>
		Public Property IsEffectiveDateIncluded() As Nullable(Of Short)
		<Column("BILL_RATE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Rate")>
		Public Property IsBillingRateDetailIncluded() As Nullable(Of Short)
		<Column("NONBILL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Non Billable")>
		Public Property IsNonBillableIncluded() As Nullable(Of Short)
		<Column("COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Markup Percent")>
		Public Property IsCommissionIncluded() As Nullable(Of Short)
		<Column("TAX_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Sales Tax")>
		Public Property IsTaxIncluded() As Nullable(Of Short)
		<Column("TAX_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Markup Tax Flags")>
		Public Property IsTaxCommissionIncluded() As Nullable(Of Short)
		<Column("FEE_TIME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Fee Time")>
		Public Property IsFeeTimeIncluded() As Nullable(Of Short)
		<Required>
		<Column("PRECEDENCE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order")>
		Public Property Number() As Integer
		<MaxLength(254)>
		<Column("LEVEL_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description")>
		Public Property Description() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("ADV_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property IsRequired() As Nullable(Of Short)
		<Column("TITLE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee Title")>
		Public Property IsEmployeeTitleIncluded() As Nullable(Of Short)

        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number & " - " & Me.Description

        End Function
        Protected Function IsDuplicateBillingRateLevel() As Boolean

            'objects
            Dim IsDuplicate As Boolean = False

            For Each BillingRateLevel In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).BillingRateLevels

                If BillingRateLevel.IsClientIncluded.GetValueOrDefault(0) = Me.IsClientIncluded.GetValueOrDefault(0) Then

                    If BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0) = Me.IsDivisionIncluded.GetValueOrDefault(0) Then

                        If BillingRateLevel.IsProductIncluded.GetValueOrDefault(0) = Me.IsProductIncluded.GetValueOrDefault(0) Then

                            If BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0) = Me.IsSalesClassIncluded.GetValueOrDefault(0) Then

                                If BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0) = Me.IsFunctionIncluded.GetValueOrDefault(0) Then

                                    If BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0) = Me.IsEmployeeTitleIncluded.GetValueOrDefault(0) Then

                                        If BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0) = Me.IsEmployeeIncluded.GetValueOrDefault(0) Then

                                            If BillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0) = Me.IsEffectiveDateIncluded.GetValueOrDefault(0) Then

                                                AdvantageFramework.Navigation.ShowMessageBox("There are duplicate rate structures in use.", WinForm.MessageBox.MessageBoxButtons.OK)

                                                IsDuplicate = True

                                                Exit For

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            Next

            IsDuplicateBillingRateLevel = IsDuplicate

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects 
            Dim ErrorText As String = ""

            If Me.IsEntityBeingAdded() Then

                If Me.IsDuplicateBillingRateLevel Then

                    IsValid = False

                End If

            End If

            If IsValid Then

                ErrorText = MyBase.ValidateEntity(IsValid)

            End If

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsDivisionIncluded.ToString

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            If CBool(Me.IsDivisionIncluded.GetValueOrDefault(0)) AndAlso CBool(Me.IsClientIncluded.GetValueOrDefault(0)) = False Then

                                IsValid = False

                                ErrorText = "This row uses an invalid combination of levels."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsProductIncluded.ToString

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            If CBool(Me.IsProductIncluded.GetValueOrDefault(0)) AndAlso (CBool(Me.IsClientIncluded.GetValueOrDefault(0)) = False OrElse CBool(Me.IsDivisionIncluded.GetValueOrDefault(0)) = False) Then

                                IsValid = False

                                ErrorText = "This row uses an invalid combination of levels."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsEffectiveDateIncluded.ToString

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            If CBool(Me.IsEffectiveDateIncluded.GetValueOrDefault(0)) = True AndAlso
                               CBool(Me.IsClientIncluded.GetValueOrDefault(0)) = False AndAlso
                               CBool(Me.IsDivisionIncluded.GetValueOrDefault(0)) = False AndAlso
                               CBool(Me.IsProductIncluded.GetValueOrDefault(0)) = False AndAlso
                               CBool(Me.IsSalesClassIncluded.GetValueOrDefault(0)) = False AndAlso
                               CBool(Me.IsFunctionIncluded.GetValueOrDefault(0)) = False AndAlso
                               CBool(Me.IsEmployeeTitleIncluded.GetValueOrDefault(0)) = False AndAlso
                               CBool(Me.IsEmployeeIncluded.GetValueOrDefault(0)) = False Then

                                IsValid = False

                                ErrorText = "This row uses an invalid combination of levels."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Sub SetDefaultDescription()

            Dim DefaultDescription As String = ""

            If CBool(Me.IsClientIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = "Client/"

            End If

            If CBool(Me.IsDivisionIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Division/"

            End If

            If CBool(Me.IsProductIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Product/"

            End If

            If CBool(Me.IsSalesClassIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Sales Class/"

            End If

            If CBool(Me.IsFunctionIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Function/"

            End If

            If CBool(Me.IsEmployeeIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Employee/"

            End If

            If CBool(Me.IsEmployeeTitleIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Employee Title/"

            End If

            If CBool(Me.IsEffectiveDateIncluded.GetValueOrDefault(0)) Then

                DefaultDescription = DefaultDescription & "Effective Date/"

            End If

            If DefaultDescription.Length > 0 Then

                Me.Description = DefaultDescription.Substring(0, DefaultDescription.Length - 1)

            End If
            
        End Sub

#End Region

	End Class

End Namespace
