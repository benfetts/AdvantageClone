Namespace Security.Database.Classes

    <Serializable()>
    Public Class GroupModuleAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GroupID
            Group
            IsBlocked
            CanPrint
            CanUpdate
            CanAdd
            Custom1
            Custom2
        End Enum

#End Region

#Region " Variables "

        Private _GroupID As Integer = Nothing
        Private _GroupDescription As String = Nothing
        Private _IsBlocked As Boolean = Nothing
        Private _CanPrint As Boolean = Nothing
        Private _CanUpdate As Boolean = Nothing
        Private _CanAdd As Boolean = Nothing
        Private _Custom1 As Boolean = Nothing
        Private _Custom2 As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property GroupID() As Integer
            Get
                GroupID = _GroupID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Group() As String
            Get
                Group = _GroupDescription
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

        Public Sub New(ByVal Group As AdvantageFramework.Security.Database.Entities.Group)

            _GroupID = Group.ID
            _GroupDescription = Group.Description
            _IsBlocked = False
            _CanPrint = False
            _CanUpdate = False
            _CanAdd = False
            _Custom1 = False
            _Custom2 = False

        End Sub
        Public Sub New(ByVal Group As AdvantageFramework.Security.Database.Entities.Group, ByVal SelectedModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

            'objects
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            _GroupID = Group.ID
            _GroupDescription = Group.Description
            _IsBlocked = False
            _CanPrint = False
            _CanUpdate = False
            _CanAdd = False
            _Custom1 = False
            _Custom2 = False

            If SelectedModuleList IsNot Nothing AndAlso SelectedModuleList.Count > 0 AndAlso Group IsNot Nothing Then

                _IsBlocked = True
                _CanPrint = True
                _CanUpdate = True
                _CanAdd = True
                _Custom1 = True
                _Custom2 = True

                For Each [Module] In SelectedModuleList

                    Try

                        GroupModuleAccess = Group.GroupModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = [Module].ModuleID)

                    Catch ex As Exception
                        GroupModuleAccess = Nothing
                    End Try

                    If GroupModuleAccess IsNot Nothing Then

                        If GroupModuleAccess.IsBlocked = False Then

                            _IsBlocked = False

                        End If

                        If GroupModuleAccess.CanPrint = False Then

                            _CanPrint = False

                        End If

                        If GroupModuleAccess.CanUpdate = False Then

                            _CanUpdate = False

                        End If

                        If GroupModuleAccess.CanAdd = False Then

                            _CanAdd = False

                        End If

                        If GroupModuleAccess.Custom1 = False Then

                            _Custom1 = False

                        End If

                        If GroupModuleAccess.Custom2 = False Then

                            _Custom2 = False

                        End If

                    End If

                Next

            End If

        End Sub

        Public Overrides Function ToString() As String

            ToString = Me.GroupID

        End Function
        Public Sub SetModuleAccess(ByVal Session As AdvantageFramework.Security.Session, ByVal SelectedModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

            'objects
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            If SelectedModuleList IsNot Nothing AndAlso SelectedModuleList.Count > 0 Then

                _IsBlocked = True
                _CanPrint = True
                _CanUpdate = True
                _CanAdd = True
                _Custom1 = True
                _Custom2 = True

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)



                End Using

            End If

        End Sub
        Public Sub Clear()

            _IsBlocked = False
            _CanPrint = False
            _CanUpdate = False
            _CanAdd = False
            _Custom1 = False
            _Custom2 = False

        End Sub

#End Region

    End Class

End Namespace
