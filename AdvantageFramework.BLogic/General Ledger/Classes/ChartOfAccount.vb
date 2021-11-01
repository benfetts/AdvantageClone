Namespace GeneralLedger.Classes

	<Serializable()>
	Public Class ChartOfAccount
		Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			BaseCode
			GeneralLedgerOfficeCrossReferenceCode
			DepartmentCode
			OtherCode
			Code
			Description
			Type
			BalanceType
            'CurrencyCode
            Payroll
			PurchaseOrder
			CDPRequired
			EnteredDate
			ModifiedDate
			UserCode
			IsInactive
		End Enum

#End Region

#Region " Variables "

		Private _GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
		Private _IsInactive As Boolean = False
		Private _GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property BaseCode() As String
			Get
				BaseCode = _GeneralLedgerAccount.BaseCode
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.BaseCode = value
				FormatCode()
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office Code", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property GeneralLedgerOfficeCrossReferenceCode() As String
			Get
				GeneralLedgerOfficeCrossReferenceCode = _GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode = value
				FormatCode()
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property DepartmentCode() As String
			Get
				DepartmentCode = _GeneralLedgerAccount.DepartmentCode
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.DepartmentCode = value
				FormatCode()
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property OtherCode() As String
			Get
				OtherCode = _GeneralLedgerAccount.OtherCode
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.OtherCode = value
				FormatCode()
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Account Code")>
		Public Property Code() As String
			Get
				Code = _GeneralLedgerAccount.Code
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.Code = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
			Get
				Description = _GeneralLedgerAccount.Description
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.Description = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Account Type")>
		Public Property Type() As String
			Get
				Type = _GeneralLedgerAccount.Type
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.Type = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property BalanceType() As Nullable(Of Short)
			Get
				BalanceType = _GeneralLedgerAccount.BalanceType
			End Get
			Set(ByVal value As Nullable(Of Short))
				_GeneralLedgerAccount.BalanceType = value
			End Set
		End Property
        '      <System.Runtime.Serialization.DataMemberAttribute(),
        '      AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Currency", PropertyType:=BaseClasses.PropertyTypes.CurrencyCode)>
        '      Public Property CurrencyCode() As String
        '	Get
        '              CurrencyCode = _GeneralLedgerAccount.CurrencyCode
        '          End Get
        '	Set(value As String)
        '              _GeneralLedgerAccount.CurrencyCode = value
        '          End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property Payroll() As Nullable(Of Short)
			Get
				Payroll = _GeneralLedgerAccount.Payroll
			End Get
			Set(ByVal value As Nullable(Of Short))
				_GeneralLedgerAccount.Payroll = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="PO")>
		Public Property PurchaseOrder() As Nullable(Of Short)
			Get
				PurchaseOrder = _GeneralLedgerAccount.PurchaseOrder
			End Get
			Set(ByVal value As Nullable(Of Short))
				_GeneralLedgerAccount.PurchaseOrder = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="C/D/P Required")>
		Public Property CDPRequired() As Nullable(Of Short)
			Get
				CDPRequired = _GeneralLedgerAccount.CDPRequired
			End Get
			Set(value As Nullable(Of Short))
				_GeneralLedgerAccount.CDPRequired = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date Entered")>
		Public Property EnteredDate() As Nullable(Of Date)
			Get
				EnteredDate = _GeneralLedgerAccount.EnteredDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_GeneralLedgerAccount.EnteredDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
			Get
				ModifiedDate = _GeneralLedgerAccount.ModifiedDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_GeneralLedgerAccount.ModifiedDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
			Get
				UserCode = _GeneralLedgerAccount.UserCode
			End Get
			Set(ByVal value As String)
				_GeneralLedgerAccount.UserCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Boolean
			Get
				IsInactive = _IsInactive
			End Get
			Set(ByVal value As Boolean)
				_IsInactive = value
				If value Then
					_GeneralLedgerAccount.Active = Nothing
				Else
					_GeneralLedgerAccount.Active = "A"
				End If
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
		System.ComponentModel.Browsable(False),
		Xml.Serialization.XmlIgnore()>
		Public ReadOnly Property GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount
			Get
				GeneralLedgerAccount = _GeneralLedgerAccount
			End Get
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			_GeneralLedgerAccount = New AdvantageFramework.Database.Entities.GeneralLedgerAccount

		End Sub
        Public Sub New(ByVal GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount, ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig)

            _GeneralLedgerAccount = GeneralLedgerAccount

            _IsInactive = If(GeneralLedgerAccount.Active = "A", False, True)

            _GeneralLedgerConfig = GeneralLedgerConfig

        End Sub
        Public Sub New(ByVal GLTemplate As AdvantageFramework.Database.Entities.GLTemplate, ByVal OfficeSegment As Object, ByVal DepartmentSegment As Object, ByVal OtherSegment As Object,
                       ByVal UserCode As String, ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig)

            _GeneralLedgerConfig = GeneralLedgerConfig

            _GeneralLedgerAccount = New AdvantageFramework.Database.Entities.GeneralLedgerAccount

            Me.BaseCode = GLTemplate.BaseCode
            Me.GeneralLedgerOfficeCrossReferenceCode = OfficeSegment
            Me.DepartmentCode = DepartmentSegment
            Me.OtherCode = OtherSegment

            FormatCode()

            Me.Description = GLTemplate.Description
            Me.Type = GLTemplate.Type
            Me.BalanceType = GLTemplate.BalanceType
            Me.Payroll = Nothing
            Me.PurchaseOrder = Nothing
            Me.IsInactive = False
            Me.CDPRequired = GLTemplate.CDPRequired
            Me.EnteredDate = Now
            Me.UserCode = UserCode

        End Sub
        Public Sub New(ByVal GeneralLedgerAccount As Object, ByVal OfficeSegment As Object, ByVal DepartmentSegment As Object, ByVal OtherSegment As Object,
                       ByVal UserCode As String, ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig)

            _GeneralLedgerConfig = GeneralLedgerConfig

            _GeneralLedgerAccount = New AdvantageFramework.Database.Entities.GeneralLedgerAccount

            Me.BaseCode = GeneralLedgerAccount.BaseCode
            Me.GeneralLedgerOfficeCrossReferenceCode = OfficeSegment
            Me.DepartmentCode = DepartmentSegment
            Me.OtherCode = OtherSegment

            FormatCode()

            Me.Description = GeneralLedgerAccount.Description
            Me.Type = GeneralLedgerAccount.Type
            Me.BalanceType = GeneralLedgerAccount.BalanceType
            Me.Payroll = GeneralLedgerAccount.Payroll
            Me.PurchaseOrder = GeneralLedgerAccount.PurchaseOrder
            Me.IsInactive = False
            Me.CDPRequired = GeneralLedgerAccount.CDPRequired
            Me.EnteredDate = Now
            Me.UserCode = UserCode

        End Sub
        Private Function GetSegmentCode(ByVal SegmentType As AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType) As String

			Dim SegmentCode As String = Nothing

			If SegmentType = Database.Entities.GeneralLedgerConfigSegmentType.Base Then

				SegmentCode = Me.BaseCode

			ElseIf SegmentType = Database.Entities.GeneralLedgerConfigSegmentType.Office Then

				SegmentCode = Me.GeneralLedgerOfficeCrossReferenceCode

			ElseIf SegmentType = Database.Entities.GeneralLedgerConfigSegmentType.Department Then

				SegmentCode = Me.DepartmentCode

			ElseIf SegmentType = Database.Entities.GeneralLedgerConfigSegmentType.Other Then

				SegmentCode = Me.OtherCode

			End If

			GetSegmentCode = SegmentCode

		End Function
		Private Sub FormatCode()

			Dim Code As String = Nothing

			If _GeneralLedgerConfig IsNot Nothing Then

				If _GeneralLedgerConfig.Segment1Format IsNot Nothing Then

					Code = GetSegmentCode(_GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0)) & AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigDelimiter(_GeneralLedgerConfig.Segment1After)

				End If

				If _GeneralLedgerConfig.Segment2Format IsNot Nothing Then

					Code += GetSegmentCode(_GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0)) & AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigDelimiter(_GeneralLedgerConfig.Segment2After)

				End If

				If _GeneralLedgerConfig.Segment3Format IsNot Nothing Then

					Code += GetSegmentCode(_GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0)) & AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigDelimiter(_GeneralLedgerConfig.Segment3After)

				End If

				If _GeneralLedgerConfig.Segment4Format IsNot Nothing Then

					Code += GetSegmentCode(_GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0))

				End If

			End If

			If Code IsNot Nothing Then

				Me.Code = Code

			End If

		End Sub
		Private Function GetSegmentFormatLength(ByVal SegmentType As AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType) As Integer

			Dim Length As Integer = 0

			If _GeneralLedgerConfig IsNot Nothing Then

				If _GeneralLedgerConfig.Segment1Format IsNot Nothing AndAlso _GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = SegmentType Then

					Length = _GeneralLedgerConfig.Segment1Format.Length

				ElseIf _GeneralLedgerConfig.Segment2Format IsNot Nothing AndAlso _GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = SegmentType Then

					Length = _GeneralLedgerConfig.Segment2Format.Length

				ElseIf _GeneralLedgerConfig.Segment3Format IsNot Nothing AndAlso _GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = SegmentType Then

					Length = _GeneralLedgerConfig.Segment3Format.Length

				ElseIf _GeneralLedgerConfig.Segment4Format IsNot Nothing AndAlso _GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = SegmentType Then

					Length = _GeneralLedgerConfig.Segment4Format.Length

				End If

			End If

			GetSegmentFormatLength = Length

		End Function
		Public Overrides Function ToString() As String

			ToString = Me.Code.ToString

		End Function
		Public Overrides Function IsEntityBeingAdded() As Boolean

			If _GeneralLedgerAccount.ID = 0 Then

				Return True

			Else

				Return False

			End If

		End Function
		Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			'objects
			Dim ErrorText As String = ""
			Dim PropertyValue As Object = Nothing

			If _GeneralLedgerConfig Is Nothing Then

                _GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(Me.DbContext)

            End If

			Select Case PropertyName

				Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Code.ToString

					PropertyValue = Value

					If Me.IsEntityBeingAdded Then

						If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GeneralLedgerAccounts
							Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
							Select Entity).Any Then

							IsValid = False

							ErrorText = "Please enter a unique code."

						End If

					End If

				Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString

					PropertyValue = Value

					If Me.IsRequiredProperty(Me.GetType, PropertyName) AndAlso (PropertyValue Is Nothing OrElse Len(PropertyValue.ToString.Trim) <> GetSegmentFormatLength(Database.Entities.GeneralLedgerConfigSegmentType.Base)) Then

						IsValid = False

						ErrorText = "Base Code does not match format."

					End If

				Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString

					PropertyValue = Value

					If Me.IsRequiredProperty(Me.GetType, PropertyName) AndAlso (PropertyValue Is Nothing OrElse Len(PropertyValue.ToString.Trim) <> GetSegmentFormatLength(Database.Entities.GeneralLedgerConfigSegmentType.Office)) Then

						IsValid = False

						ErrorText = "Office Code does not match format."

					End If

				Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString

					PropertyValue = Value

					If Me.IsRequiredProperty(Me.GetType, PropertyName) AndAlso (PropertyValue Is Nothing OrElse Len(PropertyValue.ToString.Trim) <> GetSegmentFormatLength(Database.Entities.GeneralLedgerConfigSegmentType.Department)) Then

						IsValid = False

						ErrorText = "Department Code does not match format."

					End If

				Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString

					PropertyValue = Value

					If Me.IsRequiredProperty(Me.GetType, PropertyName) AndAlso (PropertyValue Is Nothing OrElse Len(PropertyValue.ToString.Trim) <> GetSegmentFormatLength(Database.Entities.GeneralLedgerConfigSegmentType.Other)) Then

						IsValid = False

						ErrorText = "Other Code does not match format."

					End If

				Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Description.ToString

					PropertyValue = Value

					If String.IsNullOrWhiteSpace(PropertyValue) Then

						IsValid = False

						ErrorText = "Description cannot be blank."

					End If

			End Select

			ValidateCustomProperties = ErrorText

		End Function
		Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

			SetRequiredFields()

			ValidateEntity = MyBase.ValidateEntity(IsValid)

		End Function
		Public Overrides Sub SetRequiredFields()

			Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

			PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

			If _GeneralLedgerConfig Is Nothing Then

                _GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(Me.DbContext)

            End If

			For Each PropertyDescriptor In PropertyDescriptors

				Select Case PropertyDescriptor.Name

					Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString

						If (_GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base AndAlso _GeneralLedgerConfig.Segment1Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base AndAlso _GeneralLedgerConfig.Segment2Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base AndAlso _GeneralLedgerConfig.Segment3Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base AndAlso _GeneralLedgerConfig.Segment4Format IsNot Nothing) Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

					Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString

						If (_GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office AndAlso _GeneralLedgerConfig.Segment1Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office AndAlso _GeneralLedgerConfig.Segment2Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office AndAlso _GeneralLedgerConfig.Segment3Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office AndAlso _GeneralLedgerConfig.Segment4Format IsNot Nothing) Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

					Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString

						If (_GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department AndAlso _GeneralLedgerConfig.Segment1Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department AndAlso _GeneralLedgerConfig.Segment2Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department AndAlso _GeneralLedgerConfig.Segment3Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department AndAlso _GeneralLedgerConfig.Segment4Format IsNot Nothing) Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

					Case AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString

						If (_GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other AndAlso _GeneralLedgerConfig.Segment1Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other AndAlso _GeneralLedgerConfig.Segment2Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other AndAlso _GeneralLedgerConfig.Segment3Format IsNot Nothing) OrElse
								(_GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other AndAlso _GeneralLedgerConfig.Segment4Format IsNot Nothing) Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

				End Select

			Next

		End Sub

#End Region

	End Class

End Namespace

