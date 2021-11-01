Namespace Security.Database.Classes

    <Serializable()>
    Public Class GroupUserDefinedReportAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GroupID
            Group
            IsBlocked
        End Enum

#End Region

#Region " Variables "

        Private _GroupID As Integer = Nothing
        Private _Group As String = Nothing
        Private _IsBlocked As Boolean = Nothing

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
                Group = _Group
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

        Public Sub New(ByVal Group As AdvantageFramework.Security.Database.Entities.Group)

            _GroupID = Group.ID
            _Group = Group.Description
            _IsBlocked = False

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.GroupID

        End Function
        Public Sub SetUserDefinedReportAccess(ByVal Session As AdvantageFramework.Security.Session, ByVal SelectedUserDefinedReportList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport))

            'objects
            Dim GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess = Nothing

            If SelectedUserDefinedReportList IsNot Nothing AndAlso SelectedUserDefinedReportList.Count > 0 Then

                _IsBlocked = True

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each UserDefinedReport In SelectedUserDefinedReportList

                        GroupUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.LoadByUserDefinedReportIDAndGroupID(SecurityDbContext, UserDefinedReport.ID, _GroupID)

                        If GroupUserDefinedReportAccess IsNot Nothing Then

                            If GroupUserDefinedReportAccess.IsBlocked = False Then

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
