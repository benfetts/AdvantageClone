Namespace Database.Classes

	<Serializable()>
	Public Class PostPeriod
		Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			GLStatus
			ARStatus
			APStatus
			EmployeeTimeStatus
			StartDate
			EndDate
			Month
			Year
			EnteredDate
			ModifiedDate
			Description
			UserCode
			ID
			UnpostedJournalEntry
		End Enum

#End Region

#Region " Variables "

		Private _PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
		Private _UnpostedJournalEntry As Boolean = False

#End Region

#Region " Properties "

		<System.ComponentModel.Browsable(False),
		Xml.Serialization.XmlIgnore()>
		Public Overrides ReadOnly Property AttachedEntityType As System.Type
			Get
				AttachedEntityType = GetType(AdvantageFramework.Database.Entities.PostPeriod)
			End Get
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Posting Period", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
			Get
				Code = _PostPeriod.Code
			End Get
			Set(ByVal value As String)
				_PostPeriod.Code = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Status", PropertyType:=BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property GLStatus() As String
			Get
				GLStatus = _PostPeriod.GLStatus
			End Get
			Set(ByVal value As String)
				_PostPeriod.GLStatus = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/R Status", PropertyType:=BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property ARStatus() As String
			Get
				ARStatus = _PostPeriod.ARStatus
			End Get
			Set(ByVal value As String)
				_PostPeriod.ARStatus = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/P Status", PropertyType:=BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property APStatus() As String
			Get
				APStatus = _PostPeriod.APStatus
			End Get
			Set(ByVal value As String)
				_PostPeriod.APStatus = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Emp Time Status", PropertyType:=BaseClasses.PropertyTypes.PostPeriodStatus)>
		Public Property EmployeeTimeStatus() As String
			Get
				EmployeeTimeStatus = _PostPeriod.EmployeeTimeStatus
			End Get
			Set(ByVal value As String)
				_PostPeriod.EmployeeTimeStatus = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Starting Date")>
		Public Property StartDate() As Nullable(Of Date)
			Get
				StartDate = _PostPeriod.StartDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_PostPeriod.StartDate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ending Date")>
		Public Property EndDate() As Nullable(Of Date)
			Get
				EndDate = _PostPeriod.EndDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_PostPeriod.EndDate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Fiscal Month")>
		Public Property Month() As Nullable(Of Short)
			Get
				Month = _PostPeriod.Month
			End Get
			Set(ByVal value As Nullable(Of Short))
				_PostPeriod.Month = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Fiscal Year")>
		Public Property Year() As String
			Get
				Year = _PostPeriod.Year
			End Get
			Set(ByVal value As String)
				_PostPeriod.Year = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
			Get
				Description = _PostPeriod.Description
			End Get
			Set(ByVal value As String)
				_PostPeriod.Description = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date Entered", IsReadOnlyColumn:=True)>
		Public Property EnteredDate() As Nullable(Of Date)
			Get
				EnteredDate = _PostPeriod.EnteredDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_PostPeriod.EnteredDate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date Modified", IsReadOnlyColumn:=True)>
		Public Property ModifiedDate() As Nullable(Of Date)
			Get
				ModifiedDate = _PostPeriod.ModifiedDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_PostPeriod.ModifiedDate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="User", IsReadOnlyColumn:=True)>
		Public Property UserCode() As String
			Get
				UserCode = _PostPeriod.UserCode
			End Get
			Set(ByVal value As String)
				_PostPeriod.UserCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
			Get
				ID = _PostPeriod.ID
			End Get
			Set(ByVal value As Integer)
				_PostPeriod.ID = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public ReadOnly Property UnpostedJournalEntry As Boolean
			Get
				UnpostedJournalEntry = _UnpostedJournalEntry
			End Get
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			_PostPeriod = New AdvantageFramework.Database.Entities.PostPeriod

		End Sub
		Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod)

			_PostPeriod = PostPeriod

			Try

				If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.GLENTHDR WHERE GLEHPP = '{0}' AND (GLEHPOSTSUM IS NULL OR GLEHVOID <> 1)", PostPeriod.Code)).FirstOrDefault > 0 Then

					_UnpostedJournalEntry = True

				End If

			Catch ex As Exception
				_UnpostedJournalEntry = False
			End Try

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Description

		End Function
		Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

			_PostPeriod.DbContext = Me.DbContext

			ValidateEntity = _PostPeriod.ValidateEntity(IsValid)

		End Function
		Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			_PostPeriod.DbContext = Me.DbContext

			ValidateEntityProperty = _PostPeriod.ValidateEntityProperty(PropertyName, IsValid, Value)

		End Function
		Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			_PostPeriod.DbContext = Me.DbContext

			ValidateCustomProperties = _PostPeriod.ValidateCustomProperties(PropertyName, IsValid, Value)

		End Function
		Public Function GetEntity() As AdvantageFramework.Database.Entities.PostPeriod

			GetEntity = _PostPeriod

		End Function

#End Region

	End Class

End Namespace
