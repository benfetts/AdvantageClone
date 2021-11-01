Namespace Security.Database.Classes

    <Serializable()>
    Public Class ReportAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ReportCode
            ReportNumber
            ReportCategory
            ReportType
            ApplicationModule
            ReportName
            Enabled
        End Enum

#End Region

#Region " Variables "

        Private _ReportCode As String = Nothing
        Private _ReportNumber As Integer = Nothing
        Private _ReportCategory As String = Nothing
        Private _ReportType As Integer = Nothing
        Private _ApplicationModule As String = Nothing
        Private _ReportName As String = Nothing
        Private _Enabled As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ReportCode() As String
            Get
                ReportCode = _ReportCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ReportNumber() As Integer
            Get
                ReportNumber = _ReportNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ReportCategory() As String
            Get
                ReportCategory = _ReportCategory
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ReportType() As Integer
            Get
                ReportType = _ReportType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ApplicationModule() As String
            Get
                ApplicationModule = _ApplicationModule
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ReportName() As String
            Get
                ReportName = _ReportName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Enabled As Boolean
            Get
                Enabled = _Enabled
            End Get
            Set(value As Boolean)
                _Enabled = value
            End Set
        End Property

#End Region

#Region " Methods "

		Public Sub New(ByVal Report As AdvantageFramework.Security.Database.Entities.Report)

			_ReportCode = Report.Code
			_ReportNumber = Report.Number
			_ReportCategory = Report.Category
			_ReportType = Report.Type
			_ApplicationModule = AdvantageFramework.Security.LoadReportTypeName(Report.Type)
			_ReportName = Report.Name
			_Enabled = False

		End Sub
		Public Sub New(ByVal Report As AdvantageFramework.Security.Database.Entities.Report, ByVal Session As AdvantageFramework.Security.Session,
					   ByVal SelectedUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User))

			'objects
			Dim ReportAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.ReportAccess) = Nothing

			_ReportCode = Report.Code
			_ReportNumber = Report.Number
			_ReportCategory = Report.Category
			_ReportType = Report.Type
			_ApplicationModule = AdvantageFramework.Security.LoadReportTypeName(Report.Type)
			_ReportName = Report.Name
			_Enabled = False

			If SelectedUsersList IsNot Nothing AndAlso SelectedUsersList.Count > 0 Then

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

					ReportAccessList = AdvantageFramework.Security.Database.Procedures.ReportAccess.LoadByReportCode(SecurityDbContext, Me.ReportCode).ToList

					If ReportAccessList.Any(Function(RptAccess) SelectedUsersList.Select(Function(User) User.UserCode).Contains(RptAccess.UserCode) AndAlso RptAccess.Enabled = "N") Then

						Me.Enabled = False

					Else

						Me.Enabled = True

					End If

				End Using

			End If

		End Sub
		Public Sub New(ByVal Report As AdvantageFramework.Security.Database.Entities.Report, ByVal Session As AdvantageFramework.Security.Session, ByVal CurrentUser As AdvantageFramework.Security.Classes.User)

			'objects
			Dim ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess = Nothing

			_ReportCode = Report.Code
			_ReportNumber = Report.Number
			_ReportCategory = Report.Category
			_ReportType = Report.Type
			_ApplicationModule = AdvantageFramework.Security.LoadReportTypeName(Report.Type)
			_ReportName = Report.Name
			_Enabled = False

			If CurrentUser IsNot Nothing Then

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

					ReportAccess = AdvantageFramework.Security.Database.Procedures.ReportAccess.LoadByUserCodeAndReportCode(SecurityDbContext, CurrentUser.UserCode, Me.ReportCode)

					If ReportAccess IsNot Nothing Then

						If ReportAccess.Enabled = "N" Then

							Me.Enabled = False

						Else

							Me.Enabled = True

						End If

					Else

						Me.Enabled = True

					End If

				End Using

			End If

		End Sub
		Public Overrides Function ToString() As String

            ToString = Me.ReportName

        End Function

#End Region

    End Class

End Namespace
