Namespace Security.Database.Classes

    <Serializable()>
    Public Class UserUserDefinedReportAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserID
            UserCode
            EmployeeCode
            EmployeeName
            IsBlocked
        End Enum

#End Region

#Region " Variables "

        Private _UserID As Integer = Nothing
        Private _UserCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _IsBlocked As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property UserID() As Integer
            Get
                UserID = _UserID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsBlocked() As Boolean
            Get
                IsBlocked = _IsBlocked
            End Get
            Set(ByVal value As Boolean)
                _IsBlocked = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal User As AdvantageFramework.Security.Database.Entities.User)

            _UserID = User.ID
            _UserCode = User.UserCode
            _EmployeeCode = User.EmployeeCode
            _EmployeeName = User.Employee.ToString
            _IsBlocked = False

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function
        Public Sub SetUserDefinedReportAccess(ByVal Session As AdvantageFramework.Security.Session, ByVal SelectedUserDefinedReportList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport))

            'objects
            Dim UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess = Nothing

            If SelectedUserDefinedReportList IsNot Nothing AndAlso SelectedUserDefinedReportList.Count > 0 Then

                _IsBlocked = True

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each UserDefinedReport In SelectedUserDefinedReportList

                        UserUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, UserDefinedReport.ID, _UserID)

                        If UserUserDefinedReportAccess IsNot Nothing Then

                            If UserUserDefinedReportAccess.IsBlocked = False Then

                                _IsBlocked = False

                            End If

                        End If

                    Next

                End Using

            End If

        End Sub
        Public Sub Clear()

            _IsBlocked = False

        End Sub

#End Region

    End Class

End Namespace
