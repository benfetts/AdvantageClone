Namespace Security.Database.Classes

    <Serializable()>
    Public Class UserModuleAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserID
            UserCode
            EmployeeTerminationDate
            EmployeeCode
            EmployeeName
            OfficeCode
            OfficeName
            DepartmentCode
            DepartmentName
            IsBlocked
            CanPrint
            CanUpdate
            CanAdd
            Custom1
            Custom2
        End Enum

#End Region

#Region " Variables "

        Private _UserID As Integer = Nothing
        Private _UserCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeTerminationDate As Nullable(Of Date) = Nothing
        Private _EmployeeName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _DepartmentCode As String = Nothing
        Private _DepartmentName As String = Nothing
        Private _IsBlocked As Boolean = Nothing
        Private _CanPrint As Boolean = Nothing
        Private _CanUpdate As Boolean = Nothing
        Private _CanAdd As Boolean = Nothing
        Private _Custom1 As Boolean = Nothing
        Private _Custom2 As Boolean = Nothing

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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property EmployeeTerminationDate() As Nullable(Of Date)
            Get
                EmployeeTerminationDate = _EmployeeTerminationDate
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
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property DepartmentName() As String
            Get
                DepartmentName = _DepartmentName
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanPrint() As Boolean
            Get
                CanPrint = _CanPrint
            End Get
            Set(ByVal value As Boolean)
                _CanPrint = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanUpdate() As Boolean
            Get
                CanUpdate = _CanUpdate
            End Get
            Set(ByVal value As Boolean)
                _CanUpdate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanAdd() As Boolean
            Get
                CanAdd = _CanAdd
            End Get
            Set(ByVal value As Boolean)
                _CanAdd = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Custom1() As Boolean
            Get
                Custom1 = _Custom1
            End Get
            Set(ByVal value As Boolean)
                _Custom1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Custom2() As Boolean
            Get
                Custom2 = _Custom2
            End Get
            Set(ByVal value As Boolean)
                _Custom2 = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal User As AdvantageFramework.Security.Database.Entities.User)

            _UserID = User.ID
            _UserCode = User.UserCode
            _EmployeeTerminationDate = User.Employee.TerminationDate
            _EmployeeCode = User.EmployeeCode
            _EmployeeName = User.Employee.ToString
            _OfficeCode = User.Employee.OfficeCode
            _OfficeName = If(User.Employee.Office IsNot Nothing, User.Employee.Office.Name, Nothing)
            _DepartmentCode = User.Employee.DepartmentCode
            _DepartmentName = If(User.Employee.Department IsNot Nothing, User.Employee.Department.Description, Nothing)
            _IsBlocked = False
            _CanPrint = False
            _CanUpdate = False
            _CanAdd = False
            _Custom1 = False
            _Custom2 = False

        End Sub
        Public Sub New(ByVal User As AdvantageFramework.Security.Database.Entities.User, ByVal SelectedModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

            'objects
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            _UserID = User.ID
            _UserCode = User.UserCode
            _EmployeeTerminationDate = User.Employee.TerminationDate
            _EmployeeCode = User.EmployeeCode
            _EmployeeName = User.Employee.ToString
            _OfficeCode = User.Employee.OfficeCode
            _OfficeName = If(User.Employee.Office IsNot Nothing, User.Employee.Office.Name, Nothing)
            _DepartmentCode = User.Employee.DepartmentCode
            _DepartmentName = If(User.Employee.Department IsNot Nothing, User.Employee.Department.Description, Nothing)
            _IsBlocked = False
            _CanPrint = False
            _CanUpdate = False
            _CanAdd = False
            _Custom1 = False
            _Custom2 = False

            If SelectedModuleList IsNot Nothing AndAlso SelectedModuleList.Count > 0 AndAlso User IsNot Nothing Then

                _IsBlocked = True
                _CanPrint = True
                _CanUpdate = True
                _CanAdd = True
                _Custom1 = True
                _Custom2 = True

                For Each [Module] In SelectedModuleList

                    Try

                        UserModuleAccess = User.UserModuleAccesses.SingleOrDefault(Function(UsrModAccess) UsrModAccess.ModuleID = [Module].ModuleID)

                    Catch ex As Exception
                        UserModuleAccess = Nothing
                    End Try

                    If UserModuleAccess IsNot Nothing Then

                        If UserModuleAccess.IsBlocked = False Then

                            _IsBlocked = False

                        End If

                        If UserModuleAccess.CanPrint = False Then

                            _CanPrint = False

                        End If

                        If UserModuleAccess.CanUpdate = False Then

                            _CanUpdate = False

                        End If

                        If UserModuleAccess.CanAdd = False Then

                            _CanAdd = False

                        End If

                        If UserModuleAccess.Custom1 = False Then

                            _Custom1 = False

                        End If

                        If UserModuleAccess.Custom2 = False Then

                            _Custom2 = False

                        End If

                    End If

                Next

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

    End Class

End Namespace
